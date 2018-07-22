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
    public partial class Form1 : Form
    {
      
        Form2 F2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            this.comboBox4.Text = "";
            textBox15.Text = "";
            this.textBox1.Text = "";
            this.textBox2.Text = "";
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
          
            this.dataGridView1.DataSource = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand(" INSERT INTO dbo.VENDOR_Table(V_ID,V_NAME,V_BRAND_NAME,V_COMPANY_NAME,V_CONT_PER_NAME,V_ADDRESS_1,V_ADDRESS_2,V_PH_1,V_PH_2,V_CONT_PER_PH_NO,V_FAX,V_E_MAIL,CREDIT_LIMIT,CREDIT_DAYS,Bank_A_C_No_1,Bank_A_C_No_2,Bank_A_C_Credit,V_STATUS) VALUES(@V_ID,@V_NAME,@V_BRAND_NAME,@V_COMPANY_NAME,@V_CONT_PER_NAME,@V_ADDRESS_1,@V_ADDRESS_2,@V_PH_1,@V_PH_2,@V_CONT_PER_PH_NO,@V_FAX,@V_E_MAIL,@CREDIT_LIMIT,@CREDIT_DAYS,@Bank_A_C_No_1,@Bank_A_C_No_2,@Bank_A_C_Credit,@V_STATUS)", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@V_ID",this.textBox15.Text);
            CMD.Parameters.AddWithValue("@V_NAME",this.textBox13.Text);
            CMD.Parameters.AddWithValue("@V_BRAND_NAME",this.comboBox2.Text);
            CMD.Parameters.AddWithValue("@V_COMPANY_NAME",this.comboBox1.Text);
            CMD.Parameters.AddWithValue("@V_CONT_PER_NAME",this.textBox1.Text);
            CMD.Parameters.AddWithValue("@V_ADDRESS_1",this.textBox2.Text);
            CMD.Parameters.AddWithValue("@V_ADDRESS_2",this.textBox3.Text);
            CMD.Parameters.AddWithValue("@V_PH_1",this.textBox4.Text);
            CMD.Parameters.AddWithValue("@V_PH_2",this.textBox5.Text);
            CMD.Parameters.AddWithValue("@V_CONT_PER_PH_NO",this.textBox14.Text);
            CMD.Parameters.AddWithValue("@V_FAX",this.textBox6.Text);
            CMD.Parameters.AddWithValue("@V_E_MAIL",this.textBox7.Text);
            CMD.Parameters.AddWithValue("@CREDIT_LIMIT",this.textBox8.Text);
            CMD.Parameters.AddWithValue("@CREDIT_DAYS",this.textBox9.Text);
            CMD.Parameters.AddWithValue("@Bank_A_C_No_1",this.textBox10.Text);
            CMD.Parameters.AddWithValue("@Bank_A_C_No_2",this.textBox11.Text);
            CMD.Parameters.AddWithValue("@Bank_A_C_Credit", this.textBox12.Text);
            CMD.Parameters.AddWithValue("@V_STATUS", this.textBox16.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("DATA SAVED SUCCESSFULLY!");
            F2.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("Select * from dbo.VENDOR_Table", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(DR);
            dataGridView1.DataSource = DT;
            F2.sqlConnection1.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int C = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD2 = new SqlCommand("select count(V_ID) from dbo.VENDOR_Table ", F2.sqlConnection1);
            SqlDataReader dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                C = Convert.ToInt32(dr2[0]);
                C++;
                textBox15.Text = textBox17.Text + C.ToString();

            }
            F2.sqlConnection1.Close();
           
            
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT V_ID FROM  dbo.VENDOR_Table WHERE V_STATUS='CLOSE'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox3.Items.Add(DR["V_ID"].ToString());
            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD1 = new SqlCommand("SELECT V_ID FROM  dbo.VENDOR_Table WHERE V_STATUS='OPEN'", F2.sqlConnection1);
            SqlDataReader DR1 = CMD1.ExecuteReader();
            while (DR1.Read())
            {
                comboBox4.Items.Add(DR1["V_ID"].ToString());
            }
            F2.sqlConnection1.Close();
            this.textBox16.Text = "OPEN";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show(); 
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("UPDATE dbo.VENDOR_Table SET V_NAME=@V_NAME,V_BRAND_NAME=@V_BRAND_NAME,V_COMPANY_NAME=@V_COMPANY_NAME,V_CONT_PER_NAME=@V_CONT_PER_NAME,V_ADDRESS_1=@V_ADDRESS_1,V_ADDRESS_2=@V_ADDRESS_2,V_PH_1=@V_PH_1,V_PH_2=@V_PH_2,V_CONT_PER_PH_NO=@V_CONT_PER_PH_NO,V_FAX=@V_FAX,V_E_MAIL=@V_E_MAIL,CREDIT_LIMIT=@CREDIT_LIMIT,CREDIT_DAYS=@CREDIT_DAYS,Bank_A_C_No_1=@Bank_A_C_No_1,Bank_A_C_No_2=@Bank_A_C_No_2,Bank_A_C_Credit=@Bank_A_C_Credit,V_STATUS=@V_STATUS  WHERE V_ID='" + comboBox4.Text + "'", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@V_NAME", this.textBox13.Text);
            CMD.Parameters.AddWithValue("@V_BRAND_NAME", this.comboBox2.Text);
            CMD.Parameters.AddWithValue("@V_COMPANY_NAME", this.comboBox1.Text);
            CMD.Parameters.AddWithValue("@V_CONT_PER_NAME", this.textBox1.Text);
            CMD.Parameters.AddWithValue("@V_ADDRESS_1", this.textBox2.Text);
            CMD.Parameters.AddWithValue("@V_ADDRESS_2", this.textBox3.Text);
            CMD.Parameters.AddWithValue("@V_PH_1", this.textBox4.Text);
            CMD.Parameters.AddWithValue("@V_PH_2", this.textBox5.Text);
            CMD.Parameters.AddWithValue("@V_CONT_PER_PH_NO", this.textBox14.Text);
            CMD.Parameters.AddWithValue("@V_FAX", this.textBox6.Text);
            CMD.Parameters.AddWithValue("@V_E_MAIL", this.textBox7.Text);
            CMD.Parameters.AddWithValue("@CREDIT_LIMIT", this.textBox8.Text);
            CMD.Parameters.AddWithValue("@CREDIT_DAYS", this.textBox9.Text);
            CMD.Parameters.AddWithValue("@Bank_A_C_No_1", this.textBox10.Text);
            CMD.Parameters.AddWithValue("@Bank_A_C_No_2", this.textBox11.Text);
            CMD.Parameters.AddWithValue("@Bank_A_C_Credit", this.textBox12.Text);
            CMD.Parameters.AddWithValue("@V_STATUS", this.textBox16.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("VENDOR HAS BEEN SUCCESSFUL Ree Add!");
            F2.sqlConnection1.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.VENDOR_Table WHERE V_ID='" + comboBox4.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox13.Text = DR["V_NAME"].ToString();
                comboBox2.Text = DR["V_BRAND_NAME"].ToString();
                comboBox1.Text = DR["V_COMPANY_NAME"].ToString();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3();
            F3.Show();
            this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.VENDOR_Table WHERE V_ID='" + comboBox4.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox13.Text = DR["V_NAME"].ToString();
                comboBox2.Text = DR["V_BRAND_NAME"].ToString();
                comboBox1.Text = DR["V_COMPANY_NAME"].ToString();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           

        }
    }
}
