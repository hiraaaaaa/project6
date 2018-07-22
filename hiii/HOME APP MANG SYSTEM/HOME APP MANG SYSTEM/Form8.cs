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
    public partial class Form8 : Form
    {
        Form2 F2 = new Form2();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            int C = 0;
            F2.sqlConnection1.Open();
            SqlCommand CMD2 = new SqlCommand("select count(C_ID) from dbo.CUSTOMER_Table ", F2.sqlConnection1);
            SqlDataReader dr2 = CMD2.ExecuteReader();
            if (dr2.Read())
            {
                C = Convert.ToInt32(dr2[0]);

                C++;
                textBox1.Text =textBox17.Text + C.ToString();

            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT C_ID FROM  dbo.CUSTOMER_Table WHERE C_STATUS='CLOSE'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR["C_ID"].ToString());
            }
            F2.sqlConnection1.Close();
            F2.sqlConnection1.Open();
            SqlCommand CMD1 = new SqlCommand("SELECT C_ID FROM  dbo.CUSTOMER_Table WHERE C_STATUS='OPEN'", F2.sqlConnection1);
            SqlDataReader DR1 = CMD1.ExecuteReader();
            while (DR1.Read())
            {
                comboBox2.Items.Add(DR1["C_ID"].ToString());
            }
            F2.sqlConnection1.Close();
            this.textBox16.Text = "OPEN";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.CUSTOMER_Table WHERE C_ID='" + comboBox1.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox2.Text = DR["C_NAME"].ToString();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("SELECT *FROM  dbo.CUSTOMER_Table WHERE C_ID='" + comboBox2.Text + "'", F2.sqlConnection1);
            SqlDataReader DR = CMD.ExecuteReader();
            if (DR.Read())
            {
                textBox2.Text = DR["C_NAME"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand(" INSERT INTO dbo.CUSTOMER_Table(C_ID,C_NAME,C_CITY,C_CP_NAME,C_ADDRESS_1,C_ADDRESS_2,C_PH_NO_1,C_PH_NO_2,C_CP_PH_NO,C_EMAIL,C_FAX,C_CR_LIMIT,C_CR_DAYS,BANK_AC_NO_1,BANK_AC_NO_2,BANK_AC_CREDIT,C_STATUS) VALUES(@C_ID,@C_NAME,@C_CITY,@C_CP_NAME,@C_ADDRESS_1,@C_ADDRESS_2,@C_PH_NO_1,@C_PH_NO_2,@C_CP_PH_NO,@C_EMAIL,@C_FAX,@C_CR_LIMIT,@C_CR_DAYS,@BANK_AC_NO_1,@BANK_AC_NO_2,@BANK_AC_CREDIT,@C_STATUS)", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@C_ID", this.textBox1.Text);
            CMD.Parameters.AddWithValue("@C_NAME", this.textBox2.Text);
            CMD.Parameters.AddWithValue("@C_CITY", this.comboBox3.Text);
            CMD.Parameters.AddWithValue("@C_CP_NAME", this.textBox3.Text);
            CMD.Parameters.AddWithValue("@C_ADDRESS_1", this.textBox4.Text);
            CMD.Parameters.AddWithValue("@C_ADDRESS_2", this.textBox5.Text);
            CMD.Parameters.AddWithValue("@C_PH_NO_1", this.textBox6.Text);
            CMD.Parameters.AddWithValue("@C_PH_NO_2", this.textBox7.Text);
            CMD.Parameters.AddWithValue("@C_CP_PH_NO", this.textBox8.Text);
            CMD.Parameters.AddWithValue("@C_EMAIL", this.textBox9.Text);
            CMD.Parameters.AddWithValue("@C_FAX", this.textBox10.Text);
            CMD.Parameters.AddWithValue("@C_CR_LIMIT", this.textBox11.Text);
            CMD.Parameters.AddWithValue("@C_CR_DAYS", this.textBox12.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_NO_1", this.textBox13.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_NO_2", this.textBox14.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_CREDIT", this.textBox15.Text);
            CMD.Parameters.AddWithValue("@C_STATUS", this.textBox16.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("DATA SAVED SUCCESSFULLY!");
            F2.sqlConnection1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand CMD = new SqlCommand("UPDATE dbo.CUSTOMER_Table SET C_NAME=@C_NAME,C_CITY=@C_CITY,C_CP_NAME=@C_CP_NAME,C_ADDRESS_1=@C_ADDRESS_1,C_ADDRESS_2=@C_ADDRESS_2,C_PH_NO_1=@C_PH_NO_1,C_PH_NO_2=@C_PH_NO_2,C_CP_PH_NO=@C_CP_PH_NO,C_EMAIL=@C_EMAIL,C_FAX=@C_FAX,C_CR_LIMIT=@C_CR_LIMIT,C_CR_DAYS=@C_CR_DAYS,BANK_AC_NO_1=@BANK_AC_NO_1,BANK_AC_NO_2=@BANK_AC_NO_2,BANK_AC_CREDIT=@BANK_AC_CREDIT,C_STATUS=@C_STATUS WHERE C_ID='" + comboBox2.Text + "'", F2.sqlConnection1);
            CMD.Parameters.AddWithValue("@C_ID", this.textBox1.Text);
            CMD.Parameters.AddWithValue("@C_NAME", this.textBox2.Text);
            CMD.Parameters.AddWithValue("@C_CITY", this.comboBox3.Text);
            CMD.Parameters.AddWithValue("@C_CP_NAME", this.textBox3.Text);
            CMD.Parameters.AddWithValue("@C_ADDRESS_1", this.textBox4.Text);
            CMD.Parameters.AddWithValue("@C_ADDRESS_2", this.textBox5.Text);
            CMD.Parameters.AddWithValue("@C_PH_NO_1", this.textBox6.Text);
            CMD.Parameters.AddWithValue("@C_PH_NO_2", this.textBox7.Text);
            CMD.Parameters.AddWithValue("@C_CP_PH_NO", this.textBox8.Text);
            CMD.Parameters.AddWithValue("@C_EMAIL", this.textBox9.Text);
            CMD.Parameters.AddWithValue("@C_FAX", this.textBox10.Text);
            CMD.Parameters.AddWithValue("@C_CR_LIMIT", this.textBox11.Text);
            CMD.Parameters.AddWithValue("@C_CR_DAYS", this.textBox12.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_NO_1", this.textBox13.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_NO_2", this.textBox14.Text);
            CMD.Parameters.AddWithValue("@BANK_AC_CREDIT", this.textBox15.Text);
            CMD.Parameters.AddWithValue("@C_STATUS", this.textBox16.Text);
            CMD.ExecuteNonQuery();
            MessageBox.Show("CUSTOMER HAS  BENN SUCCESSFULLY REE-ADD!");
            F2.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 F9 = new Form9();
            F9.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form9 F9 = new Form9();
            F9.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            
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
            this.textBox15.Text = "";
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form14 F14 = new Form14();
            F14.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
