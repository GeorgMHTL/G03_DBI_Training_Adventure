﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace G04_DBI_Trainings_Adventure
{
    public class AddData
    {
        public string Date { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public int Exercise { get; set; }

        public AddData()
        {
            Date = "";
            Duration = 0;
            Difficulty = 0;
            Exercise = 0;
        }

        public AddData(string date, int duration, int diff, int exercise)
        {
            Date = date;
            Duration = duration;
            Difficulty = diff;
            Exercise = exercise;
        }

        public void AddExercise(string name, string description)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Uebungen (Name, Muskelgruppen) VALUES ('{name}', '{description}');";
                command.ExecuteNonQuery();
            }
        }   

        public void UpdateCBExercise(ComboBox cb)
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

        public void UpdateCBDate(ComboBox cb)
        {
            DateTime today = DateTime.Today;
            cb.SelectedItem = today.ToString("yyyy-MM-dd");
            
            for (int i = 5; i >= 0; i--)
            {
                cb.Items.Add(today.AddDays(-i).ToString("yyyy-MM-dd"));
            }

            for (int i = 1; i <= 5; i++)
            {
                cb.Items.Add(today.AddDays(i).ToString("yyyy-MM-dd"));
            }
        }

        public void AddDayToTrainingstage()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Trainingstage (Datum) VALUES ('{Date}');";
                command.ExecuteNonQuery();
            }
        }

        public void AddExerciseToTraining()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Training(fkTag, fkUebung, Dauer, Schwierigkeit) VALUES ((SELECT ID From Trainingstage WHERE Datum = '{Date}'), {Exercise+1}, {Duration}, {Difficulty});";
                command.ExecuteNonQuery();
            }
        }
    }
}
