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
    public partial class MembersForm : Form
    {
        public MembersForm()
        {
            InitializeComponent();
        }
        Member mb = new Member();
        private void MembersForm_Load(object sender, EventArgs e)
        {

            mb =(Member) Properties.Settings.Default._member;
            this.Text = mb.ToString();
            if (Properties.Settings.Default.Creating) { }
            else
            {
                firstName_tb.Text = mb.FirstName;
                LastName_tb.Text = mb.LastName;
                number_tb.Text = mb.Number;
                info_tb.Text = mb.Info;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            mb.FirstName = firstName_tb.Text;
            mb.LastName = LastName_tb.Text;
            mb.Number = number_tb.Text;
            mb.Info = info_tb.Text;
            if(Properties.Settings.Default.IsOk && !Properties.Settings.Default.fail)
            {
                this.Close();
            }
        }
    }
}
