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
using System.Windows;
using System.Data.Entity;
using CsvHelper.Configuration;

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
            
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);
            config.Delimiter = "|";

            using var writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\ExportedData_{DateTime.Now.ToShortDateString()}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.csv", false, Encoding.UTF8);
            using var csv = new CsvWriter(writer, config);

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                //CsvHelper.Configuration.CsvConfiguration config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo. InvariantCulture);
                //config.Encoding = Encoding.GetEncoding(1251);

                //CsvParser csvParser = new CsvParser(new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251)), config);
                //CsvReader csvReader = new CsvReader(csvParser);
                CsvReader csvReader = new CsvReader(new StreamReader(openFileDialog.FileName, Encoding.GetEncoding(1251)), CultureInfo.InvariantCulture);
                //string[] headers = { };
                //List<string[]> rows = new List<string[]>();

                db.Employees.Load();
                db.Organizations.Load();

                while (csvReader.Read())
                {
                    string[] row = csvReader.GetField(0).Split('|');

                        Array a;
                    if(row.Length > 1)
                        if ((a = (from u in db.Organizations
                                  where u.name == row[4]
                                  select u.id).ToArray()).Length == 0)
                        {
                            Organization organization = new Organization() { name = row[4], inn = long.Parse(row[5]), legal_adress = row[6], physical_adress = row[7] };
                            db.Organizations.Add(organization);
                            db.SaveChanges();

                            db.Employees.Add(new Employee() { organization_id = organization.id, birth_date = ConvertDate(row[3].Replace('/', '-').Split(' ')[0]), name = row[0], surname = row[1], patronymic = row[2], passport_number = int.Parse(row[8]), passport_series = int.Parse(row[9]) });
                            db.SaveChanges();
                        }
                        else
                        {
                            int id = (int)a.GetValue(0);

                            db.Employees.Add(new Employee() { organization_id = (int)id, birth_date = ConvertDate(row[3].Replace('/', '-').Split(' ')[0]), name = row[0], surname = row[1], patronymic = row[2], passport_number = int.Parse(row[8]), passport_series = int.Parse(row[9]) });
                            db.SaveChanges();
                        }
                }
            }
        }

        public DateTime ConvertDate(string value)
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
