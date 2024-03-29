using System.Collections.Generic;
using System.IO;

namespace GradeBook{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

// base class
    public class NamedObject{

        public NamedObject(string name){

            Name = name;

        }
        public string Name{
            get;
            set;
        }
    }

    public interface IBook{
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded; 
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name){

        }

        // public virtual event GradeAddedDelegate GradeAdded;

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);

        // public virtual Statistics GetStatistics(){
        //     throw new NotImplementedException();
        // }
        public abstract Statistics GetStatistics(); 

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name){

        }
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
           using(var writer = File.AppendText($"{Name}.txt")) 
           {
            writer.WriteLine(grade);
            if(GradeAdded != null){
                GradeAdded(this, new EventArgs());
            }
           }
            
            // writer.Dispose();
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt")){
                var line = reader.ReadLine();
                while(line != null){
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {

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
        public override void AddGrade(double grade){
            if (grade <= 100.0 && grade >=0.0 )
            {
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof (grade)}");
            }
        }

    public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics(){

            var result = new Statistics();
            // result.Average = 0.0;
            // result.Low = double.MinValue;
            // result.High = double.MaxValue;

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
                result.Add(grades[index]);

                // result.High = Math.Max(grades[index], result.High);
                // result.Low = Math.Min(grades[index], result.Low);

                // result.Average += grades[index];
            }

            // result.Average /= grades.Count;

            // switch (result.Average){

            //     case var d when d >= 90.0:
            //         result.letter = 'A';
            //         break;
                
            //     case var d when d >= 80.0:
            //         result.letter = 'B';
            //         break;

            //     case var d when d >= 70.0:
            //         result.letter = 'C';
            //         break;

            //     case var d when d >= 60.0:
            //         result.letter = 'D';
            //         break;

            //     case var d when d >= 50.0:
            //         result.letter = 'E';
            //         break;

            //     default:
            //         result.letter = 'F';
            //         break;
            // }

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
        // public string Name{
        //     get;
        //     set;
        // }


        // private string name;

        // readonly string category = "Science";

        // const string category = "Science"; /**local scope**/

        public const string CATEGORY = "Science"; /** global scope**/

    }
}

 