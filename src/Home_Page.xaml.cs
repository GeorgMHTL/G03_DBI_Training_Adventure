using System.Windows;
using System.Windows.Controls;

namespace G04_DBI_Trainings_Adventure
{
    /// <summary>
    /// Interaction logic for Home_Page.xaml
    /// </summary>
    public partial class Home_Page : Page
    {
        private int _startIndex = 0;
        private const int _itemsPerPage = 3;

        public Home_Page()
        {
            InitializeComponent();
            UpdatePage();

        }

        public void UpdatePage()
        {
            DataTransport dataTransport = new DataTransport("Data Source=assets/TrainingsDoku.db");
            dataTransport.LoadWorkouts(Days);

        }


    }
}
