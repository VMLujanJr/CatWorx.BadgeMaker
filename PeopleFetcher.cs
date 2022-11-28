using System;
using System.Collections.Generic; // Dictionary and List methods
using System.Threading.Tasks; // Task method
using System.Net.Http; // to download information from API endpoints and download images
using Newtonsoft.Json.Linq; // Json.NET, access to JObject

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        // code from GetEmployees() in Program.cs
        public static List<Employee> GetEmployees() // using custom type <Employee> instead of <string>; returns a list of Employee instances instead of a list of strings
        {
            // I will return a List of strings
            List<Employee> employees = new List<Employee>(); // using custom type <Employee> instead of <string>
            while (true)
            {
                // ask for FIRST NAME
                Console.WriteLine("Enter first name (leave empty to exit): ");
                string firstName = Console.ReadLine() ?? ""; // if I get null = ""
                if (firstName == "")
                {
                    break;
                }

                // ask for LAST NAME
                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine() ?? ""; // if I get null = ""

                // ask for ID
                Console.WriteLine("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? ""); // if I get null = ""

                // ask for ID
                Console.WriteLine("Enter Photo URL: ");
                string photoUrl = Console.ReadLine() ?? ""; // if I get null = ""

                // create new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }
            // This is important!
            return employees;
        }
        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            // calling API and discards
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                // Console.WriteLine(response); // print response to console
                JObject json = JObject.Parse(response);

                foreach (JToken token in json.SelectToken("results")!)
                {
                    // Parse JSON data
                    Employee emp = new Employee
                    (
                        token.SelectToken("name.first")!.ToString(),
                        token.SelectToken("name.last")!.ToString(),
                        Int32.Parse(token.SelectToken("id.value")!.ToString().Replace("-", "")),
                        token.SelectToken("picture.large")!.ToString()
                    );
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
}