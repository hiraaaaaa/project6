using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HOME_APP_MANG_SYSTEM
{
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIGNUP SU = new SIGNUP();
            SU.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 F13 = new Form13();
            F13.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random colours = new Random();
            int a = colours.Next(0, 255);
            int b = colours.Next(0, 255);
            int c = colours.Next(0, 255);
            int d = colours.Next(0, 255);
            label1.ForeColor = Color.FromArgb(a, b, c, d);

        }
    }
}
