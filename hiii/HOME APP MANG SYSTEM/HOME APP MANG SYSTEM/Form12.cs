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
    public partial class Form12 : Form
    {
        Form2 F2 = new Form2();
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
           
            
            F2.sqlConnection1.Open();
            SqlCommand CMD1 = new SqlCommand("SELECT PO_ID FROM dbo.PURCHASEORDER_Table", F2.sqlConnection1);
            SqlDataReader DR1 = CMD1.ExecuteReader();
            while (DR1.Read())
            {
                comboBox2.Items.Add(DR1["PO_ID"].ToString());
            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD2 = new SqlCommand("SELECT V_ID FROM dbo.VENDOR_Table WHERE V_STATUS='CLOSE'", F2.sqlConnection1);
            SqlDataReader DR2 = CMD2.ExecuteReader();
            while (DR2.Read())
            {
                comboBox3.Items.Add(DR2["V_ID"].ToString());
            }
            F2.sqlConnection1.Close();
            this.textBox2.Text = "OPEN";
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand(" INSERT INTO dbo.PURCHASEORDER_Table(PO_ID,PO_CURETDATE,PO_DELIVERYDATE,PR_ID,PR_TYPE,PR_BRAND,PR_PRICE,PR_COLOR,PR_SIZE,PR_POWER,PR_QTY,PR_WARENTYPERIOD,PR_AMOUNTONHAND,PR_ESTIMATEDELIVERY,V_ID,V_NAME,V_COMPANY_NAME,V_ADDRESS_1,V_PH_1,V_CONT_PER_PH_NO,PO_STATUS) VALUES(@PO_ID,@PO_CURETDATE,@PO_DELIVERYDATE,@PR_ID,@PR_TYPE,@PR_BRAND,@PR_PRICE,@PR_COLOR,@PR_SIZE,@PR_POWER,@PR_QTY,@PR_WARENTYPERIOD,@PR_AMOUNTONHAND,@PR_ESTIMATEDELIVERY,@V_ID,@V_NAME,@V_COMPANY_NAME,@V_ADDRESS_1,@V_PH_1,@V_CONT_PER_PH_NO,@PO_STATUS)", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@PO_ID", this.comboBox2.Text);
            CMD.Parameters.AddWithValue("@PO_CURETDATE", this.dateTimePicker1.Text);
            CMD.Parameters.AddWithValue("@PO_DELIVERYDATE", this.dateTimePicker2.Text);
            CMD.Parameters.AddWithValue("@PR_ID", this.comboBox1.Text);
            CMD.Parameters.AddWithValue("@PR_TYPE", this.textBox1.Text);
            CMD.Parameters.AddWithValue("@PR_BRAND", this.comboBox4.Text);
            CMD.Parameters.AddWithValue("@PR_PRICE", this.textBox3.Text);
            CMD.Parameters.AddWithValue("@PR_COLOR", this.comboBox5.Text);
            CMD.Parameters.AddWithValue("@PR_SIZE", this.textBox5.Text);
            CMD.Parameters.AddWithValue("@PR_POWER", this.textBox6.Text);
            CMD.Parameters.AddWithValue("@PR_QTY", this.textBox7.Text);
            CMD.Parameters.AddWithValue("@PR_WARENTYPERIOD", this.textBox8.Text);
            CMD.Parameters.AddWithValue("@PR_AMOUNTONHAND", this.comboBox6.Text);
            CMD.Parameters.AddWithValue("@PR_ESTIMATEDELIVERY", this.textBox10.Text);
            CMD.Parameters.AddWithValue("@V_ID", this.comboBox3.Text);
            CMD.Parameters.AddWithValue("@V_NAME", this.textBox11.Text);
            CMD.Parameters.AddWithValue("@V_COMPANY_NAME", this.textBox12.Text);
            CMD.Parameters.AddWithValue("@V_ADDRESS_1", this.textBox13.Text);
            CMD.Parameters.AddWithValue("@V_PH_1", this.textBox14.Text);
            CMD.Parameters.AddWithValue("@V_CONT_PER_PH_NO", this.textBox15.Text);
            CMD.Parameters.AddWithValue("@PO_STATUS", this.textBox2.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("PURCHASE ORDER HAS BEEN CREATED SUCCESSFULLY!");
            F2.sqlConnection1.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand(" INSERT INTO Product(PR_ID,PR_TYPE,PR_BRAND,PR_PRICE,PR_COLOR,PR_SIZE,PR_POWER,PR_QTY,PR_WARENTYPERIOD,PR_AMOUNTONHAND,PR_ESTIMATEDELIVERY) VALUES(@PR_ID,@PR_TYPE,@PR_BRAND,@PR_PRICE,@PR_COLOR,@PR_SIZE,@PR_POWER,@PR_QTY,@PR_WARENTYPERIOD,@PR_AMOUNTONHAND,@PR_ESTIMATEDELIVERY)", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@PR_ID", this.comboBox1.Text);
            CMD.Parameters.AddWithValue("@PR_TYPE", this.textBox1.Text);
            CMD.Parameters.AddWithValue("@PR_BRAND", this.comboBox4.Text);
            CMD.Parameters.AddWithValue("@PR_PRICE", this.textBox3.Text);
            CMD.Parameters.AddWithValue("@PR_COLOR", this.comboBox5.Text);
            CMD.Parameters.AddWithValue("@PR_SIZE", this.textBox5.Text);
            CMD.Parameters.AddWithValue("@PR_POWER", this.textBox6.Text);
            CMD.Parameters.AddWithValue("@PR_QTY", this.textBox7.Text);
            CMD.Parameters.AddWithValue("@PR_WARENTYPERIOD", this.textBox8.Text);
            CMD.Parameters.AddWithValue("@PR_AMOUNTONHAND", this.comboBox6.Text);
            CMD.Parameters.AddWithValue("@PR_ESTIMATEDELIVERY", this.textBox10.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("DATA SAVED SUCCESSFULLY!");
            F2.sqlConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int C = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD4 = new SqlCommand("select count(PR_ID) from dbo.Product ", F2.sqlConnection1);
            SqlDataReader dr4 = CMD4.ExecuteReader();
            if (dr4.Read())
            {
                C = Convert.ToInt32(dr4[0]);

                C++;
                comboBox1.Text = textBox9.Text + C.ToString();

            }
            F2.sqlConnection1.Close();
            int C1 = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD3 = new SqlCommand("select count(PO_ID) from dbo.PURCHASEORDER_Table ", F2.sqlConnection1);
            SqlDataReader dr3 = CMD3.ExecuteReader();
            if (dr3.Read())
            {
                C1 = Convert.ToInt32(dr3[0]);

                C1++;
                comboBox2.Text = textBox4.Text + C1.ToString();

            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.VENDOR_Table WHERE V_ID='" + comboBox3.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox11.Text = DR["V_NAME"].ToString();
                textBox12.Text = DR["V_COMPANY_NAME"].ToString();
                textBox13.Text = DR["V_ADDRESS_1"].ToString();
                textBox14.Text = DR["V_PH_1"].ToString();
                textBox15.Text = DR["V_CONT_PER_PH_NO"].ToString();
            }
            F2.sqlConnection1.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.comboBox3.Text = "";
            this.comboBox4.Text = "";
            this.comboBox5.Text = "";
            this.comboBox6.Text = "";
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            this.textBox12.Text = "";
            this.textBox13.Text = "";
            this.textBox14.Text = "";
            this.textBox15.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }

        
    }
}
