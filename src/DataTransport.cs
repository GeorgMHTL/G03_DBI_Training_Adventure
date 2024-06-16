using G04_DBI_Trainings_Adventure.components;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace G04_DBI_Trainings_Adventure
{
   
public class DataTransport
    {
        private string srcString;

        public DataTransport(string srcString)
        {
            this.srcString = srcString;
        }

        public string[] GetExercises()
        {
            List<string> exercises = new List<string>();
            using (SqliteConnection connection = new SqliteConnection(srcString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT Name FROM Uebungen;";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        exercises.Add(reader.GetString(0));
                    }
                }
            }
            return exercises.ToArray();
        }

        public void LoadWorkouts(StackPanel HomeStack)
        {
            HomeStack.Children.Clear();
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


                        HomeStack.Children.Add(work);
          
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


                        var Name = new TextBlock();
                        var Skill = new TextBlock();
                        var Duration = new TextBlock();

                  
                        Name.Foreground = new SolidColorBrush(Color.FromRgb(0xBB, 0xE1, 0xFA));
                        Skill.Foreground = new SolidColorBrush(Color.FromRgb(0xBB, 0xE1, 0xFA));
                        Duration.Foreground = new SolidColorBrush(Color.FromRgb(0xBB, 0xE1, 0xFA));

                        Name.FontFamily = new FontFamily("Inter");
                        Name.FontWeight = FontWeights.Bold;
                        Name.FontSize = 24;

                        Skill.FontFamily = new FontFamily("Inter");
                        Skill.FontWeight = FontWeights.Bold;
                        Skill.FontSize = 24;


                        Duration.FontFamily = new FontFamily("Inter");
                        Duration.FontWeight = FontWeights.Bold;
                        Duration.FontSize = 24;



                        Skill.Text = "";
                        for (int i = 0; i < reader.GetInt32(2); i++)
                        {
                            Skill.Text += "*";
                        }

                        Name.Text = reader.GetString(3);
                        Duration.Text = reader.GetString(1);

                        exercise.ExerciseGrid.Children.Add(Name);
                        exercise.ExerciseGrid.Children.Add(Skill);
                        exercise.ExerciseGrid.Children.Add(Duration);

                        Grid.SetRow(Name, 1);
                        Grid.SetColumn(Name, 0);


                        Grid.SetRow(Skill, 1);
                        Grid.SetColumn(Skill, 1);
                        

                        Grid.SetRow(Duration, 1);
                        Grid.SetColumn(Duration, 2);
                    




                        ExcersiseStack.Children.Add(exercise);


                    }
                }

            }

        }


        public void LoadDataToEdit(string Datum, WorkoutEdit workout)
        {

            using (SqliteConnection connection = new SqliteConnection(srcString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = $"SELECT * FROM TrainingDetails WHERE Datum = '{Datum}';";


                using (SqliteDataReader reader = command.ExecuteReader())
                {

                    workout.ExerciseStack.Children.Clear();
                    while (reader.Read())
                    {

                        List<string> Data = new List<string>();

                        Data.Add(reader.GetString(0));
                        Data.Add(reader.GetString(1));
                        Data.Add(reader.GetString(2));
                        Data.Add(reader.GetString(3));
                        Data.Add(reader.GetString(5));



                        ExerciseEdit exerciseToEdit = new ExerciseEdit(Data);


                        workout.ExerciseStack.Children.Add(exerciseToEdit);

                    }


                }

            }
        }


        public void UpdateTrainingDay(StackPanel exer, string oldDate, string newDate)
        {

            using (SqliteConnection connection = new SqliteConnection(srcString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = @$"UPDATE Trainingstage
                                         SET Datum = '{newDate}' WHERE Datum = '{oldDate}';";

                command.ExecuteNonQuery();

                command.CommandText = $"SELECT ID FROM Trainingstage WHERE Datum = '{newDate}';";
                int newID = 0;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        newID = reader.GetInt32(0);
                    }
                }


                foreach (ExerciseEdit ex in exer.Children)
                {

                    command.CommandText = @$"UPDATE Training
                                        SET
                                        fkUebung = '{ex.ExersiceCombo.SelectedIndex + 1}',
                                        Dauer = '{int.Parse(ex.TimeSpan.Text)}',
                                        Schwierigkeit = {ex.DifficultyCombo.SelectedIndex + 1}
                                        WHERE  ID = {ex.ID}";

                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
