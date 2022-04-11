namespace AdvancedDatabaseTermProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.isolationLvlComboBox = new System.Windows.Forms.ComboBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.isolationLvlLabel = new System.Windows.Forms.Label();
            this.typeAlabel = new System.Windows.Forms.Label();
            this.typeAtextBox = new System.Windows.Forms.TextBox();
            this.typeBlabel = new System.Windows.Forms.Label();
            this.typeBtextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // isolationLvlComboBox
            // 
            this.isolationLvlComboBox.DropDownHeight = 115;
            this.isolationLvlComboBox.FormattingEnabled = true;
            this.isolationLvlComboBox.IntegralHeight = false;
            this.isolationLvlComboBox.Location = new System.Drawing.Point(324, 91);
            this.isolationLvlComboBox.Name = "isolationLvlComboBox";
            this.isolationLvlComboBox.Size = new System.Drawing.Size(170, 24);
            this.isolationLvlComboBox.TabIndex = 0;
            this.isolationLvlComboBox.SelectedIndexChanged += new System.EventHandler(this.isolationLvlDropBox_SelectedIndexChanged);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.StartButton.Location = new System.Drawing.Point(585, 174);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(148, 52);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // isolationLvlLabel
            // 
            this.isolationLvlLabel.AutoSize = true;
            this.isolationLvlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isolationLvlLabel.Location = new System.Drawing.Point(104, 91);
            this.isolationLvlLabel.Name = "isolationLvlLabel";
            this.isolationLvlLabel.Size = new System.Drawing.Size(142, 25);
            this.isolationLvlLabel.TabIndex = 2;
            this.isolationLvlLabel.Text = "Isolation Level:";
            this.isolationLvlLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // typeAlabel
            // 
            this.typeAlabel.AutoSize = true;
            this.typeAlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.typeAlabel.Location = new System.Drawing.Point(53, 174);
            this.typeAlabel.Name = "typeAlabel";
            this.typeAlabel.Size = new System.Drawing.Size(233, 25);
            this.typeAlabel.TabIndex = 3;
            this.typeAlabel.Text = "Number of Type A Users:";
            // 
            // typeAtextBox
            // 
            this.typeAtextBox.Location = new System.Drawing.Point(324, 174);
            this.typeAtextBox.Name = "typeAtextBox";
            this.typeAtextBox.Size = new System.Drawing.Size(170, 22);
            this.typeAtextBox.TabIndex = 4;
            this.typeAtextBox.TextChanged += new System.EventHandler(this.typeAtextBox_TextChanged);
            // 
            // typeBlabel
            // 
            this.typeBlabel.AutoSize = true;
            this.typeBlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.typeBlabel.Location = new System.Drawing.Point(54, 260);
            this.typeBlabel.Name = "typeBlabel";
            this.typeBlabel.Size = new System.Drawing.Size(232, 25);
            this.typeBlabel.TabIndex = 5;
            this.typeBlabel.Text = "Number of Type B Users:";
            // 
            // typeBtextBox
            // 
            this.typeBtextBox.Location = new System.Drawing.Point(324, 264);
            this.typeBtextBox.Name = "typeBtextBox";
            this.typeBtextBox.Size = new System.Drawing.Size(170, 22);
            this.typeBtextBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.typeBtextBox);
            this.Controls.Add(this.typeBlabel);
            this.Controls.Add(this.typeAtextBox);
            this.Controls.Add(this.typeAlabel);
            this.Controls.Add(this.isolationLvlLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.isolationLvlComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox isolationLvlComboBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label isolationLvlLabel;
        private System.Windows.Forms.Label typeAlabel;
        private System.Windows.Forms.TextBox typeAtextBox;
        private System.Windows.Forms.Label typeBlabel;
        private System.Windows.Forms.TextBox typeBtextBox;
    }
}

