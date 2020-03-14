using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс "Проект". Представляет собой список контактов.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Объявление списка.
        /// </summary>
        public List<Contact> Contacts = new List<Contact>();

        public List<Contact> Sort(List<Contact> Contacts)
        {
            Contacts.Sort(delegate (Contact x, Contact y)
            {
                return x.Surname.CompareTo(y.Surname);
            });
            return Contacts;
        }

        public static Project Sort(Project project, string substring)
        {
            Project sortedProject = new Project();

            for (int i = 0; i < project.Contacts.Count; i++)
            {
                if (project.Contacts[i].Surname.Contains(substring) ||
                    project.Contacts[i].Name.Contains(substring))
                {
                    sortedProject.Contacts.Add(project.Contacts[i]);
                }
            }

            if (sortedProject.Contacts.Count == 0)
            {
                sortedProject = null;
                return sortedProject;
            }
            return sortedProject;
        }

        public static Project Birthday(Project data, DateTime today)
        {
            Project returnProject = new Project();
            for (int i = 0; i < data.Contacts.Count; i++)
            {
                if ((data.Contacts[i].BirthDay.Day == today.Day) && (data.Contacts[i].BirthDay.Month == today.Month))
                {
                    returnProject.Contacts.Add(data.Contacts[i]);
                }
            }
            return returnProject;
        }
    }
}
