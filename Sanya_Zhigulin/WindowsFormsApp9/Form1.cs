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


namespace WindowsFormsApp9
{
    public partial class PhoneList : Form
    {

        public PhoneList()
        {
            InitializeComponent();
            
    }

        private void PhoneList_Load(object sender, EventArgs e)
        {
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //May be you will use an array??? List<button> fore example. And then use foreach for enumeration of array members. 
            /*Somewhere, where there are your global wariables:
             * List<Button> buttons;
             * List<TextBox> textBoxes;
             * Somewhere, where you are initializing your variables:
             * buttons = new List<Button>();
             * textBoxes = new List<TextBox>();
             * buttons.Add(c1); buttons.Add(c2);buttons.Add(c3)......;buttons.Add(c31);buttons.Add(c32);
             * textBoxes.Add(o1);textBoxes.Add(o2);textBoxes.Add(o3);........textBoxes.Add(o31);textBoxes.Add(o32);
             * There:
             * foreach (var button in buttons)
             * {
             *      if (!button.Visible)
             *       {
             *          button.Visible = true;
             *          break;
             * }
             * foreach (var textBox in textBoxes)
             * {
             *       if (!textBox.Visible)
             *       {
             *           textBox.Visible = true;
             *          break;                                                                                        
             *       } 
             * **************Rexarrior*********************************************************************************
             */
            if (c1.Visible == false)   // I suggest you use !c1.Visible instead of c1.Visible == false. R.
            {
                c1.Visible = true;
                o1.Visible = true;
                goto a;          
            }

            if (c2.Visible == false)
            {
                c2.Visible = true;
                o2.Visible = true;
                goto a;
            }
       
            if (c3.Visible == false)
            {
                c3.Visible = true;
                o3.Visible = true;
                goto a;
            }
            if (c4.Visible == false)
            {
                c4.Visible = true;
                o4.Visible = true;
                goto a;
            }
            if (c5.Visible == false)
            {
                c5.Visible = true;
                o5.Visible = true;
                goto a;
            }

            if (c6.Visible == false)
            {
                c6.Visible = true;
                o6.Visible = true;
                goto a;
            }
            if (c7.Visible == false)
            {
                c7.Visible = true;
                o7.Visible = true;
                goto a;
            }
            if (c8.Visible == false)
            {
                c8.Visible = true;
                o8.Visible = true;
                goto a;
            }
            if (c9.Visible == false)
            {
                c9.Visible = true;
                o9.Visible = true;
                goto a;
            }
            if (c10.Visible == false)
            {
                c10.Visible = true;
                o10.Visible = true;
                goto a;
            }
            if (c11.Visible == false)
            {
                c11.Visible = true;
                o11.Visible = true;
                goto a;
            }
            if (c12.Visible == false)
            {
                c12.Visible = true;
                o12.Visible = true;
                goto a;
            }
            if (c13.Visible == false)
            {
                c13.Visible = true;
                o13.Visible = true;
                goto a;
            }
            if (c14.Visible == false)
            {
                c14.Visible = true;
                o14.Visible = true;
                goto a;
            }
            if (c15.Visible == false)
            {
                c15.Visible = true;
                o15.Visible = true;
                goto a;
            }
            if (c16.Visible == false)
            {
                c16.Visible = true;
                o16.Visible = true;
                goto a;
            }
            if (c17.Visible == false)
            {
                c17.Visible = true;
                o17.Visible = true;
                goto a;
            }
            if (c18.Visible == false)
            {
                c18.Visible = true;
                o18.Visible = true;
                goto a;
            }
            if (c19.Visible == false)
            {
                c19.Visible = true;
                o19.Visible = true;
                goto a;
            }
            if (c20.Visible == false)
            {
                c20.Visible = true;
                o20.Visible = true;
                goto a;
            }
            if (c21.Visible == false)
            {
                c21.Visible = true;
                o21.Visible = true;
                goto a;
            }
            if (c22.Visible == false)
            {
                c22.Visible = true;
                o22.Visible = true;
                goto a;
            }
            if (c23.Visible == false)
            {
                c23.Visible = true;
                o23.Visible = true;
                goto a;
            }
            if (c24.Visible == false)
            {
                c24.Visible = true;
                o24.Visible = true;
                goto a;
            }
            if (c25.Visible == false)
            {
                c25.Visible = true;
                o25.Visible = true;
                goto a;
            }
            if (c26.Visible == false)
            {
                c26.Visible = true;
                o26.Visible = true;
                goto a;
            }
            if (c27.Visible == false)
            {
                c27.Visible = true;
                o27.Visible = true;
                goto a;
            }
            if (c28.Visible == false)
            {
                c28.Visible = true;
                o28.Visible = true;
                goto a;
            }
            if (c29.Visible == false)
            {
                c29.Visible = true;
                o29.Visible = true;
                goto a;
            }
            if (c30.Visible == false)
            {
                c30.Visible = true;
                o30.Visible = true;
                goto a;
            }
            if (c31.Visible == false)
            {
                c31.Visible = true;
                o31.Visible = true;
                goto a;
            }
            if (c32.Visible == false)
            {
                c32.Visible = true;
                o32.Visible = true;
                goto a;
            }
        a:;

        }

