using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace G04_DBI_Trainings_Adventure
{
   
    public class DataTransport
    {
        private string srcString;
        
        public DataTransport(string srcString)
        {
            this.srcString = srcString;
        }

        public void LoadWorkouts(WrapPanel HomeWrap)
        {
            using (SqliteConnection connection = new SqliteConnection(srcString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();


                command.CommandText = @"";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                      




                    }
                }

            }



        }

        public void LoadExercises(string Datum, StackPanel ExcersiseStack)
        {
            
        }

    }
}
