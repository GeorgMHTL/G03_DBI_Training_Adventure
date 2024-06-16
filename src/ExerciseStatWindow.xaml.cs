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
    }
}
