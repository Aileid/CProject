using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CProject
{
    public class Organization: BaseViewModel, INotifyPropertyChanged
    {
        int _id;
        string _name;
        long _inn;
        string _legal_adress;
        string _physical_adress;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {

            get => _id;

            set => RaisePropertyChanged(ref _id, value);
        }
        public string name {

            get => _name;

            set => RaisePropertyChanged(ref _name, value);
        }
        public long inn {

            get => _inn;

            set => RaisePropertyChanged(ref _inn, value);
        }
        public string legal_adress {

            get => _legal_adress;

            set => RaisePropertyChanged(ref _legal_adress, value);
        }
        public string physical_adress {

            get => _physical_adress;

            set => RaisePropertyChanged(ref _physical_adress, value);
        }

    }
}
