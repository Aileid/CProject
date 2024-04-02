using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CProject
{
    public abstract class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Инициирует обновление значения переданного названия свойства в интерфейсе, и присваивает новое значение
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">старое значение</param>
        /// <param name="newValue">новое значение</param>
        /// <param name="propertyName">название свойства</param>
        public void RaisePropertyChanged<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
