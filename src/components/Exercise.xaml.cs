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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G04_DBI_Trainings_Adventure.components
{
    /// <summary>
    /// Interaction logic for Exercise.xaml
    /// </summary>
    public partial class Exercise : UserControl
    {
     
        public int Duration { get; set; }
        public int SkillLevel { get; set; }
        public string Name { get; set; }
        public string TargetMuscles { get; set; }




        public Exercise()
        {
            InitializeComponent();


        }
    }
}
