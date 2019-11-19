using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppUI
{
    /// <summary>
    /// Класс "Контакт". Содержит фамилию, имя, дату рождения, e-mail, id вконтакте.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Поле "Фамилия".
        /// </summary>
        private string _surname;

        /// <summary>
        /// Поле "Имя".
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле "День рождение".
        /// </summary>
        private DateTime _birthDay;

        /// <summary>
        /// Поле "Электронная почта".
        /// </summary>
        private string _email;

        /// <summary>
        /// Поле "ID Вконтакте".
        /// </summary>
        private string _idvk;

        /// <summary>
        /// Свойство поля "Фамилия". Содержит не более 50 символов.
        /// </summary>
        public string Surname 
        {
            get { return _surname; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина фамилии не должна быть больше 50 символов");
                }
                else
                    _surname = value;
            }
        }

        /// <summary>
        /// Свойство поля "Имя". Содержит не более 50 символов.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина имени не должна быть больше 50 символов");
                }
                else
                    _name = value;
            }
        }

        /// <summary>
        /// Поле "Номер телефона". Реализация представлена в отдельном файле.
        /// </summary>
        private PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Свойство поля "День рождения". Содержит информацию о дне, месяце, годе рождения владельца контакта.
        /// </summary>
        public DateTime BirthDay
        {
            get { return _birthDay; }
            set
            {
                if (value>DateTime.Today && value<DateTime.FromBinary(1900))
                {
                    throw new ArgumentException("Дата рождения не может быть раньше 1900 года и позже текущего");
                }
                else
                    _birthDay = value;
            }
        }

        /// <summary>
        /// Свойство поля "Электронная почта". Содержит не более 50 символов.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина e-mail не должна быть больше 50 символов");
                }
                else
                    _email = value;
            }
        }

        /// <summary>
        /// Свойство поля "ID Вконтакте". Содержит не более 15 символов.
        /// </summary>
        public string IDvk
        {
            get { return _idvk; }
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("Длина id не должна быть больше 15 символов");
                }
                else
                   _idvk = value;
            }
        }
    }
}
