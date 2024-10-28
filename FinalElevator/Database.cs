using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalElevator
{
    internal class Database
    {
        string connectionString = @"Server = SUZU;Database = testing; Trusted_Connection = True;";

        public void InsertLogsIntoDB(DataTable dt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
        
                    string query = @"Insert into Logs (LogTime, EventDescription) values (@Time, @Log)";

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.InsertCommand = new SqlCommand(query, conn);
                        adapter.InsertCommand.Parameters.Add("@Time", SqlDbType.DateTime, 0, "LogTime");
                        adapter.InsertCommand.Parameters.Add("@Log", SqlDbType.NVarChar, 255, "EventDescription");

                        conn.Open();

                        adapter.Update(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving logs to DB: " + ex.Message);
            }
        }
        public void ClearLogsFromDB()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Logs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing logs: " + ex.Message);
            }
        }

        public void loadLogsFromDB(DataTable dt, DataGridView dataGridViewLogs)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"Select LogTime, EventDescription from Logs order by LogTime desc";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        dt.Rows.Clear();

                        adapter.Fill(dt);

                        dataGridViewLogs.Rows.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            string currentTime = Convert.ToDateTime(row["LogTime"]).ToString("hh:mm:ss");
                            string events = row["EventDescription"].ToString();

                            dataGridViewLogs.Rows.Add(currentTime, events);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logs from DB: " + ex.Message);
            }

        }
    }
}

