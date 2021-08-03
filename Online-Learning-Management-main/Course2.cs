using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Course2 : Form
    {
        string id6;
        public Course2(string id)
        {
            InitializeComponent();
            id6 = id;
            textBox1.Text = id6;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Feature fe = new Feature(id6);
            fe.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // int i = 1;
                this.Hide();
                SView sv = new SView(id6);
                sv.Show();


            }
            else if (radioButton2.Checked)
            {
                //int i = 2;
               
                this.Hide();
                SView sv = new SView(id6);
                sv.Show();


            }
            else if (radioButton3.Checked)
            {
                //int i = 3;
                this.Hide();
                SView sv = new SView(id6);
                
                sv.Show();
            }
            else
            {
                MessageBox.Show("Please Select One");
            }
        }
    }
}
