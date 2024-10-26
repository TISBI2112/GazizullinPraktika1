using EmployeeManagementApp.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EmployeeManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            var positions = App.db.Position.ToList();
            positions.Insert(0, new Position() { Title = "Все" });
            PositionComboBox.ItemsSource = positions;
            Refresh();
        }

        public void Refresh()
        {
            var selectedPosition = PositionComboBox.SelectedItem as Position;
            if (selectedPosition == null || PositionComboBox.SelectedIndex ==0)
            {
                RefreshEmployeeDataGrid(App.db.Employee.Where(empl => empl.FirstName.Contains(SearchTextBox.Text)).ToList());
                return;
            }
            RefreshEmployeeDataGrid(App.db.Employee.Where(empl => empl.FirstName.Contains(SearchTextBox.Text) && empl.Position.Id == selectedPosition.Id).ToList());

        }

        public void RefreshEmployeeDataGrid(List<Employee> employees)
        {
            EmployeeDataGrid.ItemsSource = null;
            EmployeeDataGrid.ItemsSource = employees;
        }

        private void PositionComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
