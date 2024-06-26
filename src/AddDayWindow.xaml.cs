﻿using System;
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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddData newDay = new AddData();
        public AddWindow()
        {
            InitializeComponent();

            newDay.UpdateCBDate(CBDate);
            newDay.UpdateCBExercise(CBExercise);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CBDate.SelectedItem != null && TBDuration.Text != "" && CBDiff.SelectedItem != null && CBExercise.SelectedItem != null)
            {
                if (!int.TryParse(TBDuration.Text, out int duration) || duration > int.MaxValue)
                {
                    MessageBox.Show($"Dauer muss eine Zahl sein und kleiner als {int.MaxValue}.");
                }
                else
                {
                    newDay.Date = CBDate.SelectedItem.ToString(); newDay.Duration = int.Parse(TBDuration.Text); newDay.Difficulty = CBDiff.SelectedIndex+1; newDay.Exercise = CBExercise.SelectedIndex;
                    newDay.AddDayToTrainingstage();
                    newDay.AddExerciseToTraining();
                    DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus.");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
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
