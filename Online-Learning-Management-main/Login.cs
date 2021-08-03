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
    public partial class Login : Form
    {
        SqlConnection conn = null;
        int i;
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup su = new Signup();
            su.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                /* MessageBox.Show("LOGIN SUCCESSFUL!!");
                 this.Hide();
                 Feature fe = new Feature();
                 fe.Show();
                 */
                if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Please fill the form");
                }
                else
                {
                    try
                    {
                        conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                        conn.Open();
                        string query = "select Password ,ID from Signup where Email='" + textBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        IDataReader dr = cmd.ExecuteReader();
                        i = Convert.ToInt32(dt.Rows.Count.ToString());
                        if (i == 0)
                        {
                            MessageBox.Show("Check Email And password");
                        }
                        else
                        {
                            if (dr.Read())
                            {
                                string id = (dr["ID"].ToString());
                                MessageBox.Show("LOGIN SUCCESSFUL!!");
                                this.Hide();
                                Feature fe = new Feature(id);
                                fe.Show();
                            }
                        }
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
            }
            else
            {
                 if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Please fill the form");
                }
                else
                {
                    try
                    {
                        conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                        conn.Open();
                        string query = "select Password ,ID from Signup1DB where Email='" + textBox1.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        IDataReader dr = cmd.ExecuteReader();
                        i = Convert.ToInt32(dt.Rows.Count.ToString());
                        if (i == 0)
                        {
                            MessageBox.Show("Check Email And password");
                        }
                        else
                        {
                            if (dr.Read())
                            {
                                string id = (dr["ID"].ToString());
                                MessageBox.Show("LOGIN SUCCESSFUL!!");
                                this.Hide();
                                Course1 cs1 = new Course1(id);
                                cs1.Show();
                            }
                        }
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
            }
            }
        }

      
    }

