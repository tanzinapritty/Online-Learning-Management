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
    public partial class Feature : Form
    {
        string id2;
        public Feature(string id1)
        {
            InitializeComponent();
             id2 = id1;
            textBox1.Text = id2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if(radioButton1.Checked)
            {
                this.Hide();
                Course cs = new Course(id2);
                cs.Show();
            }
            else if (radioButton2.Checked)
            {
                this.Hide();
                Course2 cs = new Course2(id2);
                cs.Show();
            }
            else
            {
                MessageBox.Show("Please Select One");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Feature_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
