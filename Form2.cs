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
        //Erstellen der variablen
        // setzten der Drehungs variable auf 0.1 um rechnungsfehler zu minimieren
        private float deg = 0.1f;


        //setzen weiterer Variablen
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
            //setzte die variable um von hier auf Methoden der Form1 zuzugreifen
            form = f;
            InitializeComponent();
        }

        //gebe den gewinner string zurück
        public string getWin() { return win; }

        
        private void Form2_Load(object sender, EventArgs e)
        {   
            //stoppe alle Timer 
            timer2.Stop();
            timer1.Stop();
            timer3.Stop();
            //setzte die Prosition für den Glücksrads Pfeil
            points[0].X = -10;
            points[0].Y = 10;
            points[1].X = 10;
            points[1].Y = 10;
            points[2].X = 0;
            points[2].Y = 50;


        }
        //Methode zum spinnen des Rades
        public void spin(int elements, List<string> list)
        {   

            //setzt die Variable Würfel mit der übergeben Liste
            würfel = list.ToArray();

            //leert den string vom letzten gewinner
            win = "";
            
            //Setzt die anzahl an Pices welches das Rad haben soll
            n = elements;

            //Regt die pictureBox an sich selbst neu zu zeichen 
            pictureBox1.Invalidate();

            //setzt Variablen die zum langsamwerden des Rades beitragen wieder auf Standart
            slowdown = false;
            slowup = 0;
            slow = false;
            tstop = false;

            //setzt die Timer Intervalle auf ihre werte
            timer2.Interval = verzögerung;
            timer3.Interval = 1;
            timer1.Interval = RandomNumberGenerator.GetInt32(minDauer, maxDauer);

            //Startet den Verzögerungstimer und stoppt die anderen beiden
            timer2.Start();
            timer1.Stop();
            timer3.Stop();

            //**Debug** um zu schauen auf welcher Prosition das rad ist
            //label1.Text = (360f / n).ToString();

            //berechnet den Winkel welches jedes Pices des Rades hat
            degJn = 360f / n;
            





        }
        //Event welches audgeführt wird wenn die Picturebox1 gezeichnet wird
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            //übergeben der Leinwand der Picturebox an die Lokale Variable
            Graphics Glücksrad = e.Graphics;

            //einstellen der Kantenglätung
            Glücksrad.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //einstellen des nullpunktes und der Rotation der Leinwand
            Glücksrad.TranslateTransform(280, 280);
            Glücksrad.RotateTransform(deg - 90);

            //Aufruf der Methode zum zeichnen des Rades

            DrawRad(Glücksrad, n);


            //Zeichnen einer Dünnen Schwarzen umradung um jedes Pices des Rades
            for (float i = 0; i < 360; i += 360f / n)
            {
                Glücksrad.DrawPie(Pens.Black, -250, -250, 500, 500, i, 360f / n);
            }

            //Reseten des Nullpunktes und der Rotation
            Glücksrad.ResetTransform();

            //Setzten des Nullpunktes
            Glücksrad.TranslateTransform(280, 0);

            //Zeichnen des Pfeiles
            Glücksrad.FillPolygon(Brushes.Silver, points);

            //wenn ein Gewinner gezogen ist dann
            if (win != "")
            {

                //Erstellen einer Font
                Font bisa = new Font("Arial", 25, FontStyle.Bold);

                //Defenieren eines Rechtseckes für den gewinner schrieftzug
                RectangleF rf = new RectangleF();
                rf.Width = 550;
                rf.Height = 250;
                rf.X = -250;
                rf.Y = 550;

                //Zeichnen des Gewinner Schriftzuges
                Glücksrad.DrawString(win, bisa, Brushes.Black, rf);
            }

            //Anweisung das Gezeichnete auch dazustellen
            Glücksrad.Save();

        }
        //was der Timer nach ablauf seines Intervalles machen soll
        private void timer2_Tick(object sender, EventArgs e)
        {   
            //Sich selbst stoppen und Timer3 (Haupttimer) starten
            timer3.Start();
            timer2.Stop();

            //Timer1 starten wenn slowup weniger gleich 0 ist
            if (slowup <= 0) { timer1.Start(); }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //den Speed auf die Aktuelle Rotation rechen
            deg += speed;

            //wenn mehr als 360 auf dem Wert der Rotation ist dann wird 360 abgezogen
            if (deg >= 360) { deg -= 360; }


            //berechnen der aktuellen Prosition im Rad
            newtick = ((int)(deg / degJn));

            //**Debug** anzeigen des speeds und des slowups in lable1
            label1.Text = speed + " | " + slowup;

            //wenn der Pfeil wärend der bewegung das alte Pice verlässt dann
            if (newtick != oldtick)
            {   
                //Soundbugfix
                //wenn der speed schneller ist als 5 oder schneller ist als 1 und es mehr als 25 Pices im Rad gibt und das slowup kleiner als 20 ist dann
                if (speed > 5 || speed > 1 && würfel.Length > 25 && slowup < 20)
                {   

                    //wenn die Soundtime 0 ist dann spiele den Sound setzte den den aktuellen Pice in das alte Pice und setzte Soundtime auf 5 zurück
                    if (tickSoundtime == 0)
                    {   
                        Sound.Play();
                        oldtick = newtick;
                        tickSoundtime = 5;
                    }
                    //ziehe von Soundtime 1 ab
                    else { tickSoundtime--; }
                }
                //wenn das oben icht zu trifft dann Spiele den Sound und setzte den aktuellen Pice in den alten Pice
                else
                {
                    Sound.Play();
                    oldtick = newtick;
                }
            }
            //Abbremsen vom Rad
            //Wenn slow true ist dann
            if (slow)
            {
                //addiere zu slowup 1 
                slowup += 1;

                //wenn das Rad bestochen ist und slowup größer 48 dann
                if (bBestochen && slowup >= 48)
                {
                    //locke slowup auf 48
                    slowup = 48;

                    //wenn die Aktelle Prosition des Rades das Element ist was gewinnen soll dann setzte slowup auf 50
                    if (würfel[(int)(deg / degJn)] == sBestochen)
                    {
                        slowup = 50;
                        bBestochen = false;
                    }

                }
                //wenn Slowup auf 50 ist dann setzte tstop auf true und das Intervall von Timer 3 auf 50
                if (slowup == 50) { tstop = true; }
                timer3.Interval = slowup;
            }

            //die Picturebox neu Zeichnen lassen
            pictureBox1.Invalidate();
            
        }
        //Methode zum zeichnen vom Rad
        private void DrawRad(Graphics g, int n)
        {
            //Erstellen einer Liste an Pinseln
            List<Brush> b = new List<Brush>();
            
            //Für jede Farbe wird ein Pinsel erstellt und in die Liste geschrieben
            foreach (FarbeMitName f in Farben)
            {
                SolidBrush br = new SolidBrush(f.Color);
                b.Add(br);
            }

            //Erstellen einer hochzähl variable
            int ib = 0;

            //Solange bis kein ganzer kreis gezeichnet wurde
            for (float i = 0; i < 360; i += 360f / n)
            {
                //Zeichne ein gefülltes Pice Stück mit dem Pinsel welcher in Prosition ib der Liste steht
                g.FillPie(b[ib], -250, -250, 500, 500, i, 360f / n);
                ib++;

                //wenn ib so groß ist wie die anzahl an Pinseln in der Liste setzte ib wieder auf 0 zurück
                if (ib == b.Count) { ib = 0; }
            }
        }
        //Zweiter Haupttimer für das verringern des Intervalles des Timers3
        private void timer1_Tick(object sender, EventArgs e)
        {   
            //wenn tstop true ist dann
            if (tstop)
            {   
                //stoppe alle Timer
                timer3.Stop();
                timer1.Stop();
                
                //erstelle die variable gezogen
                float gezogen;

                //wenn die größe von der Liste Würfel größer als 1 ist dann berechne die Prosition des Rades
                if (würfel.Length > 1)
                {
                    gezogen = (float)(deg / degJn);
                }

                //wenn nicht ist gezogen 0
                else { gezogen = 0; }

                //setzten der Variable win mit dem Text der an Prosition gezogen aus der Liste würfel steht
                win = würfel[(int)gezogen];

                //neuzeichnen der Picturebox1
                pictureBox1.Invalidate();

                //wenn Autostreichen in Form1 an ist dann streiche den gewinner
                if (form.IsAutoStreich())
                {
                    form.Streiche();
                }

            }
            //Wenn slowdown nicht ist dann setzte slowdown auf true und den timer Interval auf 200 (200ms)
            else if (!slowdown)
            {

                slowdown = true;
                timer1.Interval = 200;
            }
            //Wenn slowdown ist dann
            else if (slowdown)
            {   
                //wenn der speed größer 1 ist dann ziehe 1 von speed ab
                if (speed > 1) { speed -= 1; }

                //wenn ser speed 1 ist dann setzte slow auf true
                if (speed == 1) { slow = true; }
            }

            //wenn alles nicht zutrifft dann setzte slow auf true und den Timer intervall auf 10 (10ms)
            else
            {
                slow = true;
                timer1.Interval = 10;
            }


        }
        //Falls Form2 geschlossen wird sichere die Liste von Form1 und schließe sie
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.save();
            form.Close();
        }

        //Methode die das element bekommt welches gewinnen soll
        public void Bestochen(string ListNo)
        {
            sBestochen = ListNo;
            bBestochen = true;
        }

        //Methode um die Settings von form1 zu erhalten
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
