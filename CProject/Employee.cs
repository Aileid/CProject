using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CProject
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public DateTime birth_date { get; set; }
        public int passport_series { get; set; }
        public int passport_number { get; set; }
        public int organization_id { get; set; }

        [ForeignKey("organization_id")]
        public Organization? Organization { get; set; }
    }
}
