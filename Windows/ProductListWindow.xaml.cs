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
        public ProductListWindow()
        {
            InitializeComponent();
            LVProduct.ItemsSource = Context.Product.OrderBy(i => i.ID).ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}