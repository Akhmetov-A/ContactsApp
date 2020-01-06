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
    public partial class MainForm : Form
    {
        private string _path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\json.txt";

        Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.Load(_path);
            foreach(Contact s in _project.Contacts)
            {
                ContactsListBox.Items.Add(s.Surname);
            }
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex >= 0) 
            {
                Contact _contactDisplay;
                _contactDisplay = _project.Contacts[ContactsListBox.SelectedIndex];
                SurnameTextBox.Text = _contactDisplay.Surname;
                NameTextBox.Text = _contactDisplay.Name;
                BirthdateTimePicker.Value = _contactDisplay.BirthDay;
                PhoneTextBox.Text = Convert.ToString(_contactDisplay.Phone.Number);
                EmailTextBox.Text = _contactDisplay.Email;
                VkTextBox.Text = _contactDisplay.IDvk;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form2 = new AddEditContactForm();
            var UpdatedData = form2.Data;
            var i = form2.ShowDialog();
            if (i==DialogResult.OK)
            {
                _project.Contacts.Add(UpdatedData._contactnew);
                ContactsListBox.Items.Add(UpdatedData.SurnameDisplay);
            }
            ProjectManager.SaveToFile(_project, _path);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            AddEditContactForm form2 = new AddEditContactForm();
            form2.Data._contactnew = _project.Contacts[ContactsListBox.SelectedIndex];
            form2.Data.SurnameDisplay = _project.Contacts[ContactsListBox.SelectedIndex].Surname;
            form2.ShowDialog();
            var UpdatedData = form2.Data;
            _project.Contacts.RemoveAt(ContactsListBox.SelectedIndex);
            ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
            _project.Contacts.Add(UpdatedData._contactnew);
            ContactsListBox.Items.Add(UpdatedData.SurnameDisplay);
            SurnameTextBox.Text = UpdatedData._contactnew.Surname;
            NameTextBox.Text = UpdatedData._contactnew.Name;
            BirthdateTimePicker.Value = UpdatedData._contactnew.BirthDay;
            PhoneTextBox.Text = Convert.ToString(UpdatedData._contactnew.Phone.Number);
            EmailTextBox.Text = UpdatedData._contactnew.Email;
            VkTextBox.Text = UpdatedData._contactnew.IDvk;
            ProjectManager.SaveToFile(_project, _path);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _project.Contacts.RemoveAt(ContactsListBox.SelectedIndex);
            ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
            SurnameTextBox.Clear();
            NameTextBox.Clear();
            BirthdateTimePicker.Value = BirthdateTimePicker.MaxDate;
            PhoneTextBox.Clear();
            EmailTextBox.Clear();
            VkTextBox.Clear();
            ProjectManager.SaveToFile(_project, _path);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new AddEditContactForm();
            var UpdatedData = form2.Data;
            var i = form2.ShowDialog();
            if (i == DialogResult.OK)
            {
                _project.Contacts.Add(UpdatedData._contactnew);
                ContactsListBox.Items.Add(UpdatedData.SurnameDisplay);
            }
            ProjectManager.SaveToFile(_project, _path);
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddEditContactForm form2 = new AddEditContactForm();
            form2.Data._contactnew = _project.Contacts[ContactsListBox.SelectedIndex];
            form2.Data.SurnameDisplay = _project.Contacts[ContactsListBox.SelectedIndex].Surname;
            form2.ShowDialog();
            var UpdatedData = form2.Data;
            _project.Contacts.RemoveAt(ContactsListBox.SelectedIndex);
            ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
            _project.Contacts.Add(UpdatedData._contactnew);
            ContactsListBox.Items.Add(UpdatedData.SurnameDisplay);
            SurnameTextBox.Text = UpdatedData._contactnew.Surname;
            NameTextBox.Text = UpdatedData._contactnew.Name;
            BirthdateTimePicker.Value = UpdatedData._contactnew.BirthDay;
            PhoneTextBox.Text = Convert.ToString(UpdatedData._contactnew.Phone.Number);
            EmailTextBox.Text = UpdatedData._contactnew.Email;
            VkTextBox.Text = UpdatedData._contactnew.IDvk;
            ProjectManager.SaveToFile(_project, _path);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _project.Contacts.RemoveAt(ContactsListBox.SelectedIndex);
            ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
            SurnameTextBox.Clear();
            NameTextBox.Clear();
            BirthdateTimePicker.Value = BirthdateTimePicker.MaxDate;
            PhoneTextBox.Clear();
            EmailTextBox.Clear();
            VkTextBox.Clear();
            ProjectManager.SaveToFile(_project, _path);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form3 = new AboutForm();
            form3.ShowDialog();
        }
    }
}
