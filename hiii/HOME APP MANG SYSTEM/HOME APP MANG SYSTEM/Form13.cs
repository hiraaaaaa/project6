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
    public partial class Form13 : Form
    {
        Form2 F2 = new Form2();
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Text = "LOGIN WINDOW";
            
            this.label1.Text = "USER ID";
            this.label2.Text = "PASSWORD";
            this.button1.Text = "OK";
            this.button2.Text = "CLEAR";
            this.button3.Text = "EXIT";
            this.label1.BackColor = Color.DarkKhaki;
            this.label2.BackColor = Color.DarkKhaki;
            this.textBox1.Text = "ENTER YOUR ID";
            this.textBox2.Text = "ENTER YOUR PASSWORD";
            this.textBox1.ForeColor = Color.Red;
            this.textBox2.ForeColor = Color.Red;
            this.AcceptButton = this.button1;
            this.textBox1.CharacterCasing = CharacterCasing.Upper;
            this.button1.BackColor = Color.DarkKhaki;
            this.button2.BackColor = Color.DarkKhaki;
            this.button3.BackColor = Color.DarkKhaki;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox1.BackColor = Color.White;
            this.textBox2.BackColor = Color.White;

        }

       
        private void textBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox2.PasswordChar = '*';

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F2.sqlConnection1.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT COUNT(*) FROM dbo.SIGNUP WHERE NAME='"+textBox1.Text+"' AND PASSWORD='"+textBox2.Text+"'",F2.sqlConnection1);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            if (DT.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("LOGIN SUCCESSFULL" + Environment.NewLine + "YOUR ID:" + textBox1.Text + Environment.NewLine + "YOUR PASSWORD:" + textBox2.Text);
                textBox1.BackColor = Color.Green;
                textBox2.BackColor = Color.Green;
                textBox1.ForeColor = Color.White;
                textBox2.ForeColor = Color.White;
                Form14 F14 = new Form14();
                F14.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("INVALID PASSWORD OR USER ID");
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
                textBox1.ForeColor = Color.White;
                textBox2.ForeColor = Color.White;
            }

            F2.sqlConnection1.Close();

        }
    }
}
