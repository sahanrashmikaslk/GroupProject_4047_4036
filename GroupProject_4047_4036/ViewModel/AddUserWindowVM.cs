using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupProject_4047_4036.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject_4047_4036.ViewModel
{
    public partial class AddUserWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string password;
    
        [ObservableProperty]
        public bool isadmin;
        [ObservableProperty]
        public User newuser;
        [ObservableProperty]
        public bool currentUser;

        public AddUserWindowVM()
        {
            currentUser = false;
        }

        public AddUserWindowVM(User user)
        {
            userName = user.UserName;
            password = user.Password;
     
            if (user.Type == "admin")
            {
                isadmin = true;
            }
            currentUser = true;
            newuser = user;
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
        public void AddUser()
        {
            if (currentUser == false)
            {

                if (userName != null)
                {
                    User user = new User()
                    {
                        UserName = userName,
                        Password = password
                    };
                    if (isadmin)
                    {
                        user.Type = "admin";
                    }
                    else
                    {
                        user.Type = "user";
                    }
                    
                        using (var db = new DataContext())
                        {
                            db.Users.Add(user);
                            db.SaveChanges();
                            MessageBox.Show("User added successfully");
                            CloseCurrentWindow();

                        }
                   



                }
            }
            else
            {
                using (var db = new DataContext())
                {
                    User user2 = db.Users.Find(newuser.Id);
                    user2.UserName = userName;
                    user2.Password = password;
                    if (isadmin)
                    {
                        user2.Type = "admin";
                    }
                    else
                    {
                        user2.Type = "user";
                    }
                  
                        db.SaveChanges();
                        MessageBox.Show("Updated");
                        CloseCurrentWindow();
                  

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
