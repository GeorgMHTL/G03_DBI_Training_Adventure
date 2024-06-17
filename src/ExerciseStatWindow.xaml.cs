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
    /// Interaktionslogik für ExerciseStatWindow.xaml
    /// </summary>
    public partial class ExerciseStatWindow : Window
    {
        ExerciseStatistic exerciseStatistic = new ExerciseStatistic();
        
        public ExerciseStatWindow()
        {
            InitializeComponent();
            
            exerciseStatistic.VisualizeStats(CanvasDraw);
        }

        private void CanvasDraw_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            exerciseStatistic.VisualizeStats(CanvasDraw);


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {

                WindowState = WindowState.Maximized;

            }
            else
            {

                WindowState = WindowState.Normal;
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {

            WindowState = WindowState.Minimized;
        }

        private void ControlBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

    }
}
