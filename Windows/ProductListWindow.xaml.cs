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
using static BeautySalon_Brovushka.EF.AppData;

namespace BeautySalon_Brovushka.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();
            LVProduct.ItemsSource = Context.Product.OrderBy(i => i.ID).ToList();

            TBlCount.Text = Context.Product.Count().ToString();
            TBlFilteredCount.Text = TBlCount.Text;
        }

        private void Filter()
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CBManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TBDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void TBName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}