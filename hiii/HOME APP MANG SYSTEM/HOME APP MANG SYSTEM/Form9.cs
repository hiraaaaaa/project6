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
    public partial class Form9 : Form
    {
        Form2 F2 = new Form2();
        public Form9()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 F8 = new Form8();
            F8.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.CUSTOMER_Table WHERE C_ID='" + comboBox2.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox2.Text = DR["C_NAME"].ToString();
                textBox1.Text = DR["C_ID"].ToString();
                comboBox3.Text = DR["C_CITY"].ToString();
                textBox3.Text = DR["C_CP_NAME"].ToString();
                textBox4.Text = DR["C_ADDRESS_1"].ToString();
                textBox5.Text = DR["C_ADDRESS_2"].ToString();
                textBox6.Text = DR["C_PH_NO_1"].ToString();
                textBox7.Text = DR["C_PH_NO_2"].ToString();
                textBox8.Text = DR["C_CP_PH_NO"].ToString();
                textBox9.Text = DR["C_EMAIL"].ToString();
                textBox10.Text = DR["C_FAX"].ToString();
                textBox11.Text = DR["C_CR_LIMIT"].ToString();
                textBox12.Text = DR["C_CR_DAYS"].ToString();
                textBox13.Text = DR["BANK_AC_NO_1"].ToString();
                textBox14.Text = DR["BANK_AC_NO_2"].ToString();
                textBox15.Text = DR["BANK_AC_CREDIT"].ToString();
                textBox16.Text = DR["C_STATUS"].ToString();
            }
            F2.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("UPDATE dbo.CUSTOMER_Table SET C_STATUS='CLOSE' WHERE C_ID='" + comboBox2.Text + "'", F2.sqlConnection1);
            CMD.ExecuteNonQuery();
            MessageBox.Show("CUSTOMER HAS BEEN SUCCESSFUL APPROVED!" + Environment.NewLine + "THANK YOU!");
            F2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CUSTOMER DISSAPPROVED" + Environment.NewLine + "UPDATE THE CUSTOMER" + Environment.NewLine + "THEN RE-ADD");
            Form8 F8 = new Form8();
            F8.Show();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT C_ID FROM  dbo.CUSTOMER_Table WHERE C_STATUS='OPEN'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox2.Items.Add(DR["C_ID"].ToString());
            }
            F2.sqlConnection1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 F10 = new Form10();
            F10.Show(); 
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }
    }
}
