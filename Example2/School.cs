using System;
using System.Collections.Generic;
using System.Text;

namespace Example2
{
    public class School
    {
        public string SchoolName;
        public int SchoolId;

        public School(string schoolName, int schoolId)
        { 
            SchoolName = schoolName;
            SchoolId = schoolId;
        }

        public string GetSchoolInfo()
        {
            return "School Name: " + SchoolName + " \n School ID: " + SchoolId;
        }
    }
}