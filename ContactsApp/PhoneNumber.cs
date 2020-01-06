using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Отдельный класс "Номер телефона".
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Поле "Номер".
        /// </summary>
        private long _number;

        /// <summary>
        /// Свойство поля "Номер". Начинается с 7 и состоит из 11 цифр.
        /// </summary>
        public long Number
        {
            get { return _number; }
            set
            {
                if (value < 70000000000 && value > 70000000000)
                {
                    throw new ArgumentException("Номер телефона должен состоять из 11 цифр и начинаться с 7");
                }
                else
                    _number = value;
            }
        }
    }
}
