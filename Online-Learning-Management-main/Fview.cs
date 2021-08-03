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
    public partial class Fview : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd;
        SqlDataReader dr;
        string id5;
        public Fview(string id4)
        {
            InitializeComponent();
            id5 = id4;
            textBox2.Text = id5;
        }

        public void UploadFile(String file)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
            conn.Open();
            FileStream fs = File.OpenRead(file);
            byte[] contents = new byte[fs.Length];
            fs.Read(contents, 0, (int)fs.Length);
            fs.Close();
            using (cmd = new SqlCommand("insert into FQuestionDB(ID,Question) values(@ID,@file)", conn))
            {
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue(@"file", contents);
                cmd.ExecuteNonQuery();
            }
           
            MessageBox.Show("Finished uploading File","Diaglod dg", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void UploadBook(String file1)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
            conn.Open();
            FileStream fs = File.OpenRead(file1);
            byte[] contents = new byte[fs.Length];
            fs.Read(contents, 0, (int)fs.Length);
            fs.Close();
            using (cmd = new SqlCommand("insert into BookDB(ID,BOOK) values(@ID,@BOOK)", conn))
            {
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue(@"BOOK", contents);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Finished uploading Book", "Diaglod dg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void downloadFile(string file)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
            conn.Open();
            bool bol = false;
            using (cmd = new SqlCommand("select Answer from SAnwserDB where ID='" + textBox1.Text + "'", conn))
            {
                using (dr = cmd.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        bol = true;
                        byte[] fileData = (byte[])dr.GetValue(0);
                        using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
                        {
                            using (BinaryWriter bw = new BinaryWriter(fs))
                            {
                                bw.Write(fileData);
                                bw.Close();

                            }
                        }
                        MessageBox.Show("Finished Download", "Dialog dg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (bol == false)
                    {
                        MessageBox.Show("No Data", "Erroe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Course1 cs = new Course1(id5);
            cs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dg = new OpenFileDialog() {Filter = "Text Documents (*.pdf;) |*.pdf",ValidateNames = true})
            {
                if (dg.ShowDialog()==DialogResult.OK)
                {
                    DialogResult dr = MessageBox.Show("Are You want to upload this file?", "Dialog dg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dr==DialogResult.Yes)
                    {
                        string fileName = dg.FileName;
                        UploadFile(fileName);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog() { Filter = "Text Doccument(*.pdf;) |*.pdf", ValidateNames = true })
            {

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dr = MessageBox.Show("Do You want to download this file!", "Dialog dg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        string filename = sf.FileName;
                        downloadFile(filename);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void Fview_Load(object sender, EventArgs e)
        {
           // display();
            //this.Initialize();
            this.srchDisplay();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dg = new OpenFileDialog() { Filter = "Text Documents (*.pdf;) |*.pdf", ValidateNames = true })
            {
                if (dg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dr = MessageBox.Show("Do you want to upload this BOOK?", "Dialog dg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        string fileName = dg.FileName;
                        UploadBook(fileName);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //string id = dataGridView1.Rows[e.RowIndex].Cells["dgvID"].Value.ToString();
            
        }

        private void srchDisplay(string id)
        {
            throw new NotImplementedException();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // string valueToSearch = textBox1.Text.ToString();
            this.srchDisplay();
        }
        public void srchDisplay()
        {
            try
            {
                
                conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
                conn.Open();
                string query = "Select ID from SAnwserDB ";
                if (string.IsNullOrEmpty(textBox1.Text) == false)
                    query += " where ID like '%" + textBox1.Text + "%'";
                SqlCommand sq = new SqlCommand(query,conn);
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
       

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            RESULT Re = new RESULT(id5);
            Re.Show();
        }
    }
}
