using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class PhoneNumberTest
    {
        private PhoneNumber _number;

        [SetUp]
        public void InitNumber()
        {
            _number = new PhoneNumber();
        }

        [TestCase(0, "Должно возникать исключение, если номер меньше 70000000000",
        TestName = "Присвоение значения номера меньше 70000000000")]
        [TestCase(100000000000, "Должно возникать исключение, если номер больше 79999999999",
        TestName = "Присвоение значения номера больше 79999999999")]
        public void TestNumber_SetArgumentException(long wrongNumber, string message)
        {
            Assert.Throws<ArgumentException>(() => { _number.Number = wrongNumber; }, message);
        }

        [Test(Description = "Позитивный тест сеттера Number")]
        public void TestNumber_SetCorrectValue()
        {
            var expected = 79234360917;
            Assert.DoesNotThrow(() => { _number.Number = expected; }, "Тест не пройден, если выдается исключение");
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void TestNumber_GetCorrectValue()
        {
            var expected = 79234360917;
            _number.Number = expected;
            var actual = _number.Number;
            Assert.AreEqual(expected, actual, "Геттер Number возвращает неправильный номер телефона");
        }
    }
}
