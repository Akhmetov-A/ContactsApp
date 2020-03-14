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
            if (ProjectManager.Load(_path) != null)
            {
                _project = ProjectManager.Load(_path);
            }
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
            var addContactForm = new AddContact();
            var UpdatedData = addContactForm.Data;
            var i = addContactForm.ShowDialog();
            if (i == DialogResult.OK)
            {
                _project.Contacts.Add(UpdatedData._contactCurrent);
                ContactsListBox.Items.Add(UpdatedData.SurnameDisplay);
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
                AddContact addContactForm = new AddContact();
                addContactForm.Data._contactCurrent = _project.Contacts[ContactsListBox.SelectedIndex];
                addContactForm.Data.SurnameDisplay = _project.Contacts[ContactsListBox.SelectedIndex].Surname;
                addContactForm.ShowDialog();
                var UpdatedData = addContactForm.Data;
                _project.Contacts.RemoveAt(ContactsListBox.SelectedIndex);
                ContactsListBox.Items.RemoveAt(ContactsListBox.SelectedIndex);
                _project.Contacts.Add(UpdatedData._contactCurrent);
                ContactsListBox.Items.Add(UpdatedData.SurnameDisplay);
                SurnameTextBox.Text = UpdatedData._contactCurrent.Surname;
                NameTextBox.Text = UpdatedData._contactCurrent.Name;
                BirthdateTimePicker.Value = UpdatedData._contactCurrent.BirthDay;
                PhoneTextBox.Text = Convert.ToString(UpdatedData._contactCurrent.Phone.Number);
                EmailTextBox.Text = UpdatedData._contactCurrent.Email;
                VkTextBox.Text = UpdatedData._contactCurrent.IDvk;
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
                var i = MessageBox.Show("Удалить этот контакт?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (i == DialogResult.OK)
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

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FindTextBox.Text == "")
            {
                _project = ProjectManager.Load(_path);
                while (ContactsListBox.Items.Count != 0)

                {

                    ContactsListBox.Items.RemoveAt(0);

                }

                for (int i = 0; i != _project.Contacts.Count; i++)

                {

                    ContactsListBox.Items.Add(_project.Contacts[i].Surname);

                }
            }

            else
            {
                _project = ProjectManager.Load(_path);
                _sortProject = Project.Sort(_project, FindTextBox.Text);
                if (_sortProject == null)
                {
                    while (ContactsListBox.Items.Count != 0)
                    {
                        ContactsListBox.Items.RemoveAt(0);
                    }
                }
                else
                {
                    while (ContactsListBox.Items.Count != 0)
                    {
                        ContactsListBox.Items.RemoveAt(0);
                    }
                    for (int i = 0; i != _sortProject.Contacts.Count; i++)
                    {
                        ContactsListBox.Items.Add(_sortProject.Contacts[i].Surname);
                    }
                }
            }
        }
    }
}
