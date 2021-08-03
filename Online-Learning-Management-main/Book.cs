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
using System.IO;

namespace Project
{
    public partial class Book : Form
    {
        string id1;
        int book1;
        SqlConnection conn = null;
        SqlCommand cmd;
        public Book(string id,int book)
        {
            book1 = book;
            InitializeComponent();
            id1 = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (book1 == 1)
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                conn.Open();
               string query="select BOOk from BookDB where ID='1'";
               cmd = new SqlCommand(query, conn);
               cmd.ExecuteNonQuery();
               SqlDataAdapter adp = new SqlDataAdapter(cmd);
               DataSet ds = new DataSet();
               adp.Fill(ds);
               DataTable dt = ds.Tables[0];
               IDataReader dr = cmd.ExecuteReader();
                OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    axAcroPDF1.src = fd.FileName;
                }
                else
                {
                    MessageBox.Show("Select file");
                }
            }
            else if(book1==2)
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                conn.Open();
                OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    axAcroPDF1.src = fd.FileName;
                }
                else
                {
                    MessageBox.Show("Select file");
                }
            }
            else
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                conn.Open();
                OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    axAcroPDF1.src = fd.FileName;
                }
                else
                {
                    MessageBox.Show("Select file");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Course cs = new Course(id1);
            cs.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
    }
}
