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
    public partial class Form6 : Form
    {
        private string stringConnection = "data source=DESKTOP-7VKCCI7\\REZA ; database=TokoBuku;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Form6()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }


        private void refreshform()
        {
            textBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            textBox5.Text = "";
            textBox1.Enabled = false;
            kasircbx();
            comboBox2.Enabled = false;
            pembelicbx();
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox5.Enabled = false;
         
        }

        private void pembelicbx()
        {
            koneksi.Open();
            String str = "select id_pembeli from dbo.pembeli";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            comboBox1.DisplayMember = "id_pembeli";
            comboBox1.ValueMember = "id_pembeli";
            comboBox1.DataSource = ds.Tables[0];

        }

        private void kasircbx()
        {
            koneksi.Open();
            String str = "select id_kasir from dbo.kasir";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            comboBox2.DisplayMember = "id_kasir";
            comboBox2.ValueMember = "id_kasir";
            comboBox2.DataSource = ds.Tables[0];

        }
        private void dataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(stringConnection))
                {
                    connection.Open();
                    string query = "SELECT id_transaksi, id_kasir, id_pembeli, tanggal, total_harga FROM dbo.ManageOrder";
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idTransaksi = textBox1.Text;
            string idPembeli = comboBox1.Text;
            string idKasir = comboBox2.Text;
            string tanggal = dateTimePicker1.Text;
            string harga = textBox5.Text;
            

            if (textBox1.Text == "" || comboBox2.Text == "" || comboBox1.Text == "" || dateTimePicker1.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("Masukkan Semua Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO dbo.ManageOrder (id_transaksi, id_kasir, id_pembeli, tanggal, total_harga)" + "VALUES(@id_transaksi, @id_kasir, @id_pembeli, @tanggal, @total_harga)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@id_transaksi", idTransaksi));
                cmd.Parameters.Add(new SqlParameter("@id_kasir", idKasir));
                cmd.Parameters.Add(new SqlParameter("@id_pembeli", idPembeli));
                cmd.Parameters.Add(new SqlParameter("@tanggal", tanggal));
                cmd.Parameters.Add(new SqlParameter("@total_harga", harga));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disimpan", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.Close();
                refreshform();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idSupplier = textBox1.Text;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Masukkan Data ID Transaksi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " delete from [ManageOrder] where id_transaksi = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                textBox1.Text = "";
                MessageBox.Show("Data Berhasil Dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView();
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fg = new Form1();
            fg.Show();
            this.Hide();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
