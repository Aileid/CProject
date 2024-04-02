using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Documents;
using System.Formats.Asn1;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace CProject
{
    public class MainViewModel: BaseViewModel
    {
        Context db = new Context();

        public object Employes { get; set; }

        public ICommand AddEmployeCommand { get; }
        public ICommand AddOrganizationCommand { get; }
        public ICommand ExportToCsvCommand { get; }
        public ICommand ImportFromCsvCommand { get; }

        public MainViewModel()
        {
            Employes = (from u in db.Employees
                               join c in db.Organizations on u.organization_id equals c.id
                                               select new { Name = u.name, Subname = u.surname, Patronymic = u.patronymic, Birth_date = u.birth_date, Organization = c.name, Inn = c.inn, Legal_adress = c.legal_adress, Physical_adress = c.physical_adress, Passport_number = u.passport_number, Passport_series = u.passport_series }).ToList();

            this.AddEmployeCommand = new RelayCommand(p=> this.AddEmployeAction());
            this.AddOrganizationCommand = new RelayCommand(p=>this.AddOrganizationAction());
            this.ExportToCsvCommand = new RelayCommand(p => this.ExportToCSVAction());
            this.ImportFromCsvCommand = new RelayCommand(p => this.ImportFromCSVAction());

        }

        void Refreshemployes()
        {
            Employes = (from u in db.Employees
                        join c in db.Organizations on u.organization_id equals c.id
                        select new { Name = u.name, Subname = u.surname, Patronymic = u.patronymic, Birth_date = u.birth_date, Organization = c.name, Inn = c.inn, Legal_adress = c.legal_adress, Physical_adress = c.physical_adress, Passport_number = u.passport_number, Passport_series = u.passport_series }).ToList();
        }

        public void AddEmployeAction()
        {
            EmployeWindow ewindow = new EmployeWindow();
            if (ewindow.ShowDialog() == true)
            {
                Refreshemployes();
            }
        }

        public void AddOrganizationAction()
        {
            OrganisationsWindow owindow = new OrganisationsWindow();
            if (owindow.ShowDialog() == true)
            {
                Refreshemployes();
            }
        }

        void ExportToCSVAction()
        {
            var employes = (from u in db.Employees
                        join c in db.Organizations on u.organization_id equals c.id
                        select new { Name = u.name, Subname = u.surname, Patronymic = u.patronymic, Birth_date = u.birth_date, Organization = c.name, Inn = c.inn, Legal_adress = c.legal_adress, Physical_adress = c.physical_adress, Passport_number = u.passport_number, Passport_series = u.passport_series }).ToArray();

            //string s = ToCSV(employes);Encoding.UTF8
            using var writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\ExportedData_{DateTime.Now.ToShortDateString()}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.csv", false, Encoding.UTF8);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteHeader<Employee>();
            csv.NextRecord();
            foreach (var employee in employes)
            {
                csv.WriteRecord(employee);
                csv.NextRecord();
            }
        }

        void ImportFromCSVAction()
        {
            
        }

        string ToCSV(Array items)
        {
            if (items.Length > 0)
            {
                bool isFirstIteration = true;
                StringBuilder sb = new StringBuilder();
                foreach (object item in items)
                {
                    string[] propertyNames = item.GetType().GetProperties().Select(p => p.Name).ToArray();
                    foreach (var prop in propertyNames)
                    {
                        if (isFirstIteration == true)
                        {
                            for (int j = 0; j < propertyNames.Length; j++)
                            {
                                sb.Append("\"" + propertyNames[j] + "\"" + ',');
                            }
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("\r\n");
                            isFirstIteration = false;
                        }
                        object propValue = item.GetType().GetProperty(prop).GetValue(item, null);
                        sb.Append("\"" + propValue + "\"" + ",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\r\n");
                }
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
