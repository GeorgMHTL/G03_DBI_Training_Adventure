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
    /// Interaktionslogik für AddExerciseWindow.xaml
    /// </summary>
    public partial class AddExerciseWindow : Window
    {
        private AddData addData = new AddData();

        public AddExerciseWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TBExercise.Text == "" || TBDescription.Text == "")
            {
                MessageBox.Show("Bitte alle Felder ausfüllen.");
            }
            else
            {
                if (!double.TryParse(TBExercise.Text, out double result) && !double.TryParse(TBDescription.Text, out double num))
                {
                    addData.AddExercise(TBExercise.Text, TBDescription.Text);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Bitte keine Zahlen eingeben.");
                }
            }
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
