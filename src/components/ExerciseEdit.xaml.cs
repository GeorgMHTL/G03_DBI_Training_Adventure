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
    /// Interaction logic for ExerciseEdit.xaml
    /// </summary>
    public partial class ExerciseEdit : UserControl
    {
        private DataTransport dataTransport = new DataTransport("Data Source=assets/TrainingsDoku.db");
        private string[] difficulty = { "1", "2", "3", "4", "5" };
        public int ID { get; private set; }
        public ExerciseEdit(List<string> Data)
        {

            InitializeComponent();
            LoadDefaultData(Data);

            this.ID = Convert.ToInt32(Data[5]);

        }

        private void LoadDefaultData(List<string> Data)
        {
            string[] exercise = dataTransport.GetExercises();
            ExersiceCombo.ItemsSource = exercise;
            ExersiceCombo.SelectedIndex = Array.IndexOf(exercise, Data[3]);
            DifficultyCombo.SelectedIndex = Array.IndexOf(difficulty, Data[2]);
            TimeSpan.Text = Data[1];


            
        }
    }
}
