using G04_DBI_Trainings_Adventure.components;
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
using System.Windows.Shapes;


namespace G04_DBI_Trainings_Adventure
{
    /// <summary>
    /// Interaction logic for WorkoutEdit.xaml
    /// </summary>
    public partial class WorkoutEdit : Window
    {
        public string OldDate { get; set; }


        public static class EventAggregator
        {
            public static event Action DataUpdated;

            public static void RaiseDataUpdated()
            {
                DataUpdated?.Invoke();
            }
        }


        public WorkoutEdit(string oldDate)
        {
            this.OldDate = oldDate;
            InitializeComponent();
        }






        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTransport DB = new DataTransport("Data Source=assets/TrainingsDoku.db");
                DB.UpdateTrainingDay(ExerciseStack, OldDate, DateCombo.SelectedItem.ToString());

                EventAggregator.RaiseDataUpdated();

                DialogResult = true;

            }
            catch
            {
                MessageBox.Show($"Die Dauer muss eine Zahl sein und kleiner als {int.MaxValue}s sein.");
            }
        }


    }

}
