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

namespace TokoBuku_C17
{
    public partial class Form4 : Form
    {
        private string stringConnection = "data source=DESKTOP-7VKCCI7\\REZA ; database=TokoBuku;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Form4()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }
        private void refreshform()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
        }

        private void dataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = "SELECT id_pembeli, nama_pembeli, telp_pembeli, alamat_pembeli, jenis_kelamin FROM dbo.pembeli";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idPembeli = textBox1.Text;
            string nmPembeli = textBox2.Text;
            string noTelpPembeli = textBox3.Text;
            string alamatPembeli = textBox4.Text;
            string jkPembeli = textBox5.Text;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO dbo.pembeli (id_pembeli, nama_pembeli, telp_pembeli, alamat_pembeli, jenis_kelamin)" + "VALUES(@id_pembeli, @nama_pembeli, @telp_pembeli, @alamat_pembeli, @jenis_kelamin)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_pembeli", idPembeli));
                cmd.Parameters.Add(new SqlParameter("@nama_pembeli", nmPembeli));
                cmd.Parameters.Add(new SqlParameter("@telp_pembeli", noTelpPembeli));
                cmd.Parameters.Add(new SqlParameter("@alamat_pembeli", alamatPembeli));
                cmd.Parameters.Add(new SqlParameter("@jenis_kelamin", jkPembeli));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                refreshform();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idPembeli = textBox1.Text;
            string nmPembeli = textBox2.Text;
            string noTelpPembeli = textBox3.Text;
            string alamatPembeli = textBox4.Text;
            string jkPembeli = textBox5.Text;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "UPDATE pembeli SET nama_pembeli = @nama_pembeli, alamat_pembeli = @alamat_pembeli, telp_pembeli = @telp_pembeli, jenis_kelamin = @jenis_kelamin WHERE id_pembeli = @id_pembeli";
                SqlCommand command = new SqlCommand(str, koneksi);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@id_pembeli", idPembeli));
                command.Parameters.Add(new SqlParameter("@nama_pembeli", nmPembeli));
                command.Parameters.Add(new SqlParameter("@telp_pembeli", noTelpPembeli));
                command.Parameters.Add(new SqlParameter("@alamat_pembeli", alamatPembeli));
                command.Parameters.Add(new SqlParameter("@jenis_kelamin", jkPembeli));
                command.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data Berhasil Diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refreshform();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string idSupplier = textBox1.Text;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Masukkan Data ID Pembeli", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " delete from [pembeli] where id_pembeli = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                textBox1.Text = "";
                MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 nm = new Form1();
            nm.Show();
            this.Hide();
        }
    }
}
