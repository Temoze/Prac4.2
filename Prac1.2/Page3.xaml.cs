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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private SampleDatabaseEntities context = new SampleDatabaseEntities();
        public Page3()
        {
            InitializeComponent();
            UsersDataGrid.ItemsSource = context.Users.ToList();
            UserNameFilter.ItemsSource = context.Users.ToList();
        }
        private void UserNameSearch_Click(object sender, RoutedEventArgs e)
        {
            {
                string searchKeyword = UserNameSearch.Text.Trim();

                using (var context = new SampleDatabaseEntities())
                {
                    var searchResults = context.Users
                        .Where(od => od.UserName.Contains(searchKeyword))
                                            .ToList();

                    UsersDataGrid.ItemsSource = null;
                    UsersDataGrid.ItemsSource = searchResults;
                }
            }
        }



        private void UserNameFilterSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedUserName = (UserNameFilter.SelectedItem as Users)?.UserName;

            if (selectedUserName != null)
            {
                var filteredData = context.Users.Where(od => od.UserName == selectedUserName).ToList();

                UsersDataGrid.ItemsSource = filteredData;
            }
            else
            {
                UsersDataGrid.ItemsSource = context.Users.ToList();
            }
        }



        private void UserNameFilter_Click(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = context.Users.ToList();
        }
    }
}

