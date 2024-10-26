using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EmployeeManagementApp.DataModel;

namespace EmployeeManagementApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EmployeeManagementEntities db= new EmployeeManagementEntities();
    }
}
