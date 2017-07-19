﻿using System;
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

namespace SPKWithTopsis.Forms
{
    /// <summary>
    /// Interaction logic for HandphoneSearch.xaml
    /// </summary>
    public partial class HandphoneSearch : Window
    {
        public HandphoneSearch()
        {
            InitializeComponent();
            var vm= new ViewModels.HandphoneSearchVM();
            this.DataContext = vm;
        }
    }
}
