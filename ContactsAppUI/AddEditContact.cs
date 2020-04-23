using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    //TODO: неправильное название - из названия непонятно, что это форма, и глаголы в названии не нужны
    public partial class AddContact : Form
    {

        Contact _contactCurrent = new Contact();
        PhoneNumber _phone = new PhoneNumber();

        public AddContact()
        {
            InitializeComponent();
            BirthdateTimePicker.MaxDate = DateTime.Now;
        }

        private void AddEditContactForm_Load(object sender, EventArgs e)
        {
            if (Data._contactCurrent != null)
            {
                SurnameTextBox.Text = Data._contactCurrent.Surname;
                NameTextBox.Text = Data._contactCurrent.Name;
                BirthdateTimePicker.Value = Data._contactCurrent.BirthDay;
                PhoneTextBox.Text = Convert.ToString(Data._contactCurrent.Phone.Number);
                EmailTextBox.Text = Data._contactCurrent.Email;
                VkTextBox.Text = Data._contactCurrent.IDvk;
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactCurrent.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                SurnameTextBox.BackColor = Color.Salmon;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactCurrent.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                NameTextBox.BackColor = Color.Salmon;
            }
        }

        private void BirthdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contactCurrent.BirthDay = BirthdateTimePicker.Value;
                BirthdateTimePicker.BackColor = Color.White;
            }
            catch (Exception)
            {
                BirthdateTimePicker.BackColor = Color.Salmon;
            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneTextBox.Text, out number);
                _contactCurrent.Phone.Number = number;
                PhoneTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhoneTextBox.BackColor = Color.Salmon;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactCurrent.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                EmailTextBox.BackColor = Color.Salmon;
            }
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactCurrent.IDvk = VkTextBox.Text;
                VkTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                VkTextBox.BackColor = Color.Salmon;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            //TODO: вместо флага лучше сделать return
            bool flague;
            try
            {
                flague = true;
                _contactCurrent.Surname = SurnameTextBox.Text;
                _contactCurrent.Name = NameTextBox.Text;
                _contactCurrent.BirthDay = BirthdateTimePicker.Value;
                _phone.Number = System.Int64.Parse(PhoneTextBox.Text);
                _contactCurrent.Phone = _phone;
                _contactCurrent.Email = EmailTextBox.Text;
                _contactCurrent.IDvk = VkTextBox.Text;
                Data.SurnameDisplay = _contactCurrent.Surname;
                Data._contactCurrent = _contactCurrent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
                flague = false;
            }
            if (flague == true) 
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //TODO: этот класс не нужен. Должно быть просто свойство типа Contact
        public class DataInMainForm
        {
            public string SurnameDisplay;
            public Contact _contactCurrent;
        }

        public DataInMainForm Data { get; set; } = new DataInMainForm();

    }
}
