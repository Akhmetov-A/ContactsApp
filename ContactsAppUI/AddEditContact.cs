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
    public partial class ContactForm : Form
    {
        public Contact contact { get; set; }
        PhoneNumber _phone = new PhoneNumber();

        public ContactForm()
        {
            InitializeComponent();
            BirthdateTimePicker.MaxDate = DateTime.Now;
        }

        private void AddEditContactForm_Load(object sender, EventArgs e)
        {
            if (contact != null)
            {
                SurnameTextBox.Text = contact.Surname;
                NameTextBox.Text = contact.Name;
                BirthdateTimePicker.Value = contact.BirthDay;
                PhoneTextBox.Text = Convert.ToString(contact.Phone.Number);
                EmailTextBox.Text = contact.Email;
                VkTextBox.Text = contact.IDvk;
            }
            else
            {
                contact = new Contact();
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                contact.Surname = SurnameTextBox.Text;
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
                contact.Name = NameTextBox.Text;
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
                contact.BirthDay = BirthdateTimePicker.Value;
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
                contact.Phone.Number = number;
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
                contact.Email = EmailTextBox.Text;
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
                contact.IDvk = VkTextBox.Text;
                VkTextBox.BackColor = Color.White;
            }
            catch (Exception)
            {
                VkTextBox.BackColor = Color.Salmon;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {                
                contact.Surname = SurnameTextBox.Text;
                contact.Name = NameTextBox.Text;
                contact.BirthDay = BirthdateTimePicker.Value;
                _phone.Number = System.Int64.Parse(PhoneTextBox.Text);
                contact.Phone = _phone;
                contact.Email = EmailTextBox.Text;
                contact.IDvk = VkTextBox.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
            } 
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
