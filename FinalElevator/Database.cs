using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;//provides classes for working with SQL Server 
using System.Linq;//not use in this class explicity
using System.Text;
using System.Threading.Tasks;

namespace FinalElevator//to encapsulate databse class
{
    internal class Database
    {
        string connectionString = @"Server = SUZU;Database = testing; Trusted_Connection = True;";//establish database connection //linking system with database

        public void InsertLogsIntoDB(DataTable dt)//accepts a datatable as input
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))//creates and manages sqlconn to database
                {
        
                    string query = @"Insert into Logs (LogTime, EventDescription) values (@Time, @Log)";// query of insert data

                    using (SqlDataAdapter adapter = new SqlDataAdapter())// create instance to manage data operators
                    {
                        adapter.InsertCommand = new SqlCommand(query, conn);// assign sql command  
                        adapter.InsertCommand.Parameters.Add("@Time", SqlDbType.DateTime, 0, "LogTime");// logtime as date time
                        adapter.InsertCommand.Parameters.Add("@Log", SqlDbType.NVarChar, 255, "EventDescription");// event description as varchar to record 

                        conn.Open();// opens the database

                        adapter.Update(dt);//updating datatable using data in the datatable
                    }
                }
            }
            catch (Exception ex)//cataches any exception occuring
            {
                MessageBox.Show("Error saving logs to DB: " + ex.Message);//message will display
            }
        }
        public void ClearLogsFromDB()//method to create logs from the databse
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))//create new SQL connection
                {
                    conn.Open();//conection start
                    string query = "DELETE FROM Logs";//data deleting query
                    using (SqlCommand cmd = new SqlCommand(query, conn))//create sql command to execute the query
                    {
                        cmd.ExecuteNonQuery();//execute dete query
                    }
                }
            }
            catch (Exception ex)//exception handling for log clearance
            {
                MessageBox.Show("Error clearing logs: " + ex.Message);
            }
        }

        public void loadLogsFromDB(DataTable dt, DataGridView dataGridViewLogs)//method for logs loading
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))//create new sql conn
                {
                    string query = @"Select LogTime, EventDescription from Logs order by LogTime desc";//selection of all data and loadin it in sql to retrive

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        dt.Rows.Clear();//clears existing row

                        adapter.Fill(dt);//fills the databale with data retrived from the database

                        dataGridViewLogs.Rows.Clear();//clears existing rows in the gridview

                        foreach (DataRow row in dt.Rows)
                        {
                            string currentTime = Convert.ToDateTime(row["LogTime"]).ToString("hh:mm:ss");// converting date time into string
                            string events = row["EventDescription"].ToString();//getting as string

                            dataGridViewLogs.Rows.Add(currentTime, events);//add data to the grid view
                        }
                    }
                }
            }
            catch (Exception ex)//exception handling for data loading
            {
                MessageBox.Show("Error loading logs from DB: " + ex.Message);
            }

        }
    }
}

