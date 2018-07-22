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
    
    public partial class SIGNUP : Form
    {
        Form2 F2 = new Form2();
        public SIGNUP()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlCommand SMD = new SqlCommand("INSERT into SIGNUP(NAME,PASSWORD) VALUES (@NAME,@PASSWORD)",F2.sqlConnection1);
            SMD.Parameters.AddWithValue("NAME",this.textBox1.Text);
            SMD.Parameters.AddWithValue("PASSWORD", this.textBox2.Text);
            SMD.ExecuteNonQuery();
            MessageBox.Show("DATA HAS BEEN INSERTED");
           
            F2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADMIN AD = new ADMIN();
            AD.Show();
            this.Hide();
        }
    }
}
