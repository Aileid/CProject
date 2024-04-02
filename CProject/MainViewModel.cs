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

namespace CProject
{
    public class MainViewModel: BaseViewModel
    {
        Context db = new Context();

        public object Employes { get; set; }

        public ICommand AddEmployeCommand { get; }
        public ICommand AddOrganizationCommand { get; }

        public MainViewModel()
        {
         Employes = (from u in db.Employees
                               join c in db.Organizations on u.organization_id equals c.id
                                               select new { Name = u.name, Subname = u.surname, Patronymic = u.patronymic, Birth_date = u.birth_date, Organization = c.name, Inn = c.inn, Legal_adress = c.legal_adress, Physical_adress = c.physical_adress, Passport_number = u.passport_number, Passport_series = u.passport_series }).ToList();

            this.AddEmployeCommand = new RelayCommand(p=> this.AddEmployeAction());
            this.AddOrganizationCommand = new RelayCommand(p=>this.AddOrganizationAction());
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
}
}
