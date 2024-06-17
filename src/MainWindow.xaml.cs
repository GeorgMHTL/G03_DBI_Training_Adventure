using G04_DBI_Trainings_Adventure.components;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static G04_DBI_Trainings_Adventure.WorkoutEdit;

namespace G04_DBI_Trainings_Adventure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Home_Page homePage = new Home_Page();
        private int colorIndex = 0;
        private readonly List<Brush> brushes = new List<Brush>
        {
            Brushes.Magenta,
            Brushes.Aquamarine,
            Brushes.Green,
            Brushes.Yellow
        };
        public MainWindow()
        {
            InitializeComponent();
            homePage.DisplayCurrentItems();


            ContentFrame.Content = homePage;

            EventAggregator.DataUpdated += UpdatePageEvent;
            Workout.EventAggregator.DataUpdatedDel += UpdatePageEvent;


        }

        private void UpdatePageEvent()
        {
           homePage.DisplayCurrentItems();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            
            if (addWindow.ShowDialog() == true)
            {

            }
            homePage.DisplayCurrentItems();
        }

        private void BtnStat_Click(object sender, RoutedEventArgs e)
        {
            ExerciseStatWindow exerciseStatWindow = new ExerciseStatWindow();

            if (exerciseStatWindow.ShowDialog() == true)
            {

            }
        }

        private void BtnAddExercise_Click(object sender, RoutedEventArgs e)
        {
            AddExerciseWindow addExerciseWindow = new AddExerciseWindow();
            
            if (addExerciseWindow.ShowDialog() == true)
            {

            }
        }

        private void ColorChange_Click(object sender, MouseButtonEventArgs e)
        {
            homePage.BackgroundGrid.Background = brushes[colorIndex];
      
            colorIndex = (colorIndex + 1) % brushes.Count;
            ColorPicker.Fill = brushes[colorIndex];

        }
    }
}