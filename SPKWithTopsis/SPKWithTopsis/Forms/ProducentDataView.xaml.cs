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
using SPKWithTopsis.ViewModels;

namespace SPKWithTopsis.Forms
{
    /// <summary>
    /// Interaction logic for ProducentDataView.xaml
    /// </summary>
    public partial class ProducentDataView : Window
    {
        private ProducentVM viewmodel;

        public ProducentDataView()
        {
            InitializeComponent();
            viewmodel = new ViewModels.ProducentVM();
            this.DataContext = viewmodel;
        }
    }
}