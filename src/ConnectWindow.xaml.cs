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
    /// Interaktionslogik für ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        public ConnectWindow()
        {
            InitializeComponent();
        }

        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            DialogResult = true;
            if (addWindow.ShowDialog() == true)
            {
                
            }
        }

        private void BtnExercise_Click(object sender, RoutedEventArgs e)
        {
            AddExerciseWindow addExerciseWindow = new AddExerciseWindow();
            DialogResult = true;
            if (addExerciseWindow.ShowDialog() == true)
            {
                
            }
        }
    }
}
