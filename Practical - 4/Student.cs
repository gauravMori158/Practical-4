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
            decimal sum = 0;
            foreach (decimal mark in marks)
                sum += mark;
            return sum / 5;
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
        public void Aggregate(string Name, decimal AverageMarks)
        {
            Console.WriteLine("Student Name : " + Name);
            Console.WriteLine("Average Marks : " + AverageMarks);
        }
        
        /// <summary>
        /// public void method that takes decimal array as input and returns 
        ///maximum from it.
        /// </summary>
        /// <param name="marks"></param>
        public void MaxMark(decimal[] marks)
        {
            decimal max = decimal.MinValue;

            foreach (decimal mark in marks)
            {
                if (mark > max) max = mark;
            }

            Console.WriteLine("Maximum Mark : " + max);
        }
      
        /// <summary>
        /// public void method that takes decimal array as input and returns 
        ///Minimum decimal from it.
        /// </summary>
        /// <param name="marks"></param>
        public void MinMark(decimal[] marks)
        {
            decimal min = decimal.MaxValue;

            foreach (decimal mark in marks)
            {
                if (mark < min) min = mark;
            }

            Console.WriteLine("Minimum Mark : " + min);
        }

        public static void Main(string[] args)
        {
            //Student.AverageMarks= Student.CalculateAverageMarks()
            Student student = new Student();
            Console.WriteLine("Enter Student Name !");

            student.Name = Console.ReadLine();


            Console.WriteLine("Enter The Marks in Order : \t1.HTML\t2.CSS\t3.Javascript\t4.JQuery\t5.C# ");

            for (int i = 0; i < 5; i++)
            {
                student.Marks[i] = Convert.ToDecimal(Console.ReadLine());
            }

            AverageMarks = student.CalculateAverageMarks(student.Marks);




            Console.WriteLine("Choose Option from Below :");
            Console.WriteLine("1.Aggregate:\n2.MinMark\n3.MaxMarks\n4.Grades\n5.Exit");



            while (true)
            {

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case (int)Student.Options.Aggregate:
                        student.Aggregate(student.Name, AverageMarks);

                        break;
                    case (int)Student.Options.Garde:
                        student.CalculateGrade(AverageMarks);
                        Console.WriteLine("Grade : " + Student.Grade);
                        break;
                    case (int)Student.Options.MaxMark:
                        student.MaxMark(student.Marks);
                        break;
                    case (int)Student.Options.MinMark:
                        student.MinMark(student.Marks);
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
