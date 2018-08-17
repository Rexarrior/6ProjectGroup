using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class PersonEditForm : Form
    {
        public Person Person;
        public HashSet<RecordType> RecordTypes;

        public PersonEditForm()
        {
            InitializeComponent();
        }



        private void NewButton_Click(object sender, EventArgs e)
        {
            RecordEditForm form = new RecordEditForm();
            form.Owner = this;
            Enabled = false;
            form.RecordTypes = RecordTypes;
            form.Closed += (o, args) => Enabled = true;
            form.Record = new Record(new NoTypeRecord(), "Caption", "Value");
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                Person.Add(form.Record.Caption, form.Record);
                recordListBox.Items.Add(form.Record);

            }



        }



        private void EditButton_Click(object sender, EventArgs e)
        {
            RecordEditForm form = new RecordEditForm();
            form.Owner = this;
            Enabled = false;
            form.Closed += (o, args) => Enabled = true;
            form.RecordTypes = RecordTypes;


            form.Record = (Record)((Record)recordListBox.SelectedItem).Clone();
            string caption = form.Record.Caption;

            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                Person.Remove(caption);
                Person.Add(form.Record.Caption, form.Record);
                recordListBox.Items[recordListBox.SelectedIndex] = form.Record;

            }



        }



        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Record rec = (Record) recordListBox.SelectedItem;
            if (rec == null)
                return;
            
            Person.Remove(rec.Caption);
            recordListBox.Items.RemoveAt(recordListBox.SelectedIndex);
        }



        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Person.Name = nameTextBox.Text;
            this.Person.Comment = commentTextBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }



        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }



        private void PersonEditForm_Shown(object sender, EventArgs e)
        {
            nameTextBox.Text = Person.Name;
            commentTextBox.Text = Person.Comment;
            foreach (var record in Person.Values)
            {
                recordListBox.Items.Add(record);
            }



        }

        private void EditButton_MouseMove(object sender, MouseEventArgs e)
        {
            editButton.Enabled =  recordListBox.SelectedItems.Count == 1;
        }

        private void RecordListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            EditButton_MouseMove(null, null);
        }
    }
}
