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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private SampleDatabaseEntities context = new SampleDatabaseEntities();
        public Page2()
        {
            InitializeComponent();
            OrdersDataGrid.ItemsSource = context.Orders.ToList();
            UserIDFilter.ItemsSource = context.Orders.ToList();
        }
        private void UserIDSearch_Click(object sender, RoutedEventArgs e)
        {
            {
                string searchKeyword = UserIDSearch.Text.Trim();

                using (var context = new SampleDatabaseEntities())
                {
                    var searchResults = context.Orders
                        .Where(od => od.UserID != null && od.UserID.Value.ToString().Contains(searchKeyword))
                        .ToList();

                    OrdersDataGrid.ItemsSource = null;
                    OrdersDataGrid.ItemsSource = searchResults;
                }
            }
        }



        private void UserIDFilterSearch_Click(object sender, RoutedEventArgs e)
        {
            int? selectedUserID = (UserIDFilter.SelectedItem as Orders)?.UserID;

            if (selectedUserID != null)
            {
                var filteredData = context.Orders.Where(od => od.UserID == selectedUserID).ToList();

                OrdersDataGrid.ItemsSource = filteredData;
            }
            else
            {
                OrdersDataGrid.ItemsSource = context.Orders.ToList();
            }
        }



        private void UserIDFilter_Click(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.ItemsSource = context.Orders.ToList();
        }
    }
}
