using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AdvancedDatabaseTermProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SqlCommand sqlcommandUpd, sqlcommandSel;
        public int deadlockCount = 0;
        public int numberOfDeadlockbyTypeA, numberOfDeadlockbyTypeB = 0;
        public int exceptionNumb = 0;
        private IsolationLevel ısolationLvl;
        private TimeSpan totTimeA, totTimeB;
        Stopwatch watch = new Stopwatch();
        Stopwatch watch2 = new Stopwatch();



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            isolationLvlComboBox.Items.Add("Read Uncommitted");
            isolationLvlComboBox.Items.Add("Read Committed");
            isolationLvlComboBox.Items.Add("Repeatable Read");
            isolationLvlComboBox.Items.Add("Serializable");
        }
        private void isolationLvlDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isolationLvlComboBox.SelectedIndex == 0)
            {
                ısolationLvl = IsolationLevel.ReadUncommitted;
            }
            else if (isolationLvlComboBox.SelectedIndex == 1)
            {
                ısolationLvl = IsolationLevel.ReadCommitted;
            }
            else if (isolationLvlComboBox.SelectedIndex == 2)
            {
                ısolationLvl = IsolationLevel.RepeatableRead;
            }
            else if (isolationLvlComboBox.SelectedIndex == 3)
            {
                ısolationLvl = IsolationLevel.Serializable;
            }

        }



        public void UpdateQuery(string beginDate, string endDate, SqlConnection con, SqlTransaction transaction)
        {
            string sqlupdQuery = "UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 " +
                "WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                "AND Sales.SalesOrderHeader.OrderDate " +
                "BETWEEN @BeginDate AND @EndDate AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";

            sqlcommandUpd = new SqlCommand(sqlupdQuery, con, transaction);
            sqlcommandUpd.Parameters.AddWithValue("@BeginDate", beginDate);
            sqlcommandUpd.Parameters.AddWithValue("@EndDate ", endDate);

        }

        public void SelectQuery(string beginDate, string endDate, SqlConnection con, SqlTransaction transaction)
        {
            string sqlselQuery = "SELECT SUM(Sales.SalesOrderDetail.OrderQty) " +
                                    "FROM Sales.SalesOrderDetail " +
                                 "WHERE UnitPrice > 100 AND EXISTS(SELECT * FROM Sales.SalesOrderHeader " +
                                 "WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID " +
                                    "AND Sales.SalesOrderHeader.OrderDate " +
                                    "BETWEEN @BeginDate AND @EndDate AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)";
            sqlcommandSel = new SqlCommand(sqlselQuery, con, transaction);
            sqlcommandSel.Parameters.AddWithValue("@BeginDate", beginDate);
            sqlcommandSel.Parameters.AddWithValue("@EndDate", endDate);

        }
        public void TypeAUsersThread()
        {

            string connectionString = "server= DESKTOP-OEQJFLF;database=AdventureWorks2012;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlTransaction transaction = null;
            watch.Start();


            for (int i = 0; i < 100; i++)
            {

                try
                {
                    conn.Open();
                    try
                    {
                        transaction = conn.BeginTransaction(IsolationLevel.RepeatableRead);

                        Random random = new Random();

                        if (random.NextDouble() < 0.5)
                        {
                            UpdateQuery("20110101", "20111231", conn, transaction);
                            sqlcommandUpd.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            UpdateQuery("20120101", "20121231", conn, transaction);
                            sqlcommandUpd.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            UpdateQuery("20130101", "20131231", conn, transaction);
                            sqlcommandUpd.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            UpdateQuery("20140101", "20141231", conn, transaction);
                            sqlcommandUpd.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            UpdateQuery("20150101", "20151231", conn, transaction);
                            sqlcommandUpd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (SqlException exc)
                    {
                        if (exc.Number == 1205)
                        {
                            numberOfDeadlockbyTypeA += 1;
                            transaction.Rollback();

                        }
                        else
                            throw;

                    }
                }

                catch (Exception ex)
                {
                    exceptionNumb++;
                    Console.WriteLine(ex.GetType());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

            }
            watch.Stop();
            Console.WriteLine("Type A Time elapsed: {0:hh\\:mm\\:ss}", watch.Elapsed);
            Console.WriteLine("Type A deadlock: " + numberOfDeadlockbyTypeA);
        }

        public void TypeBUsersThread()
        {
            string connectionString = "server = DESKTOP-OEQJFLF;database=AdventureWorks2012;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlTransaction transaction = null;
            watch2.Start();



            for (int i = 0; i < 100; i++)
            {
                try
                {
                    conn.Open();
                    try
                    {
                        transaction = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                        Random random = new Random();

                        if (random.NextDouble() < 0.5)
                        {
                            SelectQuery("20110101", "20111231", conn, transaction);
                            sqlcommandSel.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            SelectQuery("20120101", "20121231", conn, transaction);
                            sqlcommandSel.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            SelectQuery("20130101", "20131231", conn, transaction);
                            sqlcommandSel.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            SelectQuery("20140101", "20141231", conn, transaction);
                            sqlcommandSel.ExecuteNonQuery();
                        }
                        if (random.NextDouble() < 0.5)
                        {
                            SelectQuery("20150101", "20151231", conn, transaction);
                            sqlcommandSel.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (SqlException exc)
                    {
                        if (exc.Number == 1205)
                        {
                            numberOfDeadlockbyTypeB += 1;
                            transaction.Rollback();

                        }
                        else
                            throw;

                    }
                }

                catch (Exception ex)
                {
                    exceptionNumb++;
                    Console.WriteLine(ex.GetType());

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

            }
            watch.Stop();
            Console.WriteLine("Type B Time elapsed: {0:hh\\:mm\\:ss}", watch.Elapsed);
            Console.WriteLine("Type B deadlock: " + numberOfDeadlockbyTypeB);

        }

        private void typeAtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Thread> ThreadTypeA = new List<Thread>();
            List<Thread> ThreadTypeB = new List<Thread>();

            int numberofTypeAUsers = Int32.Parse(typeAtextBox.Text);
            int numberofTypeBUsers = Int32.Parse(typeBtextBox.Text);

            for (int i = 0; i < numberofTypeAUsers; i++)
            {
                ThreadTypeA.Add(new Thread(new ThreadStart(TypeAUsersThread)));
            }
            for (int i = 0; i < numberofTypeBUsers; i++)
            {
                ThreadTypeB.Add(new Thread(new ThreadStart(TypeBUsersThread)));
            }
            foreach (var thread in ThreadTypeA)
            {
                thread.Start();
            }
            foreach (var thread in ThreadTypeB)
            {
                thread.Start();
            }

            foreach (var thread in ThreadTypeA)
            {
                thread.Join();
            }
            foreach (var thread in ThreadTypeB)
            {
                thread.Join();
            }


        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {

        }

        private void AvgTimeTypeAlabel_Click(object sender, EventArgs e)
        {

        }

    }
}

