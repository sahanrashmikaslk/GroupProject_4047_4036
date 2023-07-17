﻿using GroupProject_4047_4036.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GroupProject_4047_4036.View
{
    /// <summary>
    /// Interaction logic for ShowStudentWindow.xaml
    /// </summary>
    public partial class ShowStudentWindow : Window
    {
        public ShowStudentWindow()
        {
            DataContext = new ShowStudentVM();
            InitializeComponent();
        }
    }
}
