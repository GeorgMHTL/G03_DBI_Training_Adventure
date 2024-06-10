using G04_DBI_Trainings_Adventure.components;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace G04_DBI_Trainings_Adventure
{
   
    public class DataTransport
    {
        private string srcString;
        
        public DataTransport(string srcString)
        {
            this.srcString = srcString;
        }

        public void LoadWorkouts(WrapPanel HomeWrap)
        {
            HomeWrap.Children.Clear();
            using (SqliteConnection connection = new SqliteConnection(srcString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();


                command.CommandText = @"SELECT Datum FROM TrainingDetails GROUP BY Datum;";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Workout work = new Workout(reader.GetString(0));

                        LoadExercises(reader.GetString(0), work.Training);



                        HomeWrap.Children.Add(work);

                    }
                }

                

            }



        }

        public void LoadExercises(string Datum, StackPanel ExcersiseStack)
        {
            using (SqliteConnection connection = new SqliteConnection(srcString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();


                command.CommandText = $"SELECT * FROM TrainingDetails WHERE Datum = '{Datum}';";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise();
                        exercise.Name = reader.GetString(3);
                        exercise.Training.Children.Add(new TextBlock() { Text = reader.GetString(3) });
                        

                        ExcersiseStack.Children.Add(exercise);
                    }
                }

            }

        }

    }
}
