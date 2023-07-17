using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupProject_4047_4036.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GroupProject_4047_4036.Model;
namespace GroupProject_4047_4036.ViewModel
{
    public partial class ShowModuleVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Module> modulesList;

        [ObservableProperty]
        public Module selectedmodule;

        public ShowModuleVM()
        {
            modulesList = new ObservableCollection<Module>();
            using (var context = new DataContext())
            {
                var modules = context.Modules.ToList();
                foreach (var module in modules)
                {
                    modulesList.Add(module);
                }
            }
        }
        public void ModuleList()
        {
            using (var db = new DataContext())
            {
                var toList = db.Modules.ToList();
                ModulesList = new ObservableCollection<Module>(toList);

            }

        }
        [RelayCommand]
        public void UpdateModule()
        {
            if (selectedmodule != null)
            {
                var module_ = new AddModuleVM(selectedmodule);
                var window = new AddModuleWindow(module_);
                window.ShowDialog();
                ModuleList();


            }
            else
            {
                MessageBox.Show("Select a Module");

            }
        }
        [RelayCommand]
        public void DeleteModule()
        {
            Module module_ = selectedmodule;
            if (selectedmodule != null)
            {
                using (var db = new DataContext())
                {
                    db.Modules.Remove(module_);
                    db.SaveChanges();
                    MessageBox.Show("Module Deleted");
                    ModuleList();

                }
            }
            else
            {
                MessageBox.Show("Select a Module");
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
