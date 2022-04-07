using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public static int RadioKol;
        public static int RadioRow;
        public static int startwid;
        public static int kartwid;
        public static int startwiddef = 1;
        public static int kartwiddef = 1;
        public static string imie;
        public static string nazwisko;
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine();
            string startowa_widocznosc = Console.ReadLine();
            
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                startwiddef = 1;
            }
            else
            {
                startwiddef = 2;
                startwid = Convert.ToInt32(textBox1.Text);
            }

            if (String.IsNullOrEmpty(textBox2.Text))
            {
                kartwiddef = 1;
            }
            else
            {
                kartwiddef = 2;
                kartwid = Convert.ToInt32(textBox2.Text);
            }

            imie = textBox4.Text;
            nazwisko = textBox5.Text;

            if (radioButton1.Checked)
            {
                Form2 frm2 = new Form2();
                frm2.Show();
            }
            else if (radioButton2.Checked)
            {
                Form3 frm3 = new Form3();
                frm3.Show();
            }
            else if (radioButton3.Checked)
            {
                Form4 frm4 = new Form4();
                frm4.Show();
            }
            else
            {
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine();
            string widocznosc_karty = Console.ReadLine();
            int kart_wid = Convert.ToInt32(widocznosc_karty);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
