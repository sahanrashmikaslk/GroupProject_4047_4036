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
    public partial class AdminWindowVM : ObservableObject
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

        [RelayCommand]
        public void AddUser()
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.Show();
        }
        [RelayCommand]
        public void RemoveUser()
        {
            ShowUsersWindow showUsersWindow = new ShowUsersWindow();
            showUsersWindow.Show();
          
        }

        [RelayCommand]
        public void UpdateUser()
        {
            ShowUsersWindow showUsersWindow = new ShowUsersWindow();
            showUsersWindow.Show();
        }

        [RelayCommand]
        public void ShowUser()
        {
            ShowUsersWindow showUsersWindow = new ShowUsersWindow();
            showUsersWindow.Show();
        }

        [RelayCommand]
        public void AddModule()
        {
            AddModuleWindow addModuleWindow = new AddModuleWindow();
            addModuleWindow.Show();
        }
        [RelayCommand]
        public void RemoveModule()
        {
            ShowModuleWindow showModuleWindow = new ShowModuleWindow();
            showModuleWindow.Show();
        }

        [RelayCommand]
        public void UpdateModule()
        {
            ShowModuleWindow showModuleWindow = new ShowModuleWindow();
            showModuleWindow.Show();
        }

        [RelayCommand]
        public void ShowModule()
        {
            ShowModuleWindow showModuleWindow = new ShowModuleWindow();
            showModuleWindow.Show();
        }
    }
}
