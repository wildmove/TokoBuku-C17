using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TokoBuku_C17
{
    public partial class Form3 : Form
    {
        private string stringConnection = "data source=DESKTOP-7VKCCI7\\REZA ; database=TokoBuku;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Form3()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void refreshform()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
        }

        private void dataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = "SELECT id_kasir, nama_kasir, jk_kasir FROM dbo.kasir";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idKasir = textBox1.Text;
            string nmKasir = textBox2.Text;
            string jkKasir = textBox4.Text;


            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO dbo.Kasir (id_kasir, nama_kasir, jk_kasir)" + "VALUES(@id_kasir, @nama_kasir, @jk_kasir)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_kasir", idKasir));
                cmd.Parameters.Add(new SqlParameter("@nama_kasir", nmKasir));
                cmd.Parameters.Add(new SqlParameter("@jk_kasir", jkKasir));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                refreshform();

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idKasir = textBox1.Text;
            string nmKasir = textBox2.Text;
            string jkKasir = textBox4.Text;


            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "UPDATE kasir SET nama_kasir = @nama_kasir, jk_kasir = @jk_kasir WHERE id_kasir = @id_kasir";
                SqlCommand command = new SqlCommand(str, koneksi);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@id_kasir", idKasir));
                command.Parameters.Add(new SqlParameter("@nama_kasir", nmKasir));
                command.Parameters.Add(new SqlParameter("@jk_kasir", jkKasir));
                command.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data Berhasil Diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshform();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string idKasir = textBox1.Text;

            if (textBox1.Text == "" )
            {
                MessageBox.Show("Masukkan Data ID Kasir", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " delete from [kasir] where id_kasir = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                textBox1.Text = "";
                MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 nm = new Form1();
            nm.Show();
            this.Hide();
        }
    }
}
