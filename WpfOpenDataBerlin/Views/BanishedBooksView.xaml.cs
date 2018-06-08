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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfOpenDataBerlin.ViewModels;

namespace WpfOpenDataBerlin.Views
{
    /// <summary>
    /// Interaktionslogik für BanishedBooksView.xaml
    /// </summary>
    public partial class BanishedBooksView : UserControl
    {
        public BanishedBooksView()
        {
            InitializeComponent();
            BanishedBooksViewModel viewModel = new BanishedBooksViewModel();
            this.DataContext = viewModel;
        }
    }
}
