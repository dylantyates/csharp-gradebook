using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        private void AddLetterGrade(Statistics result)
        {
            switch (result.Average)
            {
                case var avg when avg >= 90:
                    result.Letter = 'A';
                    break;
                case var avg when avg >= 80:
                    result.Letter = 'B';
                    break;
                case var avg when avg >= 70:
                    result.Letter = 'C';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

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

            AddLetterGrade(result);

            return result;
        }

        public List<double> grades;

        public string Name
        {
            get;
            set;
        }

        public const string CATEGORY = "Science";
    }
}