        private void button29_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void c1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e) // Сохранение
        {
            Properties.Settings.Default.c1 = o1.Text;
            Properties.Settings.Default.c2 = o2.Text;
            Properties.Settings.Default.c3 = o3.Text;
            Properties.Settings.Default.c4 = o4.Text;
            Properties.Settings.Default.c5 = o5.Text;
            Properties.Settings.Default.c6 = o6.Text;
            Properties.Settings.Default.c7 = o7.Text;
            Properties.Settings.Default.c8 = o8.Text;
            Properties.Settings.Default.c9 = o9.Text;
            Properties.Settings.Default.c10 = o10.Text;
            Properties.Settings.Default.c11 = o11.Text;
            Properties.Settings.Default.c12 = o12.Text;
            Properties.Settings.Default.c13 = o13.Text;
            Properties.Settings.Default.c14 = o14.Text;
            Properties.Settings.Default.c15 = o15.Text;
            Properties.Settings.Default.c16 = o16.Text;
            Properties.Settings.Default.c17 = o17.Text;
            Properties.Settings.Default.c18 = o18.Text;
            Properties.Settings.Default.c19 = o19.Text;
            Properties.Settings.Default.c20 = o20.Text;
            Properties.Settings.Default.c21 = o21.Text;
            Properties.Settings.Default.c22 = o22.Text;
            Properties.Settings.Default.c23 = o23.Text;
            Properties.Settings.Default.c24 = o24.Text;
            Properties.Settings.Default.c25 = o25.Text;
            Properties.Settings.Default.c26 = o26.Text;
            Properties.Settings.Default.c27 = o27.Text;
            Properties.Settings.Default.c28 = o28.Text;
            Properties.Settings.Default.c29 = o29.Text;
            Properties.Settings.Default.c30 = o30.Text;
            Properties.Settings.Default.c31 = o31.Text;
            Properties.Settings.Default.c32 = o32.Text;
            Properties.Settings.Default.Save();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            c1.Text = Properties.Settings.Default.c1;
            c2.Text = Properties.Settings.Default.c2;
            c3.Text = Properties.Settings.Default.c3;
            c4.Text = Properties.Settings.Default.c4;
            c5.Text = Properties.Settings.Default.c5;
            c6.Text = Properties.Settings.Default.c6;
            c7.Text = Properties.Settings.Default.c7;
            c8.Text = Properties.Settings.Default.c8;
            c9.Text = Properties.Settings.Default.c9;
            c10.Text = Properties.Settings.Default.c10;
            c11.Text = Properties.Settings.Default.c11;
            c12.Text = Properties.Settings.Default.c12;
            c13.Text = Properties.Settings.Default.c13;
            c14.Text = Properties.Settings.Default.c14;
            c15.Text = Properties.Settings.Default.c15;
            c16.Text = Properties.Settings.Default.c16;
            c17.Text = Properties.Settings.Default.c17;
            c18.Text = Properties.Settings.Default.c18;
            c19.Text = Properties.Settings.Default.c19;
            c20.Text = Properties.Settings.Default.c20;
            c21.Text = Properties.Settings.Default.c21;
            c22.Text = Properties.Settings.Default.c22;
            c23.Text = Properties.Settings.Default.c23;
            c24.Text = Properties.Settings.Default.c24;
            c25.Text = Properties.Settings.Default.c25;
            c26.Text = Properties.Settings.Default.c26;
            c27.Text = Properties.Settings.Default.c27;
            c28.Text = Properties.Settings.Default.c28;
            c29.Text = Properties.Settings.Default.c29;
            c30.Text = Properties.Settings.Default.c30;
            c31.Text = Properties.Settings.Default.c31;
            c32.Text = Properties.Settings.Default.c32;
        }

