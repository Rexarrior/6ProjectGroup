using CyberLife.Platform.World_content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberLife.Simple2DWorld
{
    public partial class MainForm : Form
    {
        public MainForm(Bitmap bitmap)
        {
            InitializeComponent();
            mapPicture.Image = bitmap;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
