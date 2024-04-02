using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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

namespace CProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context db;
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
            //db = new Context();


            //var employes = from u in db.Employees
            //join c in db.Organizations on u.organization_id equals c.id
            //select new { Name = u.name, Subname = u.surname, Patronymic = u.patronymic, Birth_date = u.birth_date, Organization = c.name, Inn = c.inn, Legal_adress = c.legal_adress, Physical_adress = c.physical_adress, Passport_number = u.passport_number, Passport_series = u.passport_series };

            //db.Organizations.Load();
            //db.Employees.Load(); // загружаем данные
            //employesGrid.ItemsSource = employes.ToList(); //db.Organizations.Local.ToBindingList(); // устанавливаем привязку к кэшу

            //this.Closing += MainWindow_Closing;
        }


    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        db.Dispose();
    }

    private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (employesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < employesGrid.SelectedItems.Count; i++)
                {
                    //Employe employe = phonesGrid.SelectedItems[i] as Employe;
                    //if (employe != null)
                    //{
                        //db.Employees.Remove(employe);
                    //}
                }
            }
            db.SaveChanges();
        }
    }
}
