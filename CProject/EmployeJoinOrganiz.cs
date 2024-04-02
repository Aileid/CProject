using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CProject
{
    public class EmployeJoinOrganiz
    {
        public string Subname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birth_date { get; set; }
        public int Passport_series { get; set; }
        public int Passport_number { get; set; }
        public string Organization { get; set; }
        public long Inn { get; set; }
        public string Legal_adress { get; set; }
        public string Physical_adress { get; set; }
    }
}
