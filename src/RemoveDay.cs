using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G04_DBI_Trainings_Adventure
{
    public class RemoveDay
    {
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public RemoveDay()
        {
            Date = "";
        }

        public RemoveDay(string date)
        {
            Date = date;
        }

        public void RemoveDayFromTraining()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = $"DELETE FROM Training WHERE fkTag = (SELECT ID FROM Trainingstage WHERE Datum = '{Date}');";
                command.ExecuteNonQuery();
            }
        }

        public void RemoveDayFromTrainingstage()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = $"DELETE FROM Trainingstage WHERE Datum = '{Date}';";
                command.ExecuteNonQuery();
            }
        }
    }
}
