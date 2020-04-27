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
        private string _path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Contacts.txt";

        private Project _project = new Project();
        private Project _sortProject = new Project();

        public MainForm()
        {
            InitializeComponent();
            BirthdateTimePicker.MaxDate = DateTime.Now;
            _project = ProjectManager.Load(_path);
            foreach (Contact s in _project.Contacts)
            {
                ContactsListBox.Items.Add(s.Surname);
            }
            ContactsListBox.Sorted = true;

            Project birth = Project.Birthday(_project, DateTime.Today);
            for (int i = 0; i != birth.Contacts.Count; i++)
            {
                BirthdayTodayLabel.Text = BirthdayTodayLabel.Text + "Сегодня день рождения:\n"+birth.Contacts[i].Surname + ".";
            }
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex >= 0) 
            {
                Contact contact;
                contact = _project.Contacts[ContactsListBox.SelectedIndex];
                Assignment(contact);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectManager.SaveToFile(_project, _path);
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var abouForm = new AboutForm();
            abouForm.ShowDialog();
        }

        public void Add()
        {
            var addContactForm = new ContactForm();
            var UpdatedData = addContactForm;
            var i = addContactForm.ShowDialog();
            if (i == DialogResult.OK)
            {
                _project.Contacts.Add(UpdatedData.contact);
                ContactsListBox.Items.Add(UpdatedData.contact.Surname);
                _project.Sort(_project.Contacts);
            }
            ProjectManager.SaveToFile(_project, _path);
        }

        public void Edit()
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт для редактирования", "Отсутствие контакта");
            }
            else
            {
                ContactForm addContactForm = new ContactForm();
                addContactForm.contact = _project.Contacts[ContactsListBox.SelectedIndex];
                addContactForm.contact.Surname = _project.Contacts[ContactsListBox.SelectedIndex].Surname;
                addContactForm.ShowDialog();
                var UpdatedData = addContactForm.contact;
                _project.Contacts.RemoveAt(ContactsListBox.SelectedIndex);
                ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
                _project.Contacts.Add(UpdatedData);
                ContactsListBox.Items.Add(UpdatedData.Surname);
                Assignment(UpdatedData);
                _project.Sort(_project.Contacts);
                ProjectManager.SaveToFile(_project, _path);
            }
        }

        public void Remove()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт для удаления ", "Отсутствие записи");
            }
            else
            {
                var deleteItem = MessageBox.Show("Удалить этот контакт?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (deleteItem == DialogResult.OK)
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
            }
        }

        public void Assignment (Contact contact)
        {
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdateTimePicker.Value = contact.BirthDay;
            PhoneTextBox.Text = Convert.ToString(contact.Phone.Number);
            EmailTextBox.Text = contact.Email;
            VkTextBox.Text = contact.IDvk;
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            ContactsListBox.DataSource = null;
            ContactsListBox.DataSource = _project.Sort(_project.Contacts);
            ContactsListBox.DisplayMember = "Surname";
            ProjectManager.SaveToFile(_project, _path);
        }
    }
}
