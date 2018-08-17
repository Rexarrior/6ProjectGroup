using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class RecordEditForm : Form
    {
        public Record Record;
        public HashSet<RecordType> RecordTypes;

        public RecordEditForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButton_MouseMove(null, null);
            if (SaveButton.Enabled)
            {

                RecordType type =  typeRecordBox.SelectedItem is string
                    ? new RecordType(recordTypeNameTextBox.Text, recordTypeFilterTextBox.Text)
                    : (RecordType) typeRecordBox.SelectedItem;

                if (Record.Type.Equals(type))
                {
                    Record.Caption = captionTextBox.Text;
                    Record.Value = valueTextBox.Text;
                }
                else
                {
                    Record = new Record(type, captionTextBox.Text, valueTextBox.Text);
                }

                DialogResult = DialogResult.OK;
                Close();
            }

        }




        private void SaveButton_MouseMove(object sender, MouseEventArgs e)
        {
            RecordType type = typeRecordBox.SelectedItem is string
                ? new RecordType(recordTypeNameTextBox.Text, recordTypeFilterTextBox.Text)
                : (RecordType)typeRecordBox.SelectedItem;

            SaveButton.Enabled = type.Verify(valueTextBox.Text);
        }



        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private void TypeRecordBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeRecordBox.SelectedItem is string)
            {
                recordTypeNameTextBox.Visible = true;
                recordTypeFilterTextBox.Visible = true;
            }
            else
            {
                recordTypeFilterTextBox.Visible = false;
                recordTypeNameTextBox.Visible = false;
            }

        }




        private void RecordEditForm_Shown(object sender, EventArgs e)
        {
            foreach (var recordType in RecordTypes)
            {
                typeRecordBox.Items.Add(recordType);
            }

            typeRecordBox.Items.Add("Custom type");
            typeRecordBox.SelectedItem = typeRecordBox.Items[0];

            captionTextBox.Text = Record.Caption;
            valueTextBox.Text = Record.Value;
        }




        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveButton_MouseMove(null,null);
        }
    }
}
