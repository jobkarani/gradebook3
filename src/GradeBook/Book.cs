using System.Collections.Generic;

namespace GradeBook{
    public class Book{

        public Book(string name){

            const int X = 3;
            // category = ""; /** readonly field **/
            grades = new List<double>();
            Name = name;
        }

// else if statement 
        // public void AddLetterGrade(char letter){
        //     if (letter == 'A'){   NOTE: we are using single quotes since letter is of CHAR type. 
        //         AddGrade(90);
        //     }
        //     else if (letter == 'B'){
        //         AddGrade(80);
        //     }
        //     else if (letter == 'C'){
        //         AddGrade(70);
        //     }
        //     else if (letter == 'D'){
        //         AddGrade(60);
        //     }
        //     else if (letter == 'E'){
        //         AddGrade(50);
        //     }
        //     else (letter == 'F'){
        //         AddGrade(40);
        //     }
        // }

// switch statement 
        // public void AddLetterGrade(char letter){
        //     switch(letter){
        //         case 'A':
        //             AddGrade(90);
        //             break;
        //         case 'B':
        //             AddGrade(80);
        //             break;
        //         case 'C':
        //             AddGrade(70);
        //             break;
        //         default:
        //             AddGrade(0);
        //             break;
        //     }
        // }
        public void AddGrade(double grade){
            if (grade <= 100.0 && grade >=0.0 )
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof (grade)}");
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

            for (var index = 0; index < grades.Count; index += 1 )
            {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch (result.Average){

                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;
                
                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.letter = 'D';
                    break;

                case var d when d >= 50.0:
                    result.letter = 'E';
                    break;

                default:
                    result.letter = 'F';
                    break;
            }

            return result;
        }

        private List<double> grades;

// old method for get and set properties
        // public string Name{
        //     get{
        //         return name;
        //     }
        //     set{
        //         if (!string.IsNullOrEmpty(value)){
        //             name = value;
        //         }
        //     }
        // }

// modern ms way

    public string Name{
        get;
        set;
    }
        // private string name;

        // readonly string category = "Science";

        // const string category = "Science"; /**local scope**/

        public const string CATEGORY = "Science"; /** global scope**/

    }
}

 