using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GroupProject_4047_4036.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject_4047_4036.ViewModel
{
    public partial class AddStudentViewModel : ObservableObject
    {
        [ObservableProperty]
        public string studentName;
        [ObservableProperty]
        public string phoneNumber;
        [ObservableProperty]
        public string address;
        [ObservableProperty]
        public int registerNumber;
        [ObservableProperty]
        public Student newstudent;
        [ObservableProperty]
        public bool isexist;

        public float _studentGpa;

        public float StudentGpa
        {
            get => _studentGpa;
            set
            {
                if (value == _studentGpa)
                {
                    return;
                }
                _studentGpa = value;
                OnPropertyChanged(nameof(StudentGpa));
            }

        }



        [ObservableProperty]
        public Module selectedmodule1;



        public string studentGrade;

        public string StudentGrade
        {
            get => studentGrade;
            set
            {
                if (value == studentGrade)
                {
                    return;
                }
                studentGrade = value;
                OnPropertyChanged(nameof(StudentGrade));
            }

        }



        public Module selectedmodule2;

        public Module Selectedmodule2
        {
            get => selectedmodule2;
            set
            {
                if (value == selectedmodule2)
                {
                    return;
                }
                selectedmodule2 = value;
                OnPropertyChanged(nameof(Selectedmodule2));

            }
        }


        [ObservableProperty]
        public ObservableCollection<Module> viewmoduls;
        [ObservableProperty]
        public ObservableCollection<Module> registedModules;





        public AddStudentViewModel()
        {

            isexist = false;
        }

        public AddStudentViewModel(Student student)
        {
            studentName = student.Name;
            phoneNumber = student.PhoneNumber;
            address = student.Address;
            registerNumber = student.RegisterNumber;
            isexist = true;
            newstudent = student;
            GetRegModule();
            StudentGpa = (float)student.Gpa;

        }
        [RelayCommand]
        public void Save()
        {
            if (isexist == false)
            {
                if (studentName != null)
                {
                    Student student = new Student()
                    {
                        Name = studentName,
                        PhoneNumber = phoneNumber,
                        Address = address,
                        RegisterNumber = registerNumber
                    };

                    using (var data = new DataContext())
                    {
                        data.Students.Add(student);
                        data.SaveChanges();
                        MessageBox.Show("new student added");
                        CloseCurrentWindow();

                    }
                }
            }
            else
            {


                using (var data = new DataContext())
                {
                    Student student = data.Students.Find(newstudent.Id);
                    student.Name = studentName;
                    student.Address = address;
                    student.PhoneNumber = phoneNumber;
                    student.RegisterNumber = registerNumber;


                    data.SaveChanges();
                    MessageBox.Show("Updated Student");
                    Student updatedStud = data.Students.Find(newstudent.Id);
                    StudentGpa = (float)updatedStud.Gpa;
                    CloseCurrentWindow();
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
        [RelayCommand]
        public void AddGrade()
        {
            if (selectedmodule2 != null)
            {
                using (var db = new DataContext())
                {


                    StudentModule studentModules = new StudentModule();

                    studentModules = db.StudentModules.FirstOrDefault(sm => sm.ModuleId == selectedmodule2.Id && sm.StudentId == newstudent.Id);

                    studentModules.Grade = studentGrade;
                    db.SaveChanges();


                    MessageBox.Show("Grade Added");

                    GetRegModule();
                    Student updatedStud = db.Students.Find(newstudent.Id);
                    StudentGpa = (float)updatedStud.Gpa;

                }
            }
            //var window = new ResultWindow();

            //window.Show();

        }
        public void GetRegModule()
        {
            using (var db = new DataContext())
            {
                List<int> getmoduleid = new List<int>();
                var list = db.StudentModules.ToList();
                var list2 = db.Modules.ToList();
                RegistedModules = new ObservableCollection<Module>();
                viewmoduls = new ObservableCollection<Module>(list2);
                foreach (var stdnt in list)
                {
                    if (stdnt.StudentId == newstudent.Id)
                    {
                        getmoduleid.Add(stdnt.ModuleId);
                    }
                }
                foreach (var m in getmoduleid)
                {

                    foreach (var M in viewmoduls)
                    {
                        if (m == M.Id)
                        {
                            RegistedModules.Add(M);
                        }
                    }
                }

            }


        }

        [RelayCommand]
        public void RegModule()
        {
            if (selectedmodule1 != null)
            {
                using (var db = new DataContext())
                {
                    bool isreg = db.StudentModules.Any(sm => sm.ModuleId == selectedmodule1.Id && sm.StudentId == newstudent.Id);
                    if (isreg == false)
                    {
                        StudentModule studentModules = new StudentModule()
                        {
                            StudentId = newstudent.Id,
                            ModuleId = selectedmodule1.Id,
                            Credit = selectedmodule1.Credit,
                            Grade = "F"
                        };
                        db.StudentModules.Add(studentModules);
                        db.SaveChanges();



                        MessageBox.Show("Done");
                        GetRegModule();
                    }
                    else
                    {
                        MessageBox.Show("Already registred");
                    }

                }
            }
            else
            {
                MessageBox.Show("Select a module from module list");
            }
        }

        [RelayCommand]
        public void RemoveRegMod()
        {
            if (selectedmodule2 != null)
            {
                using (var db = new DataContext())
                {
                    StudentModule studentModules = new StudentModule();
                    studentModules = db.StudentModules.FirstOrDefault(sm => sm.ModuleId == selectedmodule2.Id && sm.StudentId == newstudent.Id);
                    db.StudentModules.Remove(studentModules);
                    db.SaveChanges();


                    MessageBox.Show("Removed");
                    GetRegModule();

                }
            }
            else
            {
                MessageBox.Show("Select a registed module");
            }

        }
        [RelayCommand]
        public void CloseWindow()
        {
            CloseCurrentWindow();
        }
    } 

}
