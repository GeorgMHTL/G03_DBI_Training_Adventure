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

        public WorkoutEdit()
        {
            InitializeComponent();
            //OldDate = DateCombo.SelectedItem
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Exercise exer in ExerciseStack.Children)
            {
                
            }


        }
    }
}
