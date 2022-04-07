using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {

        Random rand = new Random();
        int punkty = 1;
        Stopwatch stopWatch = new Stopwatch();
        List<string> ikonki = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k"
        };
        Label clickone, clicktwo;
        public Form2()
        { 
            InitializeComponent();
            PrzypisanieIkonek();
            PokazanieIkonek();
        }

        private void PokazanieIkonek()
        {
            if (Form1.startwiddef == 1)
            {
                timer2.Start();
            }
            else
            {
                timer2.Interval = Form1.startwid * 1000;
                timer2.Start();
            }
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                label.ForeColor = Color.White;
            }
            stopWatch.Start();
        }

        private void PrzypisanieIkonek()
        {
            Label label;
            int randomn;

            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                    continue;
                randomn = rand.Next(0, ikonki.Count);
                label.Text = ikonki[randomn];

                ikonki.RemoveAt(randomn);
            }
        }

        private void Label_click(object sender, EventArgs e)
        {
            if(clickone != null && clicktwo != null)
            {
                return;
            }
            Label clickedlabel = sender as Label;
            if(clickedlabel == null)
            {
                return;
            }
            if(clickedlabel.ForeColor == Color.White)
            {
                return;
            }
            if(clickone == null)
            {
                clickone = clickedlabel;
                clickone.ForeColor = Color.White;
                return;
            }

            clicktwo = clickedlabel;
            clicktwo.ForeColor = Color.White;



            if (clickone.Text == clicktwo.Text)
            {
                punkty += 0;
                CheckWin();
                clickone = null;
                clicktwo = null;
            }
            else
            {
                punkty += 2;
                if (Form1.kartwiddef == 1)
                {
                    timer1.Start();
                }
                else
                {
                    timer1.Interval = Form1.kartwid * 1000;
                    timer1.Start();
                }
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            clickone.ForeColor = clickone.BackColor;
            clicktwo.ForeColor = clicktwo.BackColor;

            clickone = null;
            clicktwo = null;
        }

        private void CheckWin()
        {
            Label label;
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if(label != null && label.ForeColor == label.BackColor)
                {
                    return;
                }
               
            }
            stopWatch.Stop();
            Zapisz();
            
            string ps = "C:\\Users\\Black\\source\\repos\\WindowsFormsApp5\\WindowsFormsApp5\\Pliki\\formularz.txt";

            string tekst = "";
            using (StreamReader sr = File.OpenText(ps))
            {
                tekst = sr.ReadToEnd();
            }
            MessageBox.Show(tekst, "Tablica wynikow");
            Close();
        }

        private void Zapisz()
        {
            TimeSpan ts = stopWatch.Elapsed;
            string path = "C:\\Users\\Black\\source\\repos\\WindowsFormsApp5\\WindowsFormsApp5\\Pliki\\formularz.txt";
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            int wynik = ts.Minutes * punkty + ts.Seconds * punkty + ts.Milliseconds * punkty;
            if (File.Exists(path))
            {
                File.AppendAllText(path, wynik + " " + Form1.imie + " " + Form1.nazwisko + " " + "Plansza 2x4" + " " + elapsedTime + "\n");
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            Label label;
            timer2.Stop();
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                label.ForeColor = label.BackColor;

            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
