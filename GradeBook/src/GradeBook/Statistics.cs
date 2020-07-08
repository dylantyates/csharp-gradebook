using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var avg when avg >= 90:
                        return 'A';
                    case var avg when avg >= 80:
                        return 'B';
                    case var avg when avg >= 70:
                        return 'C';
                    case var avg when avg >= 70:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;

        }
    }
}