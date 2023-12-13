using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpieleGlücksrad
{


    public partial class Form2 : Form
    {

        private float deg = 0.1f;
        private bool tstop;
        private int slowup;
        Point[] points = new Point[3];
        private bool slow;
        private bool slowdown;
        int n = 20;
        private int speed = 15;
        private List<FarbeMitName> Farben;
        private int verzögerung;
        private string[]? würfel;
        private string win = "";
        private Form1? form;
        private double degJn;
        private string sBestochen;
        private bool bBestochen;
        private int maxDauer = 10000;
        private int minDauer = 5000;
        private SoundPlayer Sound = new SoundPlayer(Properties.Resource1.wheel_spin_click);
        private int oldtick = 0;
        private int newtick = 0;
        private int tickSoundtime;

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
            //deg = 0;
            n = elements;
            pictureBox1.Invalidate();
            //speed = 15;
            slowdown = false;
            slowup = 0;
            slow = false;
            tstop = false;
            timer2.Interval = verzögerung;
            timer3.Interval = 1;
            timer1.Interval = RandomNumberGenerator.GetInt32(minDauer, maxDauer);
            timer2.Start();
            timer1.Stop();
            timer3.Stop();
            //label1.Text = (360f / n).ToString();
            degJn = 360f / n;
            //Sound.Play();





        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Graphics Glücksrad = e.Graphics;
            //Glücksrad.Clear(Color.FromArgb(255, 0, 255, 0));
            Glücksrad.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Glücksrad.TranslateTransform(280, 280);
            Glücksrad.RotateTransform(deg - 90);

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

                //Glücksrad.FillRectangle(Brushes.Black, -200, 175, 400, 200);
                Font bisa = new Font("Arial", 25, FontStyle.Bold);
                RectangleF rf = new RectangleF();
                rf.Width = 575;
                rf.Height = 200;
                rf.X = -250;
                rf.Y = 550;

                Glücksrad.DrawString(win, bisa, Brushes.Black, rf);
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
            if (deg >= 360) { deg -= 360; }

            // label1.Text = (deg / degJn).ToString() + " | " + würfel[(int)(deg / degJn)];
            newtick = ((int)(deg / degJn));
            label1.Text = speed + " | " + slowup;
            if (newtick != oldtick)
            {
                if (speed > 5 || speed > 1 && würfel.Length > 25 && slowup < 20)
                {
                    if (tickSoundtime == 0)
                    {
                        Sound.Play();
                        oldtick = newtick;
                        tickSoundtime = 5;
                    }
                    else { tickSoundtime--; }
                }
                else
                {
                    Sound.Play();
                    oldtick = newtick;
                }
            }
            if (slow)
            {
                slowup += 1;
                if (bBestochen && slowup >= 48)
                {
                    slowup = 48;
                    if (würfel[(int)(deg / degJn)] == sBestochen)
                    {
                        slowup = 50;
                        bBestochen = false;
                    }

                }
                if (slowup == 50) { tstop = true; }
                timer3.Interval = slowup;
            }


            pictureBox1.Invalidate();
            //label1.Text = slowup.ToString();
        }

        private void DrawRad(Graphics g, int n)
        {

            List<Brush> b = new List<Brush>();
            /*
            b[0] = Brushes.Aqua;
            b[1] = Brushes.Red;
            b[2] = Brushes.Blue;
            b[3] = Brushes.Yellow;
            b[4] = Brushes.Violet;
            */
            foreach (FarbeMitName f in Farben)
            {
                SolidBrush br = new SolidBrush(f.Color);
                b.Add(br);
            }

            int ib = 0;
            for (float i = 0; i < 360; i += 360f / n)
            {

                g.FillPie(b[ib], -250, -250, 500, 500, i, 360f / n);
                ib++;
                if (ib == b.Count) { ib = 0; }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tstop)
            {
                timer3.Stop();
                timer1.Stop();
                float gezogen;
                if (würfel.Length > 1)
                {
                    gezogen = (float)(deg / degJn);
                }
                else { gezogen = 0; }
                win = würfel[(int)gezogen];
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
        public void Bestochen(string ListNo)
        {
            sBestochen = ListNo;
            bBestochen = true;
        }


        internal void setSettings(GrSettings s)
        {
            minDauer = s.MinDuration;
            maxDauer = s.MaxDuration;
            speed = s.speed;
            Farben = s.Color;
            verzögerung = s.verzögerung;
        }
    }
}
