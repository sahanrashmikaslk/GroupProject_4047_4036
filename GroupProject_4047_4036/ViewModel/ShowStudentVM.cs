using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupProject_4047_4036.Model;
using GroupProject_4047_4036.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject_4047_4036.ViewModel
{
    public partial class ShowStudentVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> studentsList;

        [ObservableProperty]
        public Student selectedstudent;

        public ShowStudentVM()
        {
            studentsList = new ObservableCollection<Student>();
            using (var context = new DataContext())
            {
                var students = context.Students.ToList();
                foreach (var stdn in students)
                {
                    studentsList.Add(stdn);
                }
            }
        }

        public void StudentList()
        {
            using (var data = new DataContext())
            {
                var list = data.Students.ToList();
                studentsList = new ObservableCollection<Student>(list);

            }
        }
        [RelayCommand]
        public void UpdateStudent()
        {
            if (selectedstudent != null)
            {
                var choosenStudent = new AddStudentViewModel(selectedstudent);
                var window = new AddStudentWindow(choosenStudent);
                window.ShowDialog();
                StudentList();
            }
            else
            {
                MessageBox.Show("Please Select a Student");
            }
        }
        [RelayCommand]
        public void DeleteStudent()
        {
            Student choosenStudent = selectedstudent;
            if (selectedstudent != null)
            {
                using (var data1 = new DataContext())
                {
                    data1.Students.Remove(choosenStudent);
                    data1.SaveChanges();
                    MessageBox.Show("Selected Student Deleted");
                    StudentList();

                }
            }
            else
            {
                MessageBox.Show("Please Select a Student");
            }

        }


        private void CloseCurrentWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.Close();
                }
            }
        }
        [RelayCommand]
        public void CloseWindow()
        {
            CloseCurrentWindow();
        }
    }
}
