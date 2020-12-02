using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Example2
{
    public class Student : Person, INotifyPropertyChanged, IStudent
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public double GetScore(string lesson)
        {
            return 12;
        }

        private string schoolName;

        public string TeacherName;
        public string SchoolName
        {
            get
            {
                if (string.IsNullOrEmpty(schoolName))
                {
                    return "Bahar";
                }
                else { return schoolName; }
            }
            set
            {
                if(value == "Behesht")
                {
                    schoolName = "Ghalat karde";
                }
                else
                {
                    schoolName = value;
                }
                OnPropertyChanged("SchoolName");
            }
        }

        public List<Dictionary<string, double>> Scores { get; set; }

        public Student(string name, string lastName, int age)
        {
            FirstName = name;
            LastName = lastName;
            Age = age;
        }

        public Student(string firstName, string lastName, int age, string teacher , string schoolName)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            TeacherName = teacher;
            SchoolName = schoolName;
        }
    }
}
