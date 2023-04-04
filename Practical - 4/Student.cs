using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practical_4
{
    class Student
    {
        public string Name;
        public decimal[] Marks = new decimal[5];
        public static decimal AverageMarks;
        public static string? Grade;


        public enum Options
        {
            Aggregate = 1,
            MinMark = 2,
            MaxMark = 3,
            Garde = 4,
            Exit = 5
        }


        /// <summary>
        ///  Public Decimal function that takes decimal array that contains students Marks
        ///it returns average of marks;
        /// </summary>
        /// <param name="marks"></param>
        /// <returns>decimal</returns>
        public decimal CalculateAverageMarks(decimal[] marks)
        {

            return marks.Average();
        }

        /// <summary>
        /// Public void method that takes average marks in decimal form and from the switch 
        ///  case it using pattern matching it will generates the grades.
        /// </summary>
        /// <param name="marks"></param>
        public void CalculateGrade(decimal marks)
        {

            switch (marks)
            {
                case > 90:
                    Student.Grade = "A";
                    break;
                case > 80:
                    Student.Grade = "B";

                    break;
                case > 70:
                    Student.Grade = "C";
                    break;
                case < 70:
                    Student.Grade = "D";
                    break;
                default:
                    Student.Grade = "Invalid";
                    break;
            }


        }

        /// <summary>
        /// public void aggregate function that takes one decimal and one string value
        ///and it will display the value
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="AverageMarks"></param>
        public string Aggregate(string Name, decimal AverageMarks)
        {
            return $"Student Name : {Name}\nAverage Marks : {AverageMarks}";
        }

        /// <summary>
        /// public void method that takes decimal array as input and returns 
        ///maximum from it.
        /// </summary>
        /// <param name="marks"></param>
        public string MaxMark(decimal[] marks)
        {
            return $"Maximum Marks : {marks.Max()}";
        }

        /// <summary>
        /// public void method that takes decimal array as input and returns 
        ///Minimum decimal from it.
        /// </summary>
        /// <param name="marks"></param>
        public string MinMark(decimal[] marks)
        {
            return $"minimum Marks : {marks.Min()}";

        }

        public static void Main(string[] args)
        {

            Student student = new Student();
            Console.WriteLine("Enter Student Name !");

            student.Name = Console.ReadLine();


            Console.WriteLine("Enter The Marks in Order : \t1.HTML\t2.CSS\t3.Javascript\t4.JQuery\t5.C# ");
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    decimal.TryParse(Console.ReadLine(), out student.Marks[i]);
                }
            }
            catch(IndexOutOfRangeException Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            AverageMarks = student.CalculateAverageMarks(student.Marks);




            Console.WriteLine("Choose Option from Below :");
            Console.WriteLine("1.Aggregate:\n2.MinMark\n3.MaxMarks\n4.Grades\n5.Exit");



            while (true)
            {
 
                int.TryParse(Console.ReadLine(), out int option);
                switch (option)
                {
                    case (int)Student.Options.Aggregate:
                        Console.WriteLine(student.Aggregate(student.Name, AverageMarks)); 

                        break;
                    case (int)Student.Options.Garde:
                        student.CalculateGrade(AverageMarks);
                        Console.WriteLine("Grade : " + Student.Grade);
                        break;
                    case (int)Student.Options.MaxMark:
                        Console.WriteLine(student.MaxMark(student.Marks));
                        break;
                    case (int)Student.Options.MinMark:
                        Console.WriteLine(student.MinMark(student.Marks));
                        break;
                    case (int)Student.Options.Exit:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong Option Choosen");
                        break;
                }

            }
        }

    }
}
