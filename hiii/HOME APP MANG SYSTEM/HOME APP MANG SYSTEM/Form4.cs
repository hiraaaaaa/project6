using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HOME_APP_MANG_SYSTEM
{
    public partial class Form4 : Form
    {
        Form2 F2 = new Form2();
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT SO_ID FROM dbo.SALESORDER_Table WHERE SO_STATUS='OPEN'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR["SO_ID"].ToString());
            }
            F2.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM dbo.SALESORDER_Table WHERE SO_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox12.Text = DR["SO_DATE"].ToString();
                textBox1.Text = DR["PO_ID"].ToString();
                textBox3.Text = DR["C_ID"].ToString();
                textBox4.Text = DR["C_NAME"].ToString();
                textBox5.Text = DR["C_CP_NAME"].ToString();
                textBox6.Text = DR["C_ADDRESS_1"].ToString();
                textBox7.Text = DR["C_PH_NO_1"].ToString();
                textBox8.Text = DR["C_CP_PH_NO"].ToString();
                textBox9.Text = DR["BANK_AC_NO_1"].ToString();
                textBox10.Text = DR["BANK_AC_CREDIT"].ToString();
                textBox11.Text = DR["SO_STATUS"].ToString();
                textBox14.Text = DR["PR_ID"].ToString();
            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD1 = new SqlCommand("Select * from dbo.SALESORDER_Table where PR_ID='" + textBox14.Text + "'", F2.sqlConnection1);
            SqlDataReader DR1 = CMD1.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR1);
            dataGridView1.DataSource = DT;
            F2.sqlConnection1.Close();

            this.textBox2.Text += "PURCHASE ORDER ID:            \t\t\t" + textBox1.Text + Environment.NewLine;
            this.textBox2.Text += "SALES ORDER ID:  \t\t" + comboBox1.Text + Environment.NewLine;
            this.textBox2.Text += "SALES ORDER DATE: \t\t" + textBox12.Text + Environment.NewLine;
            this.textBox2.Text += "CUSTOMER ID:                    \t\t\t" + textBox3.Text + Environment.NewLine;
            this.textBox2.Text += "CUSTOMER NAME:                  \t\t\t" + textBox4.Text + Environment.NewLine;
            this.textBox2.Text += "CONTACT PERSON NAME:          \t\t" + textBox5.Text + Environment.NewLine;
            this.textBox2.Text += "CUSTOMER ADDRESS:               \t\t\t" + textBox6.Text + Environment.NewLine;
            this.textBox2.Text += "CUSTOMER PHONE NUMBER:          \t\t" + textBox7.Text + Environment.NewLine;
            this.textBox2.Text += "CONTACT PERSON PHONE NO:  \t\t" + textBox8.Text + Environment.NewLine;
            this.textBox2.Text += "BANK AC NO::  \t\t" + textBox9.Text + Environment.NewLine;
            this.textBox2.Text += "BANK AC CREDIT:  \t\t" + textBox10.Text + Environment.NewLine;
            this.textBox2.Text += "SALES ORDER STATUS:  \t\t" + textBox11.Text + Environment.NewLine;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("UPDATE dbo.SALESORDER_Table SET SO_STATUS='CLOSE' WHERE SO_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            CMD.ExecuteNonQuery();
            MessageBox.Show("SALES ORDER HAS BEEN SUCCESSFUL APPROVED!" + Environment.NewLine + "THANK YOU!");
            F2.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.textBox2.Text = "";
            this.comboBox1.Text = "";
            this.dataGridView1.DataSource = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form11 F11 = new Form11();
            F11.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SALES ORDER DISSAPPROVED" + Environment.NewLine + "UPDATE THE SALES ORDER" + Environment.NewLine + "THEN RE-ADD");
            Form10 F10 = new Form10();
            F10.Show();
            this.Hide();
        }
    }
}
