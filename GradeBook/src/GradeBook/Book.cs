using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var numericGrade when numericGrade >= 90.0:
                    result.Letter = 'A';
                    break;
                case var numericGrade when numericGrade >= 80.0:
                    result.Letter = 'B';
                    break;
                case var numericGrade when numericGrade >= 70.0:
                    result.Letter = 'C';
                    break;
                case var numericGrade when numericGrade >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public List<double> grades;
        public string Name;
    }
}