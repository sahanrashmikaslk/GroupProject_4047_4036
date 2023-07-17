using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupProject_4047_4036.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_4047_4036.ViewModel
{
    public partial class StudentWindowVM : ObservableObject
    {
        [RelayCommand]
        public void AddStudent()
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.Show();
        }
        [RelayCommand]
        public void RemoveStudent()
        {
            ShowStudentWindow showStudentWindow = new ShowStudentWindow();
            showStudentWindow.Show();
        }

        [RelayCommand]
        public void UpdateStudent()
        {
            ShowStudentWindow showStudentWindow = new ShowStudentWindow();
            showStudentWindow.Show();
        }

        [RelayCommand]
        public void ShowStudent()
        {
            ShowStudentWindow showStudentWindow = new ShowStudentWindow();
            showStudentWindow.Show();
        }
    }
}
