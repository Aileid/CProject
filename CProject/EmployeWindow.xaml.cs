using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Data.Entity;
using System.Globalization;
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
using Microsoft.EntityFrameworkCore;

namespace CProject
{
    /// <summary>
    /// Логика взаимодействия для EmployeWindow.xaml
    /// </summary>
    public partial class EmployeWindow : Window
    {
        Context bd = new Context();

        public ObservableCollection<Organization> organizations { get; set; }
        public EmployeWindow()
        {
            bd.Organizations.Load();
            organizations = bd.Organizations.Local.ToObservableCollection();//new ObservableCollection<Organization>();// bd.Organizations.Local.ToDictionary();

            InitializeComponent();

            this.DataContext = this;
        }

        void OkAction(object sender, RoutedEventArgs e)
        {
            bd.Employees.Add(new Employee() { organization_id = int.Parse(OrganizationId.SelectedValue.ToString()), birth_date = ConvertDate(BirthDate.Text), name = Name.Text, surname = Subname.Text, patronymic = Patronymic.Text, passport_number = int.Parse(PassportNumber.Text), passport_series = int.Parse(PassportSeries.Text)});
            bd.SaveChanges();
            this.DialogResult = true;
            this.Close();
        }

        void CancelAction(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        DateTime ConvertDate(string value)
        {
            DateTime dt;

            if (value != null)
            {
                string y = value.Split('-')[2].Trim();

                if (y.Length == 4 && DateTime.TryParse(value, out dt))
                {
                    return dt;
                }
            }

            return DateTime.Now;
        }
    }
}
