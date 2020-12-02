using System;
using System.Collections.Generic;
using System.Text;

namespace Example2
{
    public class Teacher: Person
    {
        private const decimal IncreaseRatePerYear = 10;
        private const int MaxAgeFixedSalary = 40;
        private decimal baseSalary;

        public Teacher(string firstName, string lastName, int age, decimal baseSalary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            this.baseSalary = baseSalary;
        }

        public decimal GetSalary()
        {
            if(Age <= 40)
            {
                return baseSalary;
            }
            else
            {
                int increaseYears = Age - MaxAgeFixedSalary;
                decimal finalSalary = baseSalary + increaseYears * IncreaseRatePerYear;
                return finalSalary;
            }
        }
    }
}
