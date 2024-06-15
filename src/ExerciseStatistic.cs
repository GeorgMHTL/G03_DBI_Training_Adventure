using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace G04_DBI_Trainings_Adventure
{
    public class ExerciseStatistic
    {
        private Dictionary<string, int> statsData = new Dictionary<string, int>();

        public ExerciseStatistic()
        {
            GetStats();
        }

        public void GetStats()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=assets/TrainingsDoku.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();

                command.CommandText = "SELECT Name, COUNT(*) FROM TrainingDetails GROUP BY Name;";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        statsData.Add(reader.GetString(0), reader.GetInt32(1));
                    }
                }
                command.ExecuteNonQuery();
            }
        }

        public void VisualizeStats(Canvas canvas)
        {
            canvas.Children.Clear();
            var columnSeries = new ColumnSeries()
            {
                Title = "Gemachte Übungen",
                Values = statsData.Values.AsChartValues()
            };
            var chart = new CartesianChart()
            {
                Series = new SeriesCollection { columnSeries },
                AxisX = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Übungen",
                        Labels = statsData.Keys.ToList()
                    }
                },
                AxisY = new AxesCollection
                {
                    new Axis
                    {
                        Title = "Anzahl"
                    }
                },
                Width = canvas.ActualWidth,
                Height = canvas.ActualHeight
            };
            canvas.Children.Add(chart);
        }
    }
}
