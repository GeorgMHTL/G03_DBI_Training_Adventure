using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G04_DBI_Trainings_Adventure.components
{
    /// <summary>
    /// Interaction logic for Workout.xaml
    /// </summary>
    public partial class Workout : UserControl
    {
        private string ContentDate;
        private RemoveDay removeDay = new RemoveDay();

        public static class EventAggregator
        {
            public static event Action DataUpdatedDel;

            public static void RaiseDataUpdated()
            {
                DataUpdatedDel?.Invoke();
            }


        }

        public Workout(string date)
        {
            ContentDate = date;
            InitializeComponent();
            Date.Text = ContentDate;
        }



        public void LoadDates(WorkoutEdit workout)
        {
            DateTime currentDate = DateTime.Parse(Date.Text);
            DateTime startDate = currentDate.AddDays(-6);
            DateTime endDate = currentDate.AddDays(6);

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                string formattedDate = date.ToString("yyyy-MM-dd");
                workout.DateCombo.Items.Add(formattedDate);
            }

            workout.DateCombo.SelectedIndex = 6;
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            removeDay.Date = ContentDate;
            removeDay.RemoveDayFromTraining();
            removeDay.RemoveDayFromTrainingstage();

            EventAggregator.RaiseDataUpdated();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                WorkoutEdit workoutEdit = new WorkoutEdit(ContentDate);

                DataTransport dataTransport = new DataTransport("Data Source=assets/TrainingsDoku.db");

                dataTransport.LoadDataToEdit(ContentDate, workoutEdit);
                LoadDates(workoutEdit);

                if (workoutEdit.ShowDialog() == true)
                {
          
                    
                }
     
        }



    }


}
