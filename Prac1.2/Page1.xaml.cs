using System;
using System.Collections.Generic;
using System.Data;
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

namespace Prac1._2
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private SampleDatabaseEntities context = new SampleDatabaseEntities();
        public Page1()
        {
            InitializeComponent();
            OrderDetailsDataGrid.ItemsSource = context.OrderDetails.ToList();
            ProductFilter.ItemsSource = context.OrderDetails.ToList();
        }
        private void ProductSearch_Click(object sender, RoutedEventArgs e)
        {
            {
                string searchKeyword = ProductSearch.Text.Trim(); 
                
                using (var context = new SampleDatabaseEntities())
                {
                    var searchResults = context.OrderDetails
                                            .Where(od => od.ProductName.Contains(searchKeyword))
                                            .ToList();

                    OrderDetailsDataGrid.ItemsSource = null;
                    OrderDetailsDataGrid.ItemsSource = searchResults;
                }
            }
        }



        private void ProductFilterSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedProductName = (ProductFilter.SelectedItem as OrderDetails)?.ProductName;

            if (selectedProductName != null)
            {
                // Применяем фильтрацию
                var filteredData = context.OrderDetails.Where(od => od.ProductName == selectedProductName).ToList();

                // Обновляем источник данных для DataGrid
                OrderDetailsDataGrid.ItemsSource = filteredData;
            }
            else
            {
                // Если ничего не выбрано, показываем все данные
                OrderDetailsDataGrid.ItemsSource = context.OrderDetails.ToList();
            }
        }



        private void ProductFilter_Click(object sender, RoutedEventArgs e)
        {
            OrderDetailsDataGrid.ItemsSource = context.OrderDetails.ToList();
        }
    }
}
