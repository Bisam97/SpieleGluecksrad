using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpieleGlücksrad
{


    public partial class Form2 : Form
    {

        private int deg;
        private bool tstop;
        private int slowup;
        Point[] points = new Point[3];
        private bool slow;
        private bool slowdown;
        int n = 20;
        private int speed = 10;
        private string[]? würfel;
        private string win = "";
        private Form1? form;

        public Form2(Form1 f)
        {
            form = f;
            InitializeComponent();
        }

        public string getWin() { return win; }


        private void Form2_Load(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Stop();
            timer3.Stop();
            points[0].X = -10;
            points[0].Y = 10;
            points[1].X = 10;
            points[1].Y = 10;
            points[2].X = 0;
            points[2].Y = 50;

        }
        public void spin(int elements, List<string> list)
        {
            würfel = list.ToArray();
            win = "";
            deg = 0;
            n = elements;
            pictureBox1.Invalidate();
            speed = 10;
            slowdown = false;
            slowup = 0;
            slow = false;
            tstop = false;
            timer2.Interval = 5000;
            timer3.Interval = 1;
            timer1.Interval = RandomNumberGenerator.GetInt32(5000, 10000);
            timer2.Start();
            timer1.Stop();
            timer3.Stop();
            label1.Text = (360f / n).ToString();





        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Graphics Glücksrad = e.Graphics;
            Glücksrad.Clear(Color.FromArgb(255, 0, 255, 0));
            Glücksrad.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Glücksrad.TranslateTransform(280, 280);
            Glücksrad.RotateTransform(deg);

            DrawRad(Glücksrad, n);

            for (float i = 0; i < 360; i += 360f / n)
            {
                Glücksrad.DrawPie(Pens.Black, -250, -250, 500, 500, i, 360f / n);
            }

            Glücksrad.ResetTransform();

            Glücksrad.TranslateTransform(280, 0);
            Glücksrad.FillPolygon(Brushes.Silver, points);
            if (win != "")
            {

                Glücksrad.FillRectangle(Brushes.Black, -200, 75, 400, 400);
                Font bisa = new Font("Arial", 25, FontStyle.Bold);
                RectangleF rf = new RectangleF();
                rf.Width = 350;
                rf.Height = 350;
                rf.X = -175;
                rf.Y = 100;

                Glücksrad.DrawString(win, bisa, Brushes.White, rf);
            }
            Glücksrad.Save();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer3.Start();
            timer2.Stop();
            if (slowup <= 0) { timer1.Start(); }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            deg += speed;



            if (slow)
            {
                slowup += 1;
                if (slowup == 50) { tstop = true; }
                timer3.Interval = slowup;
            }
            if (deg == 360) { deg = 0; }

            pictureBox1.Invalidate();
            label1.Text = slowup.ToString();
        }

        private void DrawRad(Graphics g, int n)
        {
            Brush[] b = new Brush[5];
            b[0] = Brushes.Aqua;
            b[1] = Brushes.Red;
            b[2] = Brushes.Blue;
            b[3] = Brushes.Yellow;
            b[4] = Brushes.Violet;
            int ib = 0;
            for (float i = 0; i < 360; i += 360f / n)
            {

                g.FillPie(b[ib], -250, -250, 500, 500, i, 360f / n);
                ib++;
                if (ib == 5) { ib = 0; }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tstop)
            {
                timer3.Stop();
                timer1.Stop();
                int gezogen;
                if (würfel.Length > 1)
                {
                    gezogen = RandomNumberGenerator.GetInt32(0, würfel.Length - 1);
                }
                else { gezogen = 0; }
                win = würfel[gezogen];
                pictureBox1.Invalidate();
                if (form.IsAutoStreich())
                {
                    form.Streiche();
                }
            }
            else if (!slowdown)
            {

                slowdown = true;
                timer1.Interval = 200;
            }
            else if (slowdown)
            {
                if (speed > 1) { speed -= 1; }
                if (speed == 1) { slow = true; }
            }
            else
            {
                slow = true;
                timer1.Interval = 10;
            }


        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.save();
            form.Close();
        }
    }
}
