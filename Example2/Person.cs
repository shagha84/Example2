using System;
using System.Collections.Generic;
using System.Text;

namespace Example2
{
    public class Person 
    {
        public string FirstName;
        public string LastName;
        public int Age;

        public string GetBasicInfo()
        {
            return "First Name: " + FirstName + " \n LastName: " + LastName + " \n Age: " + Age;
        }
    }
}