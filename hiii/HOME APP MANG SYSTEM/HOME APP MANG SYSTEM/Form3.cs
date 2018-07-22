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
    public partial class Form3 : Form
    {
        Form2 F2 = new Form2();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT V_ID FROM  dbo.VENDOR_Table WHERE V_STATUS='OPEN'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox4.Items.Add(DR["V_ID"].ToString());
            }
            F2.sqlConnection1.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.VENDOR_Table WHERE V_ID='"+comboBox4.Text+"'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox15.Text = DR["V_ID"].ToString();
                textBox13.Text = DR["V_NAME"].ToString();
                textBox18.Text = DR["V_BRAND_NAME"].ToString();
                textBox17.Text = DR["V_COMPANY_NAME"].ToString();
                textBox1.Text = DR["V_CONT_PER_NAME"].ToString();
                textBox2.Text = DR["V_ADDRESS_1"].ToString();
                textBox3.Text = DR["V_ADDRESS_2"].ToString();
                textBox4.Text = DR["V_PH_1"].ToString();
                textBox5.Text = DR["V_PH_2"].ToString();
                textBox14.Text = DR["V_CONT_PER_PH_NO"].ToString();
                textBox6.Text = DR["V_FAX"].ToString();
                textBox7.Text = DR["V_E_MAIL"].ToString();
                textBox8.Text = DR["CREDIT_LIMIT"].ToString();
                textBox9.Text = DR["CREDIT_DAYS"].ToString();
                textBox10.Text = DR["Bank_A_C_No_1"].ToString();
                textBox11.Text = DR["Bank_A_C_No_2"].ToString();
                textBox12.Text = DR["Bank_A_C_Credit"].ToString();
                textBox16.Text = DR["V_STATUS"].ToString();
            }
            F2.sqlConnection1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("UPDATE dbo.VENDOR_Table SET V_STATUS='CLOSE' WHERE V_ID='"+comboBox4.Text+"'", F2.sqlConnection1);
            CMD.ExecuteNonQuery();
            MessageBox.Show("VENDOR HAS BEEN SUCCESSFUL APPROVED!" + Environment.NewLine + "THANK YOU!");
            F2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" VENDOR DISSAPPROVED" + Environment.NewLine + "UPDATE THE VENDOR" + Environment.NewLine + "THEN RE-ADD");
            Form1 F1 = new Form1();
            F1.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form12 F12 = new Form12();
            F12.Show();
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
