// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

namespace GradeBook{

   
    class Program{
        
        static void Main (string [] args){

            var book = new Book("Jobs Grade Book :) ");
            // book.AddGrade(90.0);
            // book.AddGrade(81.0);
            // book.AddGrade(79.0);

            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            while (true){
                
                Console.WriteLine("Enter a Grade or press 'q' to quit:");
                var input = Console.ReadLine();

                if (input == "q"){  /** we use double quotes to make "q" be read as a letter by the compiler **/
                    break;
                }

                try{
                    var grade = double.Parse(input); 
                    book.AddGrade(grade);
                }
                catch(FormatException ex){
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex){
                    Console.WriteLine(ex.Message);
                }
                finally{
                    Console.WriteLine("******");
                }
                
            }

            var stats = book.GetStatistics();

            // book.Name = "";    /**get and set properties for book name **/

            Console.WriteLine(Book.CATEGORY); /** since CATEGORY is a static member of the book class **/
            Console.WriteLine($"The book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The letter grade is {stats.letter}");

            static void OnGradeAdded(object sender, EventArgs e){
                Console.WriteLine("A grade was added :) ");
            }


// sum 
            // double x = 3.14;
            // double y = 4.35;

            // var x = 3.14;
            // var y = 4.35;

            // var z = x + y;

// Array 
            // var numbers = new double[3];
            // numbers[0] = 1.23;
            // numbers[1] = 2.23;
            // numbers[2] = 6.23;

// Array init 
        //    var numbers = new [] {1.23, 2.00, 6.23}; 
           

// List init 
            // var grades = new List<double>() {1.23, 2.00, 6.23};
            // grades.Add(6.9);


        //    var results = numbers[0];
        //    results += numbers[1];
        //    results += numbers[2];

        }
    }
}                                                                                          
