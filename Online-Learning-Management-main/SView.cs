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
    public partial class SView : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd;
        SqlDataReader dr;
        string id1;
        public SView(string id)
        {
            InitializeComponent();
            id1 = id;
            textBox2.Text = id1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Course2 cs2 = new Course2(id1);
            cs2.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }
        public void downloadFile(string file)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
            conn.Open();
            bool bol= false;
            using (cmd = new SqlCommand("select Question from FQuestionDB where ID='" + textBox1.Text + "'", conn))
            {
                using (dr = cmd.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        bol= true;
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
                    if(bol==false)
                    {
                        MessageBox.Show("No Data", "Erroe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                }

            }
        }
        public void UploadFile(String file)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-U2HGH3G;Initial Catalog=OnlineDB;Integrated Security=True");
            conn.Open();
            FileStream fs = File.OpenRead(file);
            byte[] contents = new byte[fs.Length];
            fs.Read(contents, 0, (int)fs.Length);
            fs.Close();
            using (cmd = new SqlCommand("insert into SAnwserDB(ID,Answer) values(@ID,@file)", conn))
            {
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue(@"file", contents);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Finished uploading File", "Diaglod dg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog  sf=new SaveFileDialog(){Filter="Text Doccument(*.pdf;) |*.pdf",ValidateNames = true})
            {
                if(sf.ShowDialog()==DialogResult.OK)
                {
                    DialogResult dr = MessageBox.Show("Are want to download this file!","Dialog dg" ,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(dr==DialogResult.Yes)
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dg = new OpenFileDialog() { Filter = "Text Documents (*.pdf;) |*.pdf", ValidateNames = true })
            {
                if (dg.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dr = MessageBox.Show("Are You want to upload this file?", "Dialog dg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
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
    }
}
