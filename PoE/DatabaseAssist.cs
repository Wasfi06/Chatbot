using CyberChatbotGUI;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ChatbotGUI
{
    public class DatabaseAssist
    {
        private string connectionString =
            "server=localhost;database=CSAI_DB;uid=root;pwd=;";

        public void AddTask(TaskItem task)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    "INSERT INTO Tasks (Title, Description, Reminder, Completed) " +
                    "VALUES (@title, @description, @reminder, @completed)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", task.Title);
                cmd.Parameters.AddWithValue("@description", task.Description);
                cmd.Parameters.AddWithValue("@reminder", task.Reminder);
                cmd.Parameters.AddWithValue("@completed", task.Completed);

                cmd.ExecuteNonQuery();
            }
        }

        public List<TaskItem> GetTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Tasks";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TaskItem task = new TaskItem();

                    task.Id = reader.GetInt32("Id");
                    task.Title = reader.GetString("Title");
                    task.Description = reader.GetString("Description");
                    task.Reminder = reader.GetString("Reminder");
                    task.Completed = reader.GetBoolean("Completed");

                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public void MarkTaskComplete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    "UPDATE Tasks SET Completed = 1 WHERE Id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    "DELETE FROM Tasks WHERE Id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
