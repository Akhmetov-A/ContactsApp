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
    public partial class AddEditContactForm : Form
    {

        Contact _contactnew = new Contact();
        PhoneNumber _phone = new PhoneNumber();

        public AddEditContactForm()
        {
            InitializeComponent();
            BirthdateTimePicker.MaxDate = DateTime.Now;
        }

        private void AddEditContactForm_Load(object sender, EventArgs e)
        {
            if (Data._contactnew != null)
            {
                SurnameTextBox.Text = Data._contactnew.Surname;
                NameTextBox.Text = Data._contactnew.Name;
                BirthdateTimePicker.Value = Data._contactnew.BirthDay;
                PhoneTextBox.Text = Convert.ToString(Data._contactnew.Phone.Number);
                EmailTextBox.Text = Data._contactnew.Email;
                VkTextBox.Text = Data._contactnew.IDvk;
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactnew.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                SurnameTextBox.BackColor = Color.Red;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactnew.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                NameTextBox.BackColor = Color.Red;
            }
        }

        private void BirthdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contactnew.BirthDay = BirthdateTimePicker.Value;
                BirthdateTimePicker.BackColor = Color.White;
            }
            catch (Exception)
            {
                BirthdateTimePicker.BackColor = Color.Red;
            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneTextBox.Text, out number);
                _contactnew.Phone.Number = number;
                PhoneTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhoneTextBox.BackColor = Color.Red;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactnew.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                EmailTextBox.BackColor = Color.Red;
            }
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactnew.IDvk = VkTextBox.Text;
                VkTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                VkTextBox.BackColor = Color.Red;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool flague;
            try
            {
                flague = true;
                _contactnew.Surname = SurnameTextBox.Text;
                _contactnew.Name = NameTextBox.Text;
                _contactnew.BirthDay = BirthdateTimePicker.Value;
                _phone.Number = System.Int64.Parse(PhoneTextBox.Text);
                _contactnew.Phone = _phone;
                _contactnew.Email = EmailTextBox.Text;
                _contactnew.IDvk = VkTextBox.Text;
                Data.SurnameDisplay = _contactnew.Surname;
                Data._contactnew = _contactnew;
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

        public class DataInMainForm
        {
            public string SurnameDisplay;
            public Contact _contactnew;
        }

        public DataInMainForm Data { get; set; } = new DataInMainForm();

       
    }
}
