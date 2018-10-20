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
using System.Threading;

namespace CyberLife.Simple2DWorld
{
    public partial class MainForm : Form
    {
        public bool IsLoading;
        Simple2DWorld world;
        public MainForm(World simple2DWorld)
        {
            world = (Simple2DWorld)simple2DWorld;
            InitializeComponent();
            mapPicture.Height = world.Size.Height;
            mapPicture.Width = world.Size.Width;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            while (true)
            {
                mapPicture.Width++;
                mapPicture.Height++;
                if (mapPicture.Width  +500> this.Width || mapPicture.Height +100 > this.Height)
                {
                    mapPicture.Width--;
                    mapPicture.Height--;
                    break;
                }
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        Changed changed;
        public void UpdateMap()
        {
            while (true)
            {
                world.Update();
                Invoke("Кол-во форм жизни " + world.LifeForms.Count.ToString() + 
                    "\r\nКол-во органики " + world.Organic.Count.ToString() + 
                    "\r\nТекущий ход " + world.Age.ToString()+ 
                    "\r\nТекущий сезон "+((SeasonsPhenomen) world.NaturalPhenomena["SeasonsPhenomen"]).CurSeason.ToString(), ((Simple2dVisualizer)world.Visualizer).Map);
            }
        }

        private void mapPicture_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(UpdateMap);
            thread.Start();

        }
        delegate void Changed(string str, Bitmap map);
        public void Invoke(string str, Bitmap map)
        {
            changed = new Changed(Change);
            
            statsLabel.Invoke(changed, new object[] { str,map });
        }
        public void Change(string str,Bitmap map)
        {
            statsLabel.Text = str;
            mapPicture.Image = map;
        }

        private void ColorTypeButton_Click(object sender, EventArgs e)
        {
            foreach(var bot in world.LifeForms.Values)
            {
             ((ColorState) world.States["ColorState"]).ColorType = ColorType.EnergyDisplay; // пофиксить отображение энергии в colorstate,пока что все желтые
                    
            }
        }
    }
}
