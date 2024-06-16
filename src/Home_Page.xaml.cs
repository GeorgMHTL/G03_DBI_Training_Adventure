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
            UpdateVisibleItems();
        }

        public void UpdatePage()
        {
            DataTransport dataTransport = new DataTransport("Data Source=assets/TrainingsDoku.db");
            dataTransport.LoadWorkouts(Days);
            UpdateVisibleItems();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_startIndex - _itemsPerPage < 0)
            {
                _startIndex = Days.Children.Count - (_itemsPerPage - (_startIndex % _itemsPerPage));
            }
            else
            {
                _startIndex -= _itemsPerPage;
            }

            UpdateVisibleItems();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            int nextStartIndex = _startIndex + _itemsPerPage;

            if (nextStartIndex >= Days.Children.Count)
            {
                _startIndex = 0;
            }
            else
            {
                _startIndex = nextStartIndex;
            }

            UpdateVisibleItems();
        }

        private void UpdateVisibleItems()
        {
            for (int i = 0; i < Days.Children.Count; i++)
            {
                var child = Days.Children[i] as UIElement;
                if (child != null)
                {
                    child.Visibility = (i >= _startIndex && i < _startIndex + _itemsPerPage) ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }
    }
}
