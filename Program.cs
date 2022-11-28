// Import Correct Packages
using System;
using System.Collections.Generic; // contains Dictionary and List methods
using System.Threading.Tasks; // contains the Task object

namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args) // Entry Point
        {
            List<Employee> employees = await PeopleFetcher.GetFromApi(); // returns either api or manual peoplefetcher
            Util.PrintEmployees(employees); // THIS METHOD PRINTS A LIST OF EMPLOYEES
            Util.MakeCSV(employees); // THIS METHOD CREATES AN EXCEL SHEET WITH EMPLOYEE NAMES, ETC.
            await Util.MakeBadges(employees); // THIS METHOD CREATES BADGES
        }
    }
}

// Console.WriteLine("Hello, World!");
// C# - a statistically typed language
// string carModel = "Intrepid";
// int carPrice = 500;
// string greeting = "Hello";
// greeting = greeting + "World";
// testing for myself
// string works = "This is how it works";
// Console.WriteLine("greeting" + greeting);
// String Interpolation
// Console.WriteLine($"greeting#2: {greeting}");
// Console.WriteLine("greeting#3: {0}", greeting, works);
// Console.WriteLine("greeting#4: {1}", greeting, works);

// How do you find the area of a square? Area = side * side
// float side = 3.14F;
// float area = side * side;
// Console.WriteLine($"My area is {area}, {area.GetType()}.");

// double side2 = 3.14;
// double area2 = side2 * side2;
// Console.WriteLine("My 2nd area is {0}, {1}.", area2, area2.GetType());

// Math operators
// Console.WriteLine(2 * 3); // basic arithmetic: +, -, /, *
// Console.WriteLine(10 % 3); // modulus op => remainder of 10/3
// Console.WriteLine(1 + 2 * 3); // order of operations
// Console.WriteLine(10 / 3.0); // int's and doubles
// Console.WriteLine(10 / 3); // int's
// Console.WriteLine("12" + "3"); // What happens here?
// int num = 10;
// num += 100;
// Console.WriteLine(num);
// num++;
// Console.WriteLine(num);

// bool isCold = true;
// Console.WriteLine(isCold ? "drink" : "add ice"); // output: drink
// Console.WriteLine(!isCold ? "drink" : "add ice"); // output: add ice

// string stringNum = "2";
// int intNum = Convert.ToInt32(stringNum);
// Console.WriteLine(intNum);
// Console.WriteLine(intNum.GetType());

// dictionary - key value pairs

// Dictionary<string, int> myScoreBoard = new Dictionary<string, int>(); // variable myScoreBoard has a string KEY and an integer VALUE
// to populate dictionary
// myScoreBoard.Add("firstInning", 10);
// myScoreBoard.Add("secondInning", 20);
// myScoreBoard.Add("thirdInning", 30);
// myScoreBoard.Add("fourthInning", 40);
// myScoreBoard.Add("fifthInning", 50);

// alternatively,
// Dictionary<string, int> mySecondScoreBoard = new Dictionary<string, int>(){
//     { "firstInning", 10 },
//     { "secondInning", 20 },
//     { "thirdInning", 30 },
//     { "fourthInning", 40 },
//     { "fifthInning", 50 }
// };

// Console.WriteLine("----------------");
// Console.WriteLine("Scoreboard");
// Console.WriteLine("----------------");
// Console.WriteLine("Inning | Score");
// Console.WriteLine(" 1 | {0}", myScoreBoard["firstInning"]);
// Console.WriteLine(" 2 | {0}", myScoreBoard["secondInning"]);
// Console.WriteLine(" 3 | {0}", myScoreBoard["thirdInning"]);
// Console.WriteLine(" 4 | {0}", myScoreBoard["fourthInning"]);
// Console.WriteLine(" 5 | {0}", myScoreBoard["fifthInning"]);

// Console.WriteLine("----------------");
// Console.WriteLine("2nd Scoreboard");
// Console.WriteLine("----------------");
// Console.WriteLine("Inning | Score");
// Console.WriteLine(" 1 | {0}", mySecondScoreBoard["firstInning"]);
// Console.WriteLine(" 2 | {0}", mySecondScoreBoard["secondInning"]);
// Console.WriteLine(" 3 | {0}", mySecondScoreBoard["thirdInning"]);
// Console.WriteLine(" 4 | {0}", mySecondScoreBoard["fourthInning"]);
// Console.WriteLine(" 5 | {0}", mySecondScoreBoard["fifthInning"]);

// arrays
// string[] favFoods = new string[3] { "pizza", "doughnuts", "icecream" };
// string firstFood = favFoods[0];
// string secondFood = favFoods[1];
// string thirdFood = favFoods[2];
// Console.WriteLine("I like {0}, {1}, and {2}.", firstFood, secondFood, thirdFood);

// lists
// List<string> employees = new List<string>() { "adam", "amy" };
// employees.Add("barbara");
// employees.Add("billy");

// Console.WriteLine("My employees include {0}, {1}, {2}, and {3}.", employees[0], employees[1], employees[2], employees[3]);

// // loops
// for (int i = 0; i < employees.Count; i++)
// {
//     Console.WriteLine("My new iteration method using loops!{0}", employees[i]);
// }

// New Store Employee Data
// List<string> employeeList = new List<string>();
// Collect user values until the value is an empty string
// while (true)
// {
//     // Store Employee Data
//     Console.WriteLine("Please enter a name: ");
//     // get name from the console and assign it to a variable
//     string input = Console.ReadLine() ?? "";
//     // break if the user hits ENTER without typing a name
//     if (input == "")
//     {
//         break;
//     }
//     employees.Add(input);
// }

// for (int i = 0; i < employees.Count; i++)
// {
//     Console.WriteLine(employees[i]);
// }

// assuming everything above is deleted; we will condense the code to ONLY THIS
// This is our employee-getting code now