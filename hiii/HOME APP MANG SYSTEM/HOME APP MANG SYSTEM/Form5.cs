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
    public partial class Form5 : Form
    {
        Form2 F2 = new Form2();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT PO_ID FROM dbo.PURCHASEORDER_Table WHERE PO_STATUS='OPEN'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR["PO_ID"].ToString());
            }
            F2.sqlConnection1.Close();
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            this.textBox4.Visible = false;
            this.textBox5.Visible = false;
            this.textBox6.Visible = false;
            this.textBox7.Visible = false;
            this.textBox8.Visible = false;
            this.textBox9.Visible = false;
            this.textBox10.Visible = false;
            this.textBox11.Visible = false;
            this.textBox1.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM dbo.PURCHASEORDER_Table  WHERE PO_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox12.Text = DR["PR_ID"].ToString();
                textBox2.Text = DR["PO_ID"].ToString();
                textBox3.Text = DR["PO_CURETDATE"].ToString();
                textBox4.Text = DR["PO_DELIVERYDATE"].ToString();
                textBox5.Text = DR["V_ID"].ToString();
                textBox6.Text = DR["V_NAME"].ToString();
                textBox7.Text = DR["V_COMPANY_NAME"].ToString();
                textBox8.Text = DR["V_ADDRESS_1"].ToString();
                textBox9.Text = DR["V_PH_1"].ToString();
                textBox10.Text = DR["V_CONT_PER_PH_NO"].ToString();
                textBox11.Text = DR["PO_STATUS"].ToString();
                 }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD1 = new SqlCommand("Select * from dbo.PRODUCT where PR_ID='"+textBox12.Text+"'", F2.sqlConnection1);
            SqlDataReader DR1 = CMD1.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR1);
            dataGridView1.DataSource = DT;
            F2.sqlConnection1.Close();
            this.textBox1.Text += "PURCHASE ORDER ID:            \t\t\t" + textBox2.Text + Environment.NewLine;
            this.textBox1.Text += "PURCHASE ORDER CURRENT DATE:  \t\t" + textBox3.Text + Environment.NewLine;
            this.textBox1.Text += "PURCHASE ORDER DELIVERY DATE: \t\t" + textBox4.Text + Environment.NewLine;
            this.textBox1.Text += "VENDOR ID:                    \t\t\t" + textBox5.Text + Environment.NewLine;
            this.textBox1.Text += "VENDOR NAME:                  \t\t\t" + textBox6.Text + Environment.NewLine;
            this.textBox1.Text += "VENDOR COMPANY NAME:          \t\t" + textBox7.Text + Environment.NewLine;
            this.textBox1.Text += "VENDOR ADDRESS:               \t\t\t" + textBox8.Text + Environment.NewLine;
            this.textBox1.Text += "VENDOR PHONE NUMBER:          \t\t" + textBox9.Text + Environment.NewLine;
            this.textBox1.Text += "CONTACT PERSON PHONE NUMBER:  \t\t" + textBox10.Text + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("UPDATE dbo.PURCHASEORDER_Table SET PO_STATUS='CLOSE' WHERE PO_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            CMD.ExecuteNonQuery();
            MessageBox.Show("PURCHASE ORDER HAS BEEN SUCCESSFUL APPROVED!" + Environment.NewLine + "THANK YOU!");
            F2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PURCHASE ORDER DISSAPPROVED" + Environment.NewLine + "UPDATE THE PURCHASE ORDER" + Environment.NewLine + "THEN RE-ADD");
            Form12 F12 = new Form12();
            F12.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            dataGridView1.DataSource = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 F6 = new Form6();
            F6.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }
    }
}
