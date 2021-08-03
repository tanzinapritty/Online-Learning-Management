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
    public partial class Course1 : Form
    {
        string id3;
        public Course1(string id1)
        {
            InitializeComponent();
             id3 = id1;
            textBox1.Text = id3;
        }

        private void Course1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // int i = 1;
                this.Hide();
                Fview fv = new Fview(id3);
                fv.Show();


            }
            else if (radioButton2.Checked)
            {
                //int i = 2;
                this.Hide();
                Fview fv = new Fview(id3);
                fv.Show();


            }
            else if (radioButton3.Checked)
            {
                //int i = 3;
                this.Hide();
                Fview fv = new Fview(id3);
                fv.Show();
            }
            else
            {
                MessageBox.Show("Please Select One");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
