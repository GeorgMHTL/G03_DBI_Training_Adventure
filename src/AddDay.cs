using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace G04_DBI_Trainings_Adventure
{
    public class AddDay
    {
        public string Date { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public int Exercise { get; set; }

        public AddDay()
        {
            Date = "";
            Duration = 0;
            Difficulty = 0;
            Exercise = 0;
        }

        public AddDay(string date, int duration, int diff, int exercise)
        {
            Date = date;
            Duration = duration;
            Difficulty = diff;
            Exercise = exercise;
        }

        public void UpdateComboBox(ComboBox cb)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT Name FROM Uebungen;";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cb.Items.Add(reader.GetString(0));
                    }
                }
                command.ExecuteNonQuery();
            }
        }

        public void AddDayToTrainingstage()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Trainingstage (Datum, Dauer, Schwierigkeit) VALUES ('{Date}', {Duration}, {Difficulty});";
                command.ExecuteNonQuery();
            }
        }

        public void AddExerciseToTraining()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                // Funktion mit last_insert_rowid() um die ID des letzten Eintrags zu bekommen auch möglich, aber immer noch falsch
                command.CommandText = $"INSERT INTO Training(fkTag, fkUebung) VALUES ((SELECT ID From Trainingstage WHERE Datum = '{Date}'), {Exercise+1});";
                command.ExecuteNonQuery();
            }
        }
    }
}
