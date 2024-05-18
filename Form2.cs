using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace transaction
{
    public partial class Form2 : Form
    {
        private string _connectionString = "Server=kypc;Database=AdventureWorks2022;Trusted_Connection=True;TrustServerCertificate=true;";
        private IsolationLevel _isolationLevel;
        private int _deadlockCount = 0; // Global deadlock count

        public Form2()
        {
            InitializeComponent();
        }

        private void buttonStartSimulation_Click(object sender, EventArgs e)
        {
            _isolationLevel = (IsolationLevel)Enum.Parse(typeof(IsolationLevel), comboBoxIsolationLevel.SelectedItem.ToString());

            int typeAUsers = int.Parse(textBoxTypeAUsers.Text);
            int typeBUsers = int.Parse(textBoxTypeBUsers.Text);

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < typeAUsers; i++)
            {
                Thread thread = new Thread(() => TypeAUserThread());
                threads.Add(thread);
                thread.Start();
            }

            for (int i = 0; i < typeBUsers; i++)
            {
                Thread thread = new Thread(() => TypeBUserThread());
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        private void TypeAUserThread()
        {
            DateTime startTime = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction(_isolationLevel);

                    try
                    {
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteUpdateQuery(connection, transaction, "20110101", "20111231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteUpdateQuery(connection, transaction, "20120101", "20121231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteUpdateQuery(connection, transaction, "20130101", "20131231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteUpdateQuery(connection, transaction, "20140101", "20141231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteUpdateQuery(connection, transaction, "20150101", "20151231");
                        }

                        transaction.Commit();
                        connection.Close();

                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        Interlocked.Increment(ref _deadlockCount); // Increment global deadlock count
                        // Handle error
                    }
                }
            }


            TimeSpan elapsedTime = DateTime.Now - startTime;
            Console.WriteLine("Type A User Thread finished. Deadlocks: {0}, Elapsed Time: {1}", _deadlockCount, elapsedTime);
        }

        private void TypeBUserThread()
        {
            DateTime startTime = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction(_isolationLevel);

                    try
                    {
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteSelectQuery(connection, transaction, "20110101", "20111231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteSelectQuery(connection, transaction, "20120101", "20121231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteSelectQuery(connection, transaction, "20130101", "20131231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteSelectQuery(connection, transaction, "20140101", "20141231");
                        }
                        if (new Random().NextDouble() < 0.5)
                        {
                            ExecuteSelectQuery(connection, transaction, "20150101", "20151231");
                        }

                        transaction.Commit();
                        connection.Close();

                        
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        Interlocked.Increment(ref _deadlockCount); // Increment global deadlock count
                        // Handle error
                    }
                }
            }


            TimeSpan elapsedTime = DateTime.Now - startTime;
            Console.WriteLine("Type B User Thread finished. Deadlocks: {0}, Elapsed Time: {1}", _deadlockCount, elapsedTime);
        }

        private void ExecuteUpdateQuery(SqlConnection connection, SqlTransaction transaction, string beginDate, string endDate)
        {
            using (SqlCommand command = new SqlCommand("UPDATE Sales.SalesOrderDetail SET UnitPrice = UnitPrice * 10.0 / 10.0 WHERE UnitPrice > 100 AND EXISTS (SELECT * FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN @BeginDate AND @EndDate AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)", connection, transaction))
            {
                command.Parameters.AddWithValue("@BeginDate", beginDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 1205) // Deadlock
                    {
                        transaction.Rollback();
                        Interlocked.Increment(ref _deadlockCount); // Increment global deadlock count
                        ExecuteUpdateQuery(connection, transaction, beginDate, endDate);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private void ExecuteSelectQuery(SqlConnection connection, SqlTransaction transaction, string beginDate, string endDate)
        {
            using (SqlCommand command = new SqlCommand("SELECT SUM(Sales.SalesOrderDetail.OrderQty) FROM Sales.SalesOrderDetail WHERE UnitPrice > 100 AND EXISTS (SELECT * FROM Sales.SalesOrderHeader WHERE Sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID AND Sales.SalesOrderHeader.OrderDate BETWEEN @BeginDate AND @EndDate AND Sales.SalesOrderHeader.OnlineOrderFlag = 1)", connection, transaction))
            {
                command.Parameters.AddWithValue("@BeginDate", beginDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                try
                {
                    command.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 1205) // Deadlock
                    {
                        transaction.Rollback();
                        Interlocked.Increment(ref _deadlockCount); // Increment global deadlock count
                        ExecuteSelectQuery(connection, transaction, beginDate, endDate);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}