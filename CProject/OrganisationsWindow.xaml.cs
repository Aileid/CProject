using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CProject
{
    /// <summary>
    /// Логика взаимодействия для CategorysWindow.xaml
    /// </summary>
    public partial class OrganisationsWindow : Window
    {
        Context bd = new Context();

        public OrganisationsWindow()
        {
            InitializeComponent();

            this.Closing += OrganisationsWindow_Closing;
        }

        public void OkAction(object sender, RoutedEventArgs e)
        {
            bd.Organizations.Add(new Organization() { name = OrgName.Text, inn = long.Parse(INN.Text), legal_adress = LegalAdd.Text, physical_adress = PhysAdd.Text });
            bd.SaveChanges();
            this.DialogResult = true;
            this.Close();
        }

        public void CancelAction(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void OrganisationsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bd.Dispose();
        }

    }
}