        private void button2_Click(object sender, EventArgs e) // Удаление контактов
        {
            if (c32.Visible == true)  // I suggest you use c1.Visible instead of c1.Visible == true. R.
            {
                c32.Visible = false;
                o32.Visible = false;
                goto a;
            }
            if (c31.Visible == true)
            {
                c31.Visible = false;
                o31.Visible = false;
                goto a;
            }
            if (c30.Visible == true)
            {
                c30.Visible = false;
                o30.Visible = false;
                goto a;
            }
            if (c29.Visible == true)
            {
                c29.Visible = false;
                o29.Visible = false;
                goto a;
            }
            if (c28.Visible == true)
            {
                c28.Visible = false;
                o28.Visible = false;
            }
            if (c27.Visible == true)
            {
                c27.Visible = false;
                o27.Visible = false;
                goto a;
            }
            if (c26.Visible == true)
            {
                c26.Visible = false;
                o26.Visible = false;
                goto a;
            }
            if (c25.Visible == true)
            {
                c25.Visible = false;
                o25.Visible = false;
                goto a;
            }
            if (c24.Visible == true)
            {
                c24.Visible = false;
                o24.Visible = false;
                goto a;
            }
            if (c23.Visible == true)
            {
                c23.Visible = false;
                o23.Visible = false;
                goto a;
            }
            if (c22.Visible == true)
            {
                c22.Visible = false;
                o22.Visible = false;
                goto a;
            }
            if (c21.Visible == true)
            {
                c21.Visible = false;
                o21.Visible = false;
                goto a;
            }
            if (c20.Visible == true)
            {
                c20.Visible = false;
                o20.Visible = false;
                goto a;
            }
            if (c19.Visible == true)
            {
                c19.Visible = false;
                o19.Visible = false;
                goto a;
            }
            if (c18.Visible == true)
            {
                c18.Visible = false;
                o18.Visible = false;
                goto a;
            }
            if (c17.Visible == true)
            {
                c17.Visible = false;
                o17.Visible = false;
                goto a;
            }
            if (c16.Visible == true)
            {
                c16.Visible = false;
                o16.Visible = false;
                goto a;
            }
            if (c15.Visible == true)
            {
                c15.Visible = false;
                o15.Visible = false;
                goto a;
            }
            if (c14.Visible == true)
            {
                c14.Visible = false;
                o14.Visible = false;
                goto a;
            }
            if (c13.Visible == true)
            {
                c13.Visible = false;
                o13.Visible = false;
                goto a;
            }
            if (c12.Visible == true)
            {
                c12.Visible = false;
                o12.Visible = false;
                goto a;
            }
            if (c11.Visible == true)
            {
                c11.Visible = false;
                o11.Visible = false;
                goto a;
            }
            if (c10.Visible == true)
            {
                c10.Visible = false;
                o10.Visible = false;
                goto a;
            }
            if (c9.Visible == true)
            {
                c9.Visible = false;
                o9.Visible = false;
                goto a;
            }
            if (c8.Visible == true)
            {
                c8.Visible = false;
                o8.Visible = false;
                goto a;
            }
            if (c7.Visible == true)
            {
                c7.Visible = false;
                o7.Visible = false;
                goto a;
            }
            if (c6.Visible == true)
            {
                c6.Visible = false;
                o6.Visible = false;
                goto a;
            }
            if (c5.Visible == true)
            {
                c5.Visible = false;
                o5.Visible = false;
                goto a;
            }
            if (c4.Visible == true)
            {
                c4.Visible = false;
                o4.Visible = false;
                goto a;
            }
            if (c3.Visible == true)
            {
                c3.Visible = false;
                o3.Visible = false;
                goto a;
            }
            if (c2.Visible == true)
            {
                c2.Visible = false;
                o2.Visible = false;
                goto a;
            }
            if (c1.Visible == true)
            {
                c1.Visible = false;
                o1.Visible = false;
                goto a;
            }
        a:;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
