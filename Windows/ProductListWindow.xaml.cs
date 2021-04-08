using BeautySalon_Brovushka.EF;
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
using static BeautySalon_Brovushka.EF.AppData;

namespace BeautySalon_Brovushka.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        List<Product> ProductList = new List<Product>();
        List<string> ManufacturerList = new List<string>();
        public ProductListWindow()
        {
            InitializeComponent();
            ProductList = Context.Product.OrderBy(i => i.ID).ToList();
            LVProduct.ItemsSource = ProductList;

            foreach (var item in Context.Manufacturer.OrderBy(i => i.ID))
            {
                ManufacturerList.Add(item.Name);
            }
            ManufacturerList.Insert(0, "Все");
            CBManufacturer.ItemsSource = ManufacturerList;
            CBManufacturer.SelectedIndex = 0;

            CBSort.ItemsSource = new List<string>()
            {
                "По умолчанию",
                "Цена (по возрастанию)",
                "Цена (по убыванию)"
            };
            CBSort.SelectedIndex = 0;

            TBlCount.Text = Context.Product.Count().ToString();
            TBlFilteredCount.Text = TBlCount.Text;
        }

        private void Filter()
        {
            //Фильтрация и поиск не работает
            ProductList = Context.Product.OrderBy(i => i.ID).ToList();
            //Фильтрация
            if (CBManufacturer.SelectedIndex > 0)
            {
                ProductList = ProductList.Where(i => i.ManufacturerID == CBManufacturer.SelectedIndex).ToList();
            }

            //Поиск
            ProductList = ProductList
                .Where(i => i.Title.Contains(TBName.Text))
                .Where(i => i.Description.Contains(TBDescription.Text)).ToList();

            LVProduct.ItemsSource = ProductList;
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