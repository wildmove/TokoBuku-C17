﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokoBuku_C17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
            Form5 rm = new Form5();
            rm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form2 hu = new Form2();
            hu.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form4 nw = new Form4();
            nw.Show(); 
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form5 rm = new Form5();
            rm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 hu = new Form2();
            hu.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form6 mr = new Form6();
            mr.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form6 mr = new Form6();
            mr.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 nw = new Form4();
            nw.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }
    }
}
