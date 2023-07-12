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
    public partial class Form5 : Form
    {
        private string stringConnection = "data source=DESKTOP-7VKCCI7\\REZA ; database=TokoBuku;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Form5()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }
        private void refreshform()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;  
            textBox9.Enabled = false;
            Bukucbx();
            comboBox1.Enabled = false;
        }
        private void dataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = "SELECT id_buku, nama_buku, jumlah_stok, penulis, penerbit, TahunTerbit,harga_jual, id_supplier FROM dbo.buku";
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

        private void Bukucbx()
        {
            koneksi.Open();
            String str = "select id_supplier from dbo.supplier";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            comboBox1.DisplayMember = "id_supplier";
            comboBox1.ValueMember = "id_supplier";
            comboBox1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            button1.Enabled= true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string idBuku = textBox1.Text;
            string hargaJual = textBox2.Text;
            string jmlStok = textBox5.Text;
            string nmBuku = textBox6.Text;
            string penulis = textBox7.Text;
            string penerbit = textBox8.Text;
            string thnTerbit = textBox9.Text;
            string idSupplier = comboBox1.Text;
                
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO dbo.buku (id_Buku, nama_buku, jumlah_stok, penulis, penerbit, TahunTerbit, harga_jual, id_supplier)" + "VALUES(@id_buku, @nama_buku, @jumlah_stok, @penulis, @penerbit, @TahunTerbit, @harga_beli, @harga_jual, @keuntungan, @id_supplier)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_buku", idBuku));
                cmd.Parameters.Add(new SqlParameter("@nama_buku", nmBuku));
                cmd.Parameters.Add(new SqlParameter("@jumlah_stok", jmlStok));
                cmd.Parameters.Add(new SqlParameter("@penulis", penulis));
                cmd.Parameters.Add(new SqlParameter("@penerbit", penerbit));
                cmd.Parameters.Add(new SqlParameter("@TahunTerbit", thnTerbit));
                cmd.Parameters.Add(new SqlParameter("@harga_jual", hargaJual));
                cmd.Parameters.Add(new SqlParameter("@id_supplier", idSupplier));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                refreshform();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idBuku = textBox1.Text;
            string hargaJual = textBox2.Text;
            string jmlStok = textBox5.Text;
            string nmBuku = textBox6.Text;
            string penulis = textBox7.Text;
            string penerbit = textBox8.Text;
            string thnTerbit = textBox9.Text;
            string idSupplier = comboBox1.Text;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "UPDATE buku SET nama_buku = @nama_buku, jumlah_stok = @jumlah_stok, penulis = @penulis, penerbit = @penerbit, TahunTerbit = @TahunTerbit, harga_jual = @harga_jual, id_supplier = @id_supplier WHERE id_buku = @id_buku";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_buku", idBuku));
                cmd.Parameters.Add(new SqlParameter("@nama_buku", nmBuku));
                cmd.Parameters.Add(new SqlParameter("@jumlah_stok", jmlStok));
                cmd.Parameters.Add(new SqlParameter("@penulis", penulis));
                cmd.Parameters.Add(new SqlParameter("@penerbit", penerbit));
                cmd.Parameters.Add(new SqlParameter("@TahunTerbit", thnTerbit));
                cmd.Parameters.Add(new SqlParameter("@harga_jual", hargaJual));
                cmd.Parameters.Add(new SqlParameter("@id_supplier", idSupplier));
                cmd.ExecuteNonQuery();
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
                MessageBox.Show("Masukkan Data ID Buku", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " delete from [buku] where id_buku = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                textBox1.Text = "";
                MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
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
