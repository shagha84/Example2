using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> teachers { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> students { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> schools { get; set; } = new ObservableCollection<string>();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        txtBlockInfoStudent.ItemsSource = students;
        txtBlockInfoTeacher.ItemsSource = teachers;
        txtBlockInfoSchool.ItemsSource = schools;
            Student st = new Student("John", "Bagheri", 25);
            st.Age = 26;
            string school = st.SchoolName;
            st.SchoolName = "Behesht";
    }

        // Add a Teacher
        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            string name = tbFirstNameTeacher.Text;
            string lastName = tbLastNameTeacher.Text;
            int age = Convert.ToInt32(tbAgeTeacher.Text);
            string text = tbSalaryTeacher.Text;
            int baseSalary = Convert.ToInt32(text);
            Teacher teacher = new Teacher(name, lastName, age, baseSalary);

            string basicInfo = teacher.GetBasicInfo();
            decimal salary = teacher.GetSalary();
            string fullInfo = basicInfo + " \n Salary: " + salary.ToString();

            teachers.Add(fullInfo);
            txtBlockInfoTeacher.ItemsSource = teachers;
        }

        // Remove a Teacher => must Remove his/her Student too
        private void RemoveTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            bool isOk = txtBlockInfoTeacher.SelectedIndex >= 0;
            if (!isOk)
            {
                MessageBox.Show("Please select an item at first!");
            }
            else
            {
                string info = txtBlockInfoTeacher.SelectedItem as string;
                string[] separatedInfo = info.Split(' ');
                name = separatedInfo[2];

                teachers.RemoveAt(txtBlockInfoTeacher.SelectedIndex);

                List<int> index = new List<int>();
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Contains(name))
                    {
                        index.Add(i);
                    }
                }
                if (index.Count >= 0)
                {
                    for (int i = students.Count - 1; i >= 0; i--)
                    {
                        if (index.Contains(i))
                        {
                            students.RemoveAt(i);
                        }
                    }
                }
            }
        }

        //Add a Student
        private void AddStudentButton_Click2(object sender, RoutedEventArgs e)
        {

            string name = tbFirstNameStudent.Text;
            string lastName = tbLastNameStudent.Text;
            int age = Convert.ToInt32(tbAgeStudent.Text);
            string teacher = txtTeacherName.Text;
            string schoolName = txtSchoolName.Text;
            Student student = new Student(name, lastName, age, teacher, schoolName);


            string basicInfo = student.GetBasicInfo();
            string fullInfoSt = basicInfo + "\n Teacher: " + student.TeacherName + "\n School: " + student.SchoolName;

            students.Add(fullInfoSt);

        }

        //Remove a Student
        private void RemoveStudentButton_Click2(object sender, RoutedEventArgs e)
        {
            bool isOk = txtBlockInfoStudent.SelectedIndex >= 0;
            if (!isOk)
            {
                MessageBox.Show("Please select an item at first!");
            }
            else
            {
                students.RemoveAt(txtBlockInfoStudent.SelectedIndex);
            }

        }

        private void txtSchoolBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Add a School
        private void ButtonAddSchool_Click(object sender, RoutedEventArgs e)
        {
            string schoolName = txtSchoolBox.Text;
            int schoolId = Convert.ToInt32(tbIDSchool.Text);
            School school = new School(schoolName, schoolId);

            string fullInfo = "Name: " + schoolName + " \n ID: " + schoolId.ToString();

            schools.Add(fullInfo);
            txtBlockInfoSchool.ItemsSource = schools;

        }

        // Remove a School => must Remove a Student too
        private void ButtonRemoveSchool_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            bool isOk = txtBlockInfoSchool.SelectedIndex >= 0;
            if (!isOk)
            {
                MessageBox.Show("Please select an item at first!");
            }
            else
            {
                string info = txtBlockInfoSchool.SelectedItem as string;
                string[] separatedInfo = info.Split(' ');
                name = separatedInfo[2];

                schools.RemoveAt(txtBlockInfoSchool.SelectedIndex);

                List<int> index = new List<int>();
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Contains(name))
                    {
                        index.Add(i);
                    }
                }
                if (index.Count >= 0)
                {
                    for (int i = students.Count - 1; i >= 0; i--)
                    {
                        if (index.Contains(i))
                        {
                            students.RemoveAt(i);
                        }
                    }
                }
            }
        }
    }
}