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
    public partial class Course : Form
    {
        string id4;
        
        public Course(string id3)
        {
            InitializeComponent();
            id4 = id3;
            idbox.Text = id4;
             
            
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
                int i = 3;
                this.Hide();
                Book c = new Book(id4,i);
                c.Show();
                
                
            }
            else if (radioButton2.Checked)
            {
                int i = 2;
                this.Hide();
                Book java = new Book(id4,i);
                java.Show();
                
                
            }
            else if (radioButton3.Checked)
            {
                int i = 1;
                this.Hide();
                Book csharp = new Book(id4,i);
                csharp.Show();
            }
            else
            {
                MessageBox.Show("Please Select One");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           Feature fe = new Feature(id4);
            fe.Show();
        }

        private void Course_Load(object sender, EventArgs e)
        {

        }
    }
}
