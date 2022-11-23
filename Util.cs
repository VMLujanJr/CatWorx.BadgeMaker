// Import Correct Packages
using System;
using System.IO; // contains Directory
using System.Collections.Generic; // contains Dictionary & List methods
// using System.Net.Http.HttpClient // long method
using System.Net.Http; // short method
using System.Threading.Tasks; // contains the Task object
using SkiaSharp;

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
        async public static Task MakeBadges(List<Employee> employees)
        {
            // layout variables
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            // insert employee photo using these coordinates
            int PHOTO_LEFT_X = 184;
            int PHOTO_TOP_Y = 215;
            int PHOTO_RIGHT_X = 486;
            int PHOTO_BOTTOM_Y = 517;

            // company name
            int COMPANY_NAME_Y = 150;

            // employee name
            int EMPLOYEE_NAME_Y = 600;

            // employee id
            int EMPLOYEE_ID_Y = 730;

            // instance of HttpClient is disposed after code in the block has run
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    // keeps portrait
                    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
                    // keeps badge
                    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

                    // check to see if anything was done
                    // SKData data = photo.Encode(); // to check if anything was done

                    // SKData data = background.Encode();
                    // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));

                    // create skbitmap
                    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
                    // create skcavas
                    SKCanvas canvas = new SKCanvas(badge);

                    SKPaint paint = new SKPaint();
                    paint.TextSize = 42.0f;
                    paint.IsAntialias = true;
                    paint.Color = SKColors.White;
                    paint.IsStroke = false;
                    paint.TextAlign = SKTextAlign.Center;
                    paint.Typeface = SKTypeface.FromFamilyName("Arial");

                    canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT)); // SKRect allows us to allocate a position and size on the badge

                    canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));

                    // Company name
                    canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH / 2f, COMPANY_NAME_Y, paint);

                    // does this color overwrite the white color?
                    paint.Color = SKColors.Black;
                    // Employee name
                    canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);
                    
                    // does this font family overwrite the previous font family?
                    paint.Typeface = SKTypeface.FromFamilyName("Courier New");
                    // Employee ID
                    canvas.DrawText(employees[i].GetId().ToString(), BADGE_WIDTH / 2f, EMPLOYEE_ID_Y, paint);
                    // HERE

                    // display
                    SKImage finalImage = SKImage.FromBitmap(badge);
                    SKData data = finalImage.Encode();
                    string template = "data/{0}_badge.png";
                    data.SaveTo(File.OpenWrite(string.Format(template, employees[i].GetId())));
                }
            }
            // create image
            // SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));

            // SKData data = newImage.Encode();
            // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
        }
    }
}