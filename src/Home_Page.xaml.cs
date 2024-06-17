using G04_DBI_Trainings_Adventure.components;
using System.Windows;
using System.Windows.Controls;

namespace G04_DBI_Trainings_Adventure
{
    /// <summary>
    /// Interaction logic for Home_Page.xaml
    /// </summary>
    public partial class Home_Page : Page
    {
        private List<Workout> _userControls;
        private int _currentIndex = 0;
        private const int ItemsPerPage = 3;



        public Home_Page()
        {
            InitializeComponent();
            
            DisplayCurrentItems();

        }

        public void UpdatePage()
        {

            DataTransport dataTransport = new DataTransport("Data Source=assets/TrainingsDoku.db");
            _userControls  = dataTransport.LoadWorkouts();

        }


        public void DisplayCurrentItems()
        {
            UpdatePage();
            ContentDisplay.Items.Clear();
            try
            {
                for (int i = 0; i < ItemsPerPage; i++)
                {
                    int index = (_currentIndex + i) % _userControls.Count;
                    ContentDisplay.Items.Add(_userControls[index]);
                }
            }
            catch
            {
              
            }

        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentIndex = (_currentIndex - ItemsPerPage + _userControls.Count) % _userControls.Count;
                DisplayCurrentItems();
            }
            catch
            { }
      
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentIndex = (_currentIndex + ItemsPerPage) % _userControls.Count;
                DisplayCurrentItems();
            }
            catch 
            {
            }

        }
    }


}

