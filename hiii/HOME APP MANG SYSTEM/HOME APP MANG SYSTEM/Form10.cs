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
    public partial class Form10 : Form
    {
        Form2 F2 = new Form2();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
           
            
            this.textBox17.Text = "OPEN";
            F2.sqlConnection1.Open();
            SqlCommand CMD1 = new SqlCommand("SELECT C_ID FROM  dbo.CUSTOMER_Table WHERE C_STATUS='CLOSE'", F2.sqlConnection1);
            SqlDataReader DR1 = CMD1.ExecuteReader();
            while (DR1.Read())
            {
                comboBox1.Items.Add(DR1["C_ID"].ToString());
            }
            F2.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.CUSTOMER_Table WHERE C_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox3.Text = DR["C_NAME"].ToString();
                textBox6.Text = DR["C_CP_NAME"].ToString();
                textBox4.Text = DR["C_ADDRESS_1"].ToString();
                textBox5.Text = DR["C_PH_NO_1"].ToString();
                textBox7.Text = DR["C_CP_PH_NO"].ToString();
                textBox8.Text = DR["BANK_AC_NO_1"].ToString();
                textBox9.Text = DR["BANK_AC_CREDIT"].ToString();

            }
            F2.sqlConnection1.Close();
            int C = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD2 = new SqlCommand("select count(SO_ID) from dbo.SALESORDER_Table ", F2.sqlConnection1);
            SqlDataReader dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                C = Convert.ToInt32(dr2[0]);
                C++;
                textBox2.Text = textBox19.Text + C.ToString();
            }
            F2.sqlConnection1.Close();
            int C1 = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD3 = new SqlCommand("select count(PO_ID) from dbo.SALESORDER_Table ", F2.sqlConnection1);
            SqlDataReader dr3 = CMD3.ExecuteReader();
            if (dr3.Read())
            {
                C1 = Convert.ToInt32(dr3[0]);
                C1++;
                textBox1.Text = textBox18.Text + C1.ToString();
            }
            F2.sqlConnection1.Close();
            int C3 = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD4 = new SqlCommand("select count(PR_ID) from dbo.Product ", F2.sqlConnection1);
            SqlDataReader dr4 = CMD4.ExecuteReader();
            if (dr4.Read())
            {
                C3 = Convert.ToInt32(dr4[0]);
                C3++;
                comboBox2.Text = textBox20.Text + C3.ToString();
            }
            F2.sqlConnection1.Close();
          
           
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand(" INSERT INTO Product(PR_ID,PR_TYPE,PR_BRAND,PR_PRICE,PR_COLOR,PR_SIZE,PR_POWER,PR_QTY,PR_WARENTYPERIOD,PR_AMOUNTONHAND,PR_ESTIMATEDELIVERY) VALUES(@PR_ID,@PR_TYPE,@PR_BRAND,@PR_PRICE,@PR_COLOR,@PR_SIZE,@PR_POWER,@PR_QTY,@PR_WARENTYPERIOD,@PR_AMOUNTONHAND,@PR_ESTIMATEDELIVERY)", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@PR_ID", this.comboBox2.Text);
            CMD.Parameters.AddWithValue("@PR_TYPE", this.textBox16.Text);
            CMD.Parameters.AddWithValue("@PR_BRAND", this.comboBox4.Text);
            CMD.Parameters.AddWithValue("@PR_PRICE", this.textBox15.Text);
            CMD.Parameters.AddWithValue("@PR_COLOR", this.comboBox5.Text);
            CMD.Parameters.AddWithValue("@PR_SIZE", this.textBox14.Text);
            CMD.Parameters.AddWithValue("@PR_POWER", this.textBox13.Text);
            CMD.Parameters.AddWithValue("@PR_QTY", this.textBox12.Text);
            CMD.Parameters.AddWithValue("@PR_WARENTYPERIOD", this.textBox11.Text);
            CMD.Parameters.AddWithValue("@PR_AMOUNTONHAND", this.comboBox6.Text);
            CMD.Parameters.AddWithValue("@PR_ESTIMATEDELIVERY", this.textBox10.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("PRODUCT ADD SUCCESSFULLY!");
            F2.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand(" INSERT INTO dbo.SALESORDER_Table(SO_ID,SO_DATE,SO_STATUS,PO_ID,PR_ID,PR_TYPE,PR_BRAND,PR_PRICE,PR_COLOR,PR_SIZE,PR_POWER,PR_QTY,PR_WARENTYPERIOD,PR_AMOUNTONHAND,PR_ESTIMATEDELIVERY,C_ID,C_NAME,C_CP_NAME,C_ADDRESS_1,C_PH_NO_1,C_CP_PH_NO,BANK_AC_NO_1,BANK_AC_CREDIT) VALUES(@SO_ID,@SO_DATE,@SO_STATUS,@PR_ID,@PO_ID,@PR_TYPE,@PR_BRAND,@PR_PRICE,@PR_COLOR,@PR_SIZE,@PR_POWER,@PR_QTY,@PR_WARENTYPERIOD,@PR_AMOUNTONHAND,@PR_ESTIMATEDELIVERY,@C_ID,@C_NAME,@C_CP_NAME,@C_ADDRESS_1,@C_PH_NO_1,@C_CP_PH_NO,@BANK_AC_NO_1,@BANK_AC_CREDIT)", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@SO_ID", this.textBox2.Text);
            CMD.Parameters.AddWithValue("@SO_DATE", this.dateTimePicker1.Text);
            CMD.Parameters.AddWithValue("@SO_STATUS", this.textBox17.Text);
            CMD.Parameters.AddWithValue("@PR_ID", this.comboBox2.Text);
            CMD.Parameters.AddWithValue("@PO_ID", this.textBox1.Text);
            CMD.Parameters.AddWithValue("@PR_TYPE", this.textBox16.Text);
            CMD.Parameters.AddWithValue("@PR_BRAND", this.comboBox4.Text);
            CMD.Parameters.AddWithValue("@PR_PRICE", this.textBox15.Text);
            CMD.Parameters.AddWithValue("@PR_COLOR", this.comboBox5.Text);
            CMD.Parameters.AddWithValue("@PR_SIZE", this.textBox14.Text);
            CMD.Parameters.AddWithValue("@PR_POWER", this.textBox13.Text);
            CMD.Parameters.AddWithValue("@PR_QTY", this.textBox12.Text);
            CMD.Parameters.AddWithValue("@PR_WARENTYPERIOD", this.textBox11.Text);
            CMD.Parameters.AddWithValue("@PR_AMOUNTONHAND", this.comboBox6.Text);
            CMD.Parameters.AddWithValue("@PR_ESTIMATEDELIVERY", this.textBox10.Text);
            CMD.Parameters.AddWithValue("@C_ID", this.comboBox1.Text);
            CMD.Parameters.AddWithValue("@C_NAME", this.textBox3.Text);
            CMD.Parameters.AddWithValue("@C_CP_NAME", this.textBox6.Text);
            CMD.Parameters.AddWithValue("@C_ADDRESS_1", this.textBox4.Text);
            CMD.Parameters.AddWithValue("@C_PH_NO_1", this.textBox5.Text);
            CMD.Parameters.AddWithValue("@C_CP_PH_NO", this.textBox7.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_NO_1", this.textBox8.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_CREDIT", this.textBox9.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("SALES ORDER HAS BEEN CREATED SUCCESSFULLY!");
            F2.sqlConnection1.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form4 F4 = new Form4();
            F4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "";
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.comboBox4.Text = "";
            this.comboBox5.Text = "";
            this.comboBox6.Text = "";
            
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            this.textBox12.Text = "";
            this.textBox13.Text = "";
            this.textBox14.Text = "";
            this.textBox15.Text = "";
            this.textBox16.Text = "";
            this.textBox17.Text = "";
            
        }
    }
}
