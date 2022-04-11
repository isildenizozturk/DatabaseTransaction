# Database Transaction

A database transaction, in order to maintain consistency in a database must satisfy and follow the ACID
properties. Sometimes,we want to allow concurrent users to run their transactions independently
without interrupting the other transactions that are concurrently processing.A transaction acquires a
lock prior to data access; the lock is released when the transaction is completed, records are committed
or rollback so that another transaction can lock the data item for its own use. 


## Database
  
Used 2012 version of AdventureWorks full database and downloaded from  GitHub page of Microsoft (https://github.com/microsoft/sql-server-samples/releases).

## Introduction
Once I restored the database from the backup I did some simulations on the database and measured the time it takes to complete the transactions of users against the database.

There are 2 types of users with 2 different transactions, Type A and Type B. Type A users update the database tables with exactly the same update queries inside exactly the same transaction structure. Type B users read the database records with exactly the same select queries inside exactly the same transaction structure. 

I developed a simulation application. In this simulation, I was able to determine the number of users of Type A and Type B independent of each other. For example, there will be 5 Type-A users and 8 Type B users connected to the database concurrently, there will be 5+8 = 13 concurrent threads running their respective transactions 100 times in their own loops. 
While executing the transactions, the program measures the time it takes to complete 100 runs of each transaction by each thread. 
One other parameter of the simulation is the Transaction Isolation Level. I did exactly the same simulations for each different isolation level from READ UNCOMMITTED to SERIALIZABLE and then made a comparison.
