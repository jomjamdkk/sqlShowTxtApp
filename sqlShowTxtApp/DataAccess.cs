using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace sqlShowTxtApp
{
    internal class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                String customers = "CREATE TABLE IF NOT " +
                    "EXISTS myTable (uid INTEGER PRIMARY KEY," +
                    "textEntry NVARCHAR(128) NOT NULL);";

                SqliteCommand createTable = new SqliteCommand(customers, db);

                createTable.ExecuteReader();
            }
        }
        public static void AddData(int uid, string text_entry)
        {
            using (SqliteConnection db =
              new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO myTable VALUES (@Uid,@textEntry);";
                insertCommand.Parameters.AddWithValue("@textEntry", text_entry);
                insertCommand.Parameters.AddWithValue("@Uid", uid);


                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT textEntry from myTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }

            return entries;
        }
    }
}
