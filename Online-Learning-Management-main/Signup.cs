using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class Signup : Form
    {
        SqlConnection conn = null;

        public Signup()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("SIGNUP SUCCESSFUL!!");
            if (radioButton1.Checked)
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                {
                    MessageBox.Show("Please fill the form");
                }
                else if (textBox3.Text != null)
                {
                    string uname = textBox1.Text;
                    string email = textBox2.Text;
                    string password = textBox3.Text;
                    try
                    {
                        conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                        conn.Open();
                        string query = "insert into Signup(Uname,Email,[password])"
                        + " VALUES('" + uname + "','" + email + "','" + password + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("SIGNUP SUCCESSFUL!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                {
                    MessageBox.Show("Please fill the form");
                }
                else if (textBox3.Text != null)
                {
                    string uname = textBox1.Text;
                    string email = textBox2.Text;
                    string password = textBox3.Text;
                    try
                    {
                        conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                        conn.Open();

                        string query = "insert into Signup1DB(Uname,Email,[password])"
                        + " VALUES('" + uname + "','" + email + "','" + password + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("SIGNUP SUCCESSFUL!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }
    }
}
