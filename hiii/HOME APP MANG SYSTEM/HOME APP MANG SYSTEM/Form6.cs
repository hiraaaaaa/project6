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
    public partial class Form6 : Form
    {
        Form2 F2 = new Form2();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT PO_ID FROM dbo.PURCHASEORDER_Table WHERE PO_STATUS='CLOSE'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR["PO_ID"].ToString());
            }
            F2.sqlConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int C = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD2 = new SqlCommand("select count(GRN_ID) from dbo.GRN_Table ", F2.sqlConnection1);
            SqlDataReader dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                C = Convert.ToInt32(dr2[0]);
                C++;
                textBox1.Text = textBox11.Text + C.ToString();

            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM dbo.PURCHASEORDER_Table  WHERE PO_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox7.Text = DR["V_ID"].ToString();
                textBox3.Text = DR["V_NAME"].ToString();
                textBox8.Text = DR["PR_ID"].ToString();
                textBox4.Text = DR["PR_TYPE"].ToString();
                textBox5.Text = DR["PR_QTY"].ToString();
                textBox10.Text = DR["PR_PRICE"].ToString();
                textBox6.Text = DR["PO_DELIVERYDATE"].ToString();
                 }
            F2.sqlConnection1.Close();
            int A,B,SUM;
            A = Convert.ToInt32(textBox10.Text);
            B = Convert.ToInt32(textBox5.Text);
            SUM = A * B;
            textBox9.Text= SUM.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "DELIVERED")
            {
                F2.sqlConnection1.Open();
                SqlCommand CMD = new SqlCommand(" INSERT INTO dbo.GRN_Table(PO_ID,TOTAL_AMOUNT,GRN_ID,GR_DATE,V_ID,V_NAME,PR_ID,PR_NAME,PR_QTY,PO_DELIVERYDATE,PO_DELIVERY_STATUS) VALUES(@PO_ID,@TOTAL_AMOUNT,@GRN_ID,@GR_DATE,@V_ID,@V_NAME,@PR_ID,@PR_NAME,@PR_QTY,@PO_DELIVERYDATE,@PO_DELIVERY_STATUS)", F2.sqlConnection1);
                CMD.Parameters.AddWithValue("@PO_ID", this.comboBox1.Text);
                CMD.Parameters.AddWithValue("@GRN_ID", this.textBox1.Text);
                CMD.Parameters.AddWithValue("@GR_DATE", this.dateTimePicker1.Text);
                CMD.Parameters.AddWithValue("@V_ID", this.textBox7.Text);
                CMD.Parameters.AddWithValue("@V_NAME", this.textBox3.Text);
                CMD.Parameters.AddWithValue("@PR_ID", this.textBox8.Text);
                CMD.Parameters.AddWithValue("@PR_NAME", this.textBox4.Text);
                CMD.Parameters.AddWithValue("@PR_QTY", this.textBox5.Text);
                CMD.Parameters.AddWithValue("@PO_DELIVERYDATE", this.textBox6.Text);
                CMD.Parameters.AddWithValue("@PO_DELIVERY_STATUS", this.comboBox2.Text);
                CMD.Parameters.AddWithValue("@TOTAL_AMOUNT", this.textBox9.Text);
                CMD.ExecuteNonQuery();
                MessageBox.Show("GRN CREATED SUCCESSFULLY!");
                F2.sqlConnection1.Close();

                this.textBox2.Text += "Goods Receiving Note ID:       \t\t\t" + textBox1.Text + Environment.NewLine;
                this.textBox2.Text += "Purchase Order ID:               \t\t\t" + comboBox1.Text + Environment.NewLine;
                this.textBox2.Text += "Goods Receiving Note Date:       \t\t" + dateTimePicker1.Text + Environment.NewLine;
                this.textBox2.Text += "VENDOR ID:                     \t\t\t" + textBox7.Text + Environment.NewLine;
                this.textBox2.Text += "VENDOR NAME:                   \t\t\t" + textBox3.Text + Environment.NewLine;
                this.textBox2.Text += "Product ID:                    \t\t\t" + textBox8.Text + Environment.NewLine;
                this.textBox2.Text += "Product Name:                  \t\t\t" + textBox4.Text + Environment.NewLine;
                this.textBox2.Text += "Proucts Quantity:                \t\t\t" + textBox5.Text + Environment.NewLine;
                this.textBox2.Text += "Proucts Delivery Status:         \t\t" + comboBox2.Text + Environment.NewLine;
                this.textBox2.Text += "Proucts Delivery Date:           \t\t" + textBox6.Text + Environment.NewLine;
                this.textBox2.Text += "TOTAL AMOUNT:           \t\t\t" + textBox9.Text + Environment.NewLine;
            }
            
            else
            {
                MessageBox.Show("You Can Not Create A Goods Receiving Note For This Product Because Products Are Not Delivered" + Environment.NewLine + "THANK YOU" );
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 F8 = new Form8();
            F8.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }
    }
}
