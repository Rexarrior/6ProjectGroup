using System;
using System.IO;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class MainForm : Form
    {
        private PhoneBook _phoneBook;

        public MainForm()
        {
            InitializeComponent();
           
            _phoneBook = File.Exists(LiteralsConstants.Default_book_file_name) ?
                PhoneBook.LoadFromFile(LiteralsConstants.Default_book_file_name) :
                new PhoneBook(PhoneBook.BasicTypes);

            foreach (var person in _phoneBook.Persons)
            {
                personsListBox.Items.Add( person);
            }


            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = LiteralsConstants.Phone_book_extension;
            saveFileDialog1.Filter = LiteralsConstants.MainForm_SaveDialog_filter;

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.DefaultExt = LiteralsConstants.Phone_book_extension;
            openFileDialog1.Filter = LiteralsConstants.MainForm_OpenDialog_filter;




        }



        private void EditButtonClick(object sender, EventArgs e)
        {
            PersonEditForm editForm = new PersonEditForm();
            editForm.Owner = this;
            Person clone = (Person) ((Person) personsListBox.SelectedItem).Clone();
            editForm.Person = clone;
            editForm.RecordTypes = _phoneBook.RecordTypes;
            int index = _phoneBook.Persons.FindIndex(x => x.Equals(clone));
            editForm.FormClosed += (o, args) => this.Enabled = true;
            Enabled = false;

            DialogResult res = editForm.ShowDialog();

            if (res != DialogResult.OK) return;

            personsListBox.Items[personsListBox.SelectedIndex] = clone;
            _phoneBook.Persons[index] = clone;
            personsListBox.Update();


        }



        private void NewButtonClick(object sender, EventArgs e)
        {
            PersonEditForm editForm = new PersonEditForm();
            editForm.Owner = this;
            editForm.Person = new Person("Person name", "Comment");
            editForm.RecordTypes = _phoneBook.RecordTypes;
            this.Enabled = false;
            editForm.Closed += (o, args) => Enabled = true;

            DialogResult res = editForm.ShowDialog();

            if (res != DialogResult.OK) return;

            _phoneBook.AddPerson(editForm.Person);
            personsListBox.Items.Add(editForm.Person);


        }




        private void DeleteButtonClick(object sender, EventArgs args)
        {
            Person person = (Person) personsListBox.SelectedItem;
            if (person == null)
                return;
            personsListBox.Items.Remove(person);
            _phoneBook.Persons.Remove(person);
        }
          



        private void ImportButtonClick(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                try
                {
                    _phoneBook = PhoneBook.LoadFromFile(openFileDialog1.FileName);
                    foreach (var person in _phoneBook.Persons)
                    {
                        personsListBox.Items.Add(person);
                    }
                }
                catch (Exception exception)
                {
                    errorLabel.Visible = true;
                    errorLabel.Text += exception.Message;
                }
            }
        }




        private void ExportButtonClick(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                try
                {
                    _phoneBook.SaveToFile(saveFileDialog1.FileName);
                }
                catch (Exception exception)
                {
                    errorLabel.Visible = true;
                    errorLabel.Text += exception.Message;
                }
        }

        private void EditPersonButton_MouseMove(object sender, MouseEventArgs e)
        {
            editPersonButton.Enabled = personsListBox.SelectedItems.Count == 1;
        }

        private void personsListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            EditPersonButton_MouseMove(null, null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _phoneBook.SaveToFile(LiteralsConstants.Default_book_file_name);
        }
    }
}
