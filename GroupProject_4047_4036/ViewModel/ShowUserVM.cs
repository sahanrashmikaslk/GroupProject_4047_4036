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
    public partial class ShowUserVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> usersList;

        [ObservableProperty]
        public User selectedUser;

        public ShowUserVM()
        {
            usersList = new ObservableCollection<User>();
            using (var db = new DataContext())
            {
                var users = db.Users.ToList();
                foreach (var singleUser in users)
                {
                    usersList.Add(singleUser);
                }
            }

        }

        public void UserList()
        {
            using (var data = new DataContext())
            {
                var list = data.Users.ToList();
                UsersList = new ObservableCollection<User>(list);

            }
        }
        [RelayCommand]
        public void UpdateUser()
        {
            if (selectedUser != null)
            {
                var usr = new AddUserWindowVM(selectedUser);
                var window = new AddUserWindow(usr);
                window.ShowDialog();
                UserList();

            }
            else
            {
                MessageBox.Show("Select a user");

            }

        }
        [RelayCommand]
        public void DeleteUser()
        {
            User user = selectedUser;
            if (selectedUser != null)
            {
                using (var data = new DataContext())
                {
                    data.Users.Remove(user);
                    data.SaveChanges();
                    MessageBox.Show("Selected User Deleted");
                    UserList();

                }
            }
            else
            {
                MessageBox.Show("Select a user");
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
