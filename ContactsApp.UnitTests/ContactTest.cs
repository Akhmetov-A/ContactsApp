using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        private Contact _contact;
        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
        }

        [TestCase("Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов",
            "Должно возникать исключение , если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии больше 50 символов")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(() => { _contact.Surname = wrongSurname; }, message);
        }

        [TestCase("Смирнов",
            "Тест пройден, если исключений не возникло",
            TestName = "Присвоение правильной фамилии")]
        public void TestSurnameSet_SetCorrectValue(string correctSurname, string message)
        {
            Assert.DoesNotThrow(() => { _contact.Surname = correctSurname; }, message);
        }

        [Test(Description = "Позитивный тест геттера Surname")]
        public void TestSurname_GetCorrectValue()
        {
            var expected = "Смирнов";
            _contact.Surname = expected;
            var actual = _contact.Surname;
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [TestCase("Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван",
            "Должно возникать исключение, если имя длинее 50 символов",
            TestName = "Присвоение неправильного имение больше 50 символов")]
        public void TestName_SetArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(() => { _contact.Name = wrongName; }, message);
        }

        [TestCase("Иван",
            "Тест пройден, если исключений не возникло",
            TestName = "Присвоение правильного имени")]
        public void TestName_SetCorrectValue(string correctName, string message)
        {
            Assert.DoesNotThrow(() => { _contact.Name = correctName; }, message);
        }

        [Test(Description = "Поизитивный тест геттера Name")]
        public void TestName_GetCorrectValue()
        {
            var expected = "Иван";
            _contact.Name = expected;
            var actual = _contact.Name;
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }

        private static DateTime d = new DateTime(5000, 06, 20);
        [TestCase("5000, 06, 20",
            "Должно возникать исключение, если дата рождения больше сегодняшней",
            TestName = "Присвоение неправильной даты рождения больше допустимого")]
        [TestCase("1899, 01, 01",
            "Должно возникать исключение, если дата рождение меньше 1900 года",
           TestName = "Присвоение неправильной даты рождения меньше допусимого")]
        public void TestBirthDay_SetArgumentException(string wrongBirthDay, string message)
        {
            Assert.Throws<ArgumentException>(() => { _contact.BirthDay = DateTime.Parse(wrongBirthDay); }, message);
        }

        [TestCase("1998, 10, 09",
            "Тест пройден если иключений не возникло",
           TestName = "Присвоение правильной даты рождения")]
        public void TestBirthDay_SetCorrectValue(string correctBirthDay, string message)
        {
            Assert.DoesNotThrow(() => { _contact.BirthDay = DateTime.Parse(correctBirthDay); }, message);
        }

        [Test(Description = "Поизитивный тест геттера BirthDay")]
        public void TestBirthDay_GetCorrectValue()
        {
            DateTime expected = new DateTime(1990, 02, 15);
            _contact.BirthDay = expected;
            var actual = _contact.BirthDay;
            Assert.AreEqual(expected, actual, "Геттер Birth возвращает неправильную дату рождения");
        }

        [TestCase(0, "Должно возникать исключение, если номер меньше 70000000000",
        TestName = "Присвоение значения номера меньше 70000000000")]
        [TestCase(100000000000, "Должно возникать исключение, если номер больше 79999999999",
        TestName = "Присвоение значения номера больше 79999999999")]
        public void TestNumber_SetArgumentException(long wrongNumber, string message)
        {
            Assert.Throws<ArgumentException>(() => { _contact.Phone.Number = wrongNumber; }, message);
        }

        [Test(Description = "Позитивный тест сеттера Number")]
        public void TestNumber_SetCorrectValue()
        {
            var expected = 79234360917;
            Assert.DoesNotThrow(() => { _contact.Phone.Number = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void TestNumber_GetCorrectValue()
        {
            var expected = 79234360917;
            _contact.Phone.Number = expected;
            var actual = _contact.Phone.Number;
            Assert.AreEqual(expected, actual, "Геттер Number возвращает неправильный номер телефона");
        }

        [TestCase("mail-mail-mail-mail-mail-mail-mail-mail-mail-mail-mail",
            "Должно возникать исключение, если e-mail линее 50 символов",
            TestName = "Присвоение неправильного e-mail")]
        public void TestEmail_SetArgumentException(string wrongEmail, string message)
        {
            Assert.Throws<ArgumentException>(() => { _contact.Email = wrongEmail; }, message);
        }

        [TestCase("example@mail.com",
            "Тест пройден, если исключений не возникло",
            TestName = "Присвоение правильного e-mail")]
        public void TestEmail_SetCorrectValue(string correctEmail, string message)
        {
            Assert.DoesNotThrow(() => { _contact.Email = correctEmail; }, message);
        }

        [Test(Description ="Позитивный тест геттера Email")]
        public void TestEmail_GetCorrectValue()
        {
            var expected = "example@mail.ru";
            _contact.Email = expected;
            var actual = _contact.Email;
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильный e-mail");
        }

        [TestCase("1234567890123456", 
            "Должно возникать исключение, если IDvk длинне 15 символов",
            TestName ="Присвоение неправильного IDvk")]
        public void TestIDvk_SetArgumentException(string wrongIDvk, string message)
        {
            Assert.Throws<ArgumentException>(() => { _contact.IDvk = wrongIDvk; }, message);
        }

        [TestCase("123",
            "Тест пройден, если исключений не возникло",
            TestName ="Присвоение правильного IDvk")]
        public void TestIDvk_SetCorrectValue(string correctIDvk, string message)
        {
            Assert.DoesNotThrow(() => { _contact.IDvk = correctIDvk; }, message);
        }

        [Test(Description ="Поизитивный тест геттера IDvk")]
        public void TestIDvk_GetCorrectValue()
        {
            var expected = "123";
            _contact.IDvk = expected;
            var actual = _contact.IDvk;
            Assert.AreEqual(expected, actual, "Геттер IDvk возвращает неправильный IDvk");
        }
    }
}
