using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        private Contact _contact;
        private Project _project;
        [SetUp]
        public void InitProject()
        {
            _contact = new Contact();
            _contact.Surname = "Смирнов";
            _contact.Name = "Иван";
            _contact.Phone.Number = 79234360917;
            _contact.BirthDay = new DateTime(1995, 05, 20);
            _contact.Email = "ivansmirnov@mail.ru";
            _contact.IDvk = "950520";
            _project = new Project();
        }

        [Test(Description ="Позитивный тест сериализации")]
        public void TestSaveToFile_CorrectValue()
        {
            _project.Contacts.Add(_contact);
            ProjectManager.SaveToFile(_project, Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                + @"\ContactsAppTest1.txt");
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var projectPath = System.IO.Path.GetDirectoryName(assemblyPath);
            string reference = System.IO.File.ReadAllText(projectPath + @"\SourceLoadProject.txt");
            string actual = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                + @"\ContactsAppTest1.txt");
            Assert.AreEqual(reference, actual, "Тест пройден, если исключений не возникло");
        }

        [Test(Description ="Позитивный тест десериализации")]
        public void TestLoad_CorrectValue()
        {
            _project.Contacts.Add(_contact);
            Project actualProject = new Project();
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            var projectPath = System.IO.Path.GetDirectoryName(assemblyPath);
            actualProject=ProjectManager.Load(projectPath + @"\SourceLoadProject.txt");
            Assert.AreEqual(_project.Contacts.Count, actualProject.Contacts.Count, "Загрузка работает неправильно");
            for (int i = 0; i != _project.Contacts.Count; i++)
            {
                Assert.AreEqual(_project.Contacts[i].Surname, actualProject.Contacts[i].Surname, "Загрузка фамилии работает неправильно");
                Assert.AreEqual(_project.Contacts[i].Name, actualProject.Contacts[i].Name, "Загрузка имени работает неправильно");
                Assert.AreEqual(_project.Contacts[i].BirthDay, actualProject.Contacts[i].BirthDay, "Загрузка даты рождения работает неправильно");
                Assert.AreEqual(_project.Contacts[i].Phone.Number, actualProject.Contacts[i].Phone.Number, "Загрузка номера телефона работает неправильно");
                Assert.AreEqual(_project.Contacts[i].Email, actualProject.Contacts[i].Email, "Загрузка e-mail работает неправильно");
                Assert.AreEqual(_project.Contacts[i].IDvk, actualProject.Contacts[i].IDvk, "Загрузка IDvk работает неправильно"); 
            }
        }
    }
}
