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
        
        public MainWindow()
        {
            InitializeComponent();
            homePage.UpdatePage();


            ContentFrame.Content = homePage;

            EventAggregator.DataUpdated += UpdatePageEvent;
            Workout.EventAggregator.DataUpdatedDel += UpdatePageEvent;

        }

        private void UpdatePageEvent()
        {
           homePage.UpdatePage();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();

            if (addWindow.ShowDialog() == true)
            {
                homePage.UpdatePage();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = homePage;
            homePage.UpdatePage();

        }




    }
}