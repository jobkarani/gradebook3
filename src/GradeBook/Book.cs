using System.Collections.Generic;

namespace GradeBook{
    public class Book{

        public Book(string name){
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade){
            if (grade <= 10 && grade >=0 )
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Value");
            }
        }

        public Statistics GetStatistics(){

            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MinValue;
            result.High = double.MaxValue;

// foreach loop 

            // foreach(double grade in grades){

            //     // if (grade > highGrade){
            //     //     highGrade = grade;
            //     // }
            //     result.High = Math.Max(grade, result.High);
            //     result.Low = Math.Min(grade, result.Low);
            //     result.Average += grade;

            // }


// while loop 

            // var index = 0;

            //  do{
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.Average += grades[index];

            //     index += 1;

            // }while (index < grades.Count);

                
// for loop 

            for (var index = 0; index < grades.Count; index += 1; )
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                }

            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        public string Name;
    }
}

 