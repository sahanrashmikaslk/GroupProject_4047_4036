using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GroupProject_4047_4036.Model;
namespace GroupProject_4047_4036.ViewModel
{
    public partial class AddModuleVM : ObservableObject
    {
        [ObservableProperty]
        public string modName;
        [ObservableProperty]
        public int modCode;
        [ObservableProperty]
        public int modCredit;

        [ObservableProperty]
        public bool isNewMod;

        [ObservableProperty]
        public Module newModule;

        public AddModuleVM()
        {
            isNewMod = false;
        }
        public AddModuleVM(Module module)
        {
            modName = module.ModuleName;
            modCode = module.Code;
            modCredit = module.Credit;
            isNewMod = true;
            newModule = module;
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
        public void AddModule()
        {
            if (isNewMod == false)
            {
                if (modName != null)
                {
                    Module module = new Module()
                    {
                        ModuleName = modName,
                        Code = modCode,
                        Credit = modCredit
                    };

                    using (var data = new DataContext())
                    {
                        data.Modules.Add(module);
                        data.SaveChanges();
                        MessageBox.Show("New Module Added");
                        CloseCurrentWindow();
                    }
                }
            }
            else
            {
                if (modName != null)
                {
                    using (var data = new DataContext())
                    {
                        Module module = data.Modules.Find(newModule.Id);
                        module.Credit = modCredit;
                        module.Code = modCode;
                        module.ModuleName = modName;
                        data.SaveChanges();
                        MessageBox.Show("Updated the module");
                        CloseCurrentWindow();


                    }


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
