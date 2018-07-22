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
    public partial class Form11 : Form
    {
        Form2 F2 = new Form2();
        public Form11()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT SO_ID FROM dbo.SALESORDER_Table WHERE SO_STATUS='CLOSE'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR["SO_ID"].ToString());
            }
            F2.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int C = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD2 = new SqlCommand("select count(DC_ID) from dbo.Delivery_challan_Table ", F2.sqlConnection1);
            SqlDataReader dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                C = Convert.ToInt32(dr2[0]);

                C++;
                textBox1.Text = textBox6.Text + C.ToString();
            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM dbo.SALESORDER_Table  WHERE SO_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox7.Text = DR["C_ID"].ToString();
                textBox3.Text = DR["C_NAME"].ToString();
                textBox8.Text = DR["PR_ID"].ToString();
                textBox4.Text = DR["PR_TYPE"].ToString();
                textBox5.Text = DR["PR_QTY"].ToString();
                textBox10.Text = DR["PR_PRICE"].ToString();
               
            }
            F2.sqlConnection1.Close();
            int A, B, SUM;
            A = Convert.ToInt32(textBox10.Text);
            B = Convert.ToInt32(textBox5.Text);
            SUM = A * B;
            textBox9.Text = SUM.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "DELIVERED")
            {
                F2.sqlConnection1.Open();
                SqlCommand CMD = new SqlCommand(" INSERT INTO dbo.Delivery_challan_Table(SO_ID,TOTAL_AMOUNT,DC_ID,DC_DATE,C_ID,C_NAME,P_ID,P_NAME,P_PRICE,P_QTY,DELIVERY_DATE,DELIVERY_STATUS,STATUS) VALUES(@SO_ID,@TOTAL_AMOUNT,@DC_ID,@DC_DATE,@C_ID,@C_NAME,@P_ID,@P_NAME,@P_QTY,@P_PRICE,@DELIVERY_DATE,@DELIVERY_STATUS,@STATUS)", F2.sqlConnection1);
                CMD.Parameters.AddWithValue("@SO_ID", this.comboBox1.Text);
                CMD.Parameters.AddWithValue("@DC_ID", this.textBox1.Text);
                CMD.Parameters.AddWithValue("@DC_DATE", this.dateTimePicker1.Text);
                CMD.Parameters.AddWithValue("@C_ID", this.textBox7.Text);
                CMD.Parameters.AddWithValue("@C_NAME", this.textBox3.Text);
                CMD.Parameters.AddWithValue("@P_ID", this.textBox8.Text);
                CMD.Parameters.AddWithValue("@P_NAME", this.textBox4.Text);
                CMD.Parameters.AddWithValue("@P_QTY", this.textBox5.Text);
                CMD.Parameters.AddWithValue("@P_PRICE", this.textBox10.Text);
                CMD.Parameters.AddWithValue("@DELIVERY_DATE", this.dateTimePicker2.Text);
                CMD.Parameters.AddWithValue("@DELIVERY_STATUS", this.comboBox2.Text);
                CMD.Parameters.AddWithValue("@TOTAL_AMOUNT", this.textBox9.Text);
                CMD.Parameters.AddWithValue("@STATUS", this.textBox11.Text);
                CMD.ExecuteNonQuery();
                MessageBox.Show("DELIVERY CHALLAN CREATED SUCCESSFULLY!");
                F2.sqlConnection1.Close();

                this.textBox2.Text += "Goods Receiving Note ID:       \t\t" + textBox1.Text + Environment.NewLine;
                this.textBox2.Text += "Purchase Order ID:               \t\t" + comboBox1.Text + Environment.NewLine;
                this.textBox2.Text += "Goods Receiving Note Date:       \t" + dateTimePicker1.Text + Environment.NewLine;
                this.textBox2.Text += "VENDOR ID:                     \t\t" + textBox7.Text + Environment.NewLine;
                this.textBox2.Text += "VENDOR NAME:                   \t\t" + textBox3.Text + Environment.NewLine;
                this.textBox2.Text += "Product ID:                    \t\t" + textBox8.Text + Environment.NewLine;
                this.textBox2.Text += "Product Name:                  \t\t" + textBox4.Text + Environment.NewLine;
                this.textBox2.Text += "Proucts Quantity:                \t\t" + textBox5.Text + Environment.NewLine;
                this.textBox2.Text += "Proucts Delivery Status:         \t\t" + comboBox2.Text + Environment.NewLine;
                this.textBox2.Text += "Proucts Delivery Date:           \t\t" + dateTimePicker2.Text + Environment.NewLine;
                this.textBox2.Text += "TOTAL AMOUNT:           \t\t" + textBox9.Text + Environment.NewLine;
            }

            else
            {
                MessageBox.Show("You Can Not Create A Delivery Challan For This Product Because Products Are Not Delivered" + Environment.NewLine + "THANK YOU");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 F4 = new Form4();
            F4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 F7 = new Form7();
            F7.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }
    }
}
