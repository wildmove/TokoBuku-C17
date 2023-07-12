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
    public partial class Form2 : Form
    {
        private string stringConnection = "data source=DESKTOP-7VKCCI7\\REZA ; database=TokoBuku;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Form2()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void refreshform()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void dataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = "SELECT id_supplier, nama_supplier, telp_supplier, alamat_supplier FROM dbo.supplier";
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
            textBox2.Enabled = true;
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nmSupplier = textBox2.Text;
            string idSupplier = textBox4.Text;
            string alamatSupplier = textBox1.Text;
            string noTelpSupplier = textBox3.Text;

            if (textBox2.Text == "" || textBox4.Text== "" || textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO dbo.supplier (id_supplier, nama_supplier, alamat_supplier, telp_supplier)" + "VALUES(@id_supplier, @nama_supplier, @alamat_supplier, @telp_supplier)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType= CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@nama_supplier", nmSupplier));
                cmd.Parameters.Add(new SqlParameter("@id_supplier", idSupplier));
                cmd.Parameters.Add(new SqlParameter("@alamat_supplier", alamatSupplier));
                cmd.Parameters.Add(new SqlParameter("@telp_supplier", noTelpSupplier));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                refreshform();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nmSupplier = textBox2.Text;
            string idSupplier = textBox4.Text;
            string alamatSupplier = textBox1.Text;
            string noTelpSupplier = textBox3.Text;

            if (textBox2.Text == "" || textBox4.Text == "" || textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "UPDATE supplier SET nama_supplier = @nama_supplier, alamat_supplier = @alamat_supplier, telp_supplier = @telp_supplier WHERE id_Supplier = @id_supplier";
                SqlCommand command = new SqlCommand(str, koneksi);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@nama_supplier", nmSupplier));
                command.Parameters.Add(new SqlParameter("@id_supplier", idSupplier));
                command.Parameters.Add(new SqlParameter("@alamat_supplier", alamatSupplier));
                command.Parameters.Add(new SqlParameter("@telp_supplier", noTelpSupplier));
                command.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data Berhasil Diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                refreshform();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string idSupplier = textBox4.Text;

            if (textBox4.Text == "")
            {
                MessageBox.Show("Masukkan Data ID Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " delete from [supplier] where id_supplier = '" + textBox4.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                textBox4.Text = "";
                MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
