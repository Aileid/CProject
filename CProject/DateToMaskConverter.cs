using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyProject.Core
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateToMaskConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt;


            if (value != null)
            {
                if (DateTime.TryParse(value.ToString(), out dt))
                {
                    return (dt).ToString("dd-MM-yyyy");
                }
                else
                    return value;//((DateTime)value).ToString("dd-MM-yyyy");
            }
            else
            {
                return value;
            }
            

            //throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt;

            if (value != null)
            {
                string y = ((string)value).Split('-')[2].Trim();

                //if (y.Length == 4) return 0;

                if (y.Length == 4 && DateTime.TryParse((string?)value, out dt))
                {
                    return dt;
                }
            }
            

            return -1;

            //throw new ArgumentException();
        }
    }
}
