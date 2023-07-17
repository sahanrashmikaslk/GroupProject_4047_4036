using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupProject_4047_4036.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject_4047_4036.ViewModel
{
    public partial class MainWindowVM : ObservableObject
    {

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        

        [RelayCommand]

        public void LoginWindowAdmin() {
            if (username != null)
            {
                using (var database = new DataContext())
                {
                    bool present = database.Users.Any(prsn => prsn.UserName == username && prsn.Password == Password);

                    if (present)
                    {
                        bool isadmin = database.Users.Any(prsn => prsn.UserName == username && prsn.Password == Password && prsn.Type == "admin");

                        if (isadmin)
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();

                        }
                        else
                        {
                            StudentWindow Window = new StudentWindow();
                            Window.Show();
                        }
                        
                        CloseCurrentWindow();

                    }
                    else
                    {
                        MessageBox.Show("Username or Password incorect");

                    }


                }



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
    }
}
