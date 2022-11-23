// Import Correct Packages
using System;
using System.IO; // contains Directory
using System.Collections.Generic; // contains Dictionary & List methods

namespace CatWorx.BadgeMaker
{
    class Util
    {
        // Method delcared as "static"
        // Any method that does not return a value must be defined to return void
        public static void PrintEmployees(List<Employee> employees) // List of <Employee> instances instead of list of <strings>
        {
            for (int i = 0; i < employees.Count; i++)
            {
                // each iteration in employees is now an Employee instance
                string template = "{0,-10}\t{1,-20}\t{2}";

                // new code
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }
        public static void MakeCSV(List<Employee> employees) // Create a CSV file and pass a list of employees
        {
            // Check to see if folder exists
            if (!Directory.Exists("data")) // if no directory exists called "data", then...
            {
                // ...create it
                Directory.CreateDirectory("data");
            }

            // dispose of StreamWriter and let .NET do that for us with the "using" statement; so we don't waste memory on potentially heavy resources that are no longer being used.
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID,Name,PhotoUrl");
                
                // loop over employees
                for (int i = 0; i < employees.Count; i++)
                {
                    // write each employee to the file
                    string template = "{0},{1},{2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }
    }
}