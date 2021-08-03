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
    public partial class RESULT : Form
    {
        SqlConnection conn = null;
       // SqlCommand cmd;
        public RESULT(string id6)
        {
            InitializeComponent();
            string id7 = id6;
            textBox1.Text = id7;
        }
        public void srchDisplay()
        {
            try
            {

                conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                conn.Open();
                string query = "Select ID from ResultDB ";
                if (string.IsNullOrEmpty(textBox1.Text) == false)
                    query += " where ID like '%" + textBox1.Text + "%'";
                SqlCommand sq = new SqlCommand(query, conn);
                SqlDataAdapter adp = new SqlDataAdapter(sq);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void btnNew_Click(object sender, EventArgs e)
        {
             
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
        
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.srchDisplay();   
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            
        }
       
        

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RESULT_Load(object sender, EventArgs e)
        {
            this.srchDisplay();
        }
    }
}
