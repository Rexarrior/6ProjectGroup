using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public void ShowMembers()
        {
            Members_list.Items.Clear();
            foreach(Member mb in members)
            {
                Members_list.Items.Add(mb);
            }
        }
        List<Member> members = new List<Member>() { };
        private void newMember_btn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Creating = true;
            Member mb = new Member();
            MembersForm mForm = new MembersForm();
            Properties.Settings.Default._member = mb;
            mForm.ShowDialog();                         // You get DialogResult there.  R.
            if (Properties.Settings.Default.IsOk)       // And you can use it there)   R.
            {
                members.Add(mb);
            }
            Properties.Settings.Default.IsOk = false;
            ShowMembers();
            
        }

        private void ChangeMember_btn_Click(object sender, EventArgs e)
        {
            if (Members_list.SelectedIndex == -1)
            {
                MessageBox.Show("Выбери контакт из списка");
            }
            else
            {
                Properties.Settings.Default.fail = false; 
                Properties.Settings.Default.Creating = false;
                Member mb = new Member();
                mb = (Member)Members_list.SelectedItem;
                Properties.Settings.Default._member = mb;
                MembersForm mForm = new MembersForm();
                mForm.ShowDialog();
                ShowMembers();
                Properties.Settings.Default.fail = false;
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            Members_list.Items.Clear();
            string searchingString = search_tb.Text;
            searchingString.ToLower();
            foreach(Member mb in members)
            {
                if (mb.ToString().ToLower().Contains(searchingString))
                {
                    Members_list.Items.Add(mb);
                }
            }
        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            if(search_tb.Text=="")
            {
                ShowMembers();
            }
        }
    }
}
