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
    public partial class Form7 : Form
    {
        Form2 F2 = new Form2();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
           
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT DC_ID FROM dbo.Delivery_challan_Table WHERE STATUS='OPEN' ", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR["DC_ID"].ToString());
            }
            F2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int C = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD2 = new SqlCommand("select count(INVOICE_ID) from dbo.INVOICE_Table ", F2.sqlConnection1);
            SqlDataReader dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                C = Convert.ToInt32(dr2[0]);

                C++;
                textBox2.Text = textBox12.Text + C.ToString();

            }
            F2.sqlConnection1.Close();
            this.textBox14.Text = "67";
            this.textBox11.Text = "YES";
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM dbo.Delivery_challan_Table  WHERE DC_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox3.Text = DR["SO_ID"].ToString();
                textBox4.Text = DR["C_ID"].ToString();
                textBox5.Text = DR["P_ID"].ToString();
                textBox6.Text = DR["C_NAME"].ToString();
                dateTimePicker1.Text = DR["DELIVERY_DATE"].ToString();
                textBox7.Text = DR["P_NAME"].ToString();
                textBox10.Text = DR["P_PRICE"].ToString();
                textBox9.Text = DR["P_QTY"].ToString();
                textBox8.Text = DR["TOTAL_AMOUNT"].ToString();
              }
            F2.sqlConnection1.Close();
            int A, B, SUM;
            A = Convert.ToInt32(textBox14.Text);
            B = Convert.ToInt32(textBox8.Text);
            SUM = A * B;
            textBox15.Text = SUM.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "DELIVERY CHALLAN ID:\t\t" + comboBox1.Text + Environment.NewLine;
            this.textBox1.Text += "INVOICE ID :        \t\t\t" + textBox2.Text + Environment.NewLine;
            this.textBox1.Text += "SALES ORDER ID:     \t\t\t" + textBox3.Text + Environment.NewLine;
            this.textBox1.Text += "CUSTOMER ID:        \t\t\t" + textBox4.Text + Environment.NewLine;
            this.textBox1.Text += "PRODUCT ID:         \t\t\t" + textBox5.Text + Environment.NewLine;
            this.textBox1.Text += "CUSTOMER NAME:      \t\t" + textBox6.Text + Environment.NewLine;
            this.textBox1.Text += "SALES ORDER  DATE:  \t\t" + dateTimePicker1.Text + Environment.NewLine;
            this.textBox1.Text += "PRODUCT NAME:       \t\t" + textBox7.Text + Environment.NewLine;
            this.textBox1.Text += "DELIVERED ON TIME:  \t\t" + textBox11.Text + Environment.NewLine;
            this.textBox1.Text += "PRODUCT PRICE:      \t\t\t" + textBox10.Text + Environment.NewLine;
            this.textBox1.Text += "PRODUCT QUANTITY:   \t\t" + textBox9.Text + Environment.NewLine;
            this.textBox1.Text += "SUB TOTAL:          \t\t\t" + textBox8.Text + Environment.NewLine;
            this.textBox1.Text += "TAX:                \t\t\t" + textBox14.Text + Environment.NewLine;
            this.textBox1.Text += "TOTAL AMOUNT:       \t\t" + textBox15.Text + Environment.NewLine;

            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand(" INSERT INTO dbo.INVOICE_Table(INVOICE_ID,C_ID,P_ID,SO_ID,DC_ID,TOTAL_AMOUNT) VALUES(@INVOICE_ID,@C_ID,@P_ID,@SO_ID,@DC_ID,@TOTAL_AMOUNT)", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@INVOICE_ID", this.textBox2.Text);
            CMD.Parameters.AddWithValue("@C_ID", this.textBox4.Text);
            CMD.Parameters.AddWithValue("@P_ID", this.textBox5.Text);
            CMD.Parameters.AddWithValue("@SO_ID", this.textBox3.Text);
            CMD.Parameters.AddWithValue("@DC_ID", this.comboBox1.Text);
            CMD.Parameters.AddWithValue("@TOTAL_AMOUNT", this.textBox15.Text);
            
            CMD.ExecuteNonQuery();
            MessageBox.Show("INVOICE HAS BEEN CREATED SUCCESSFULLY!");
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD5 = new SqlCommand("UPDATE dbo.Delivery_challan_Table SET STATUS='CLOSE' WHERE DC_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            CMD5.ExecuteNonQuery();
            F2.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }
    }
}
