﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextExplorer_v1._0._1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            
            Form3 form3 = new Form3();
            form3.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();

            Form4 form4 = new Form4();
            form4.ShowDialog();
        }


    }
}
