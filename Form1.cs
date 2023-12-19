using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Configuration;

namespace SpieleGlücksrad
{
    public partial class Form1 : Form
    {
        private Form2? f;
        private GrSettings s = new GrSettings();
        private List<FarbeMitName> colors = new List<FarbeMitName>();
        public Form1()
        {
            InitializeComponent();
            f = new Form2(this);
            f.setSettings(s);

            // GridView Optionen Setzen
            dataGridView1.AllowUserToAddRows = false;




            // Spalte 1: Checkbox
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(checkboxColumn);
            checkboxColumn.HeaderText = "Gestrichen";
            checkboxColumn.Width = 60;

            // Spalte 2: String
            dataGridView1.Columns.Add("StringColumn", "Text");
            DataGridViewTextBoxColumn stringColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["StringColumn"];
            stringColumn.Width = 200;

            // Spalte 3: NumericUpDown
            DataGridViewNumericUpDownColumn numericUpDownColumn = new DataGridViewNumericUpDownColumn();
            dataGridView1.Columns.Add(numericUpDownColumn);
            numericUpDownColumn.HeaderText = "Wichtung";
            numericUpDownColumn.Width = 80;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Laden der zuletzt geöffnet Datei
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (File.Exists(userProfilePath + "\\Documents\\GlücksradLastOpen.csv"))
            {
                string s = File.ReadAllText(userProfilePath + "\\Documents\\GlücksradLastOpen.csv");
                LoadFile(s);
                //setzten der Standart werte
                textBox2.Text = ((float)this.s.MinDuration / 1000).ToString();
                textBox3.Text = ((float)this.s.MaxDuration / 1000).ToString();
                textBox4.Text = this.s.speed.ToString();
                textBox5.Text = ((float)this.s.verzögerung / 1000).ToString();
                colors = this.s.Color;



            }

        }
        private void LoadFile(string s)
        {
            string[] strings = s.Split("\n");
            dataGridView1.Rows.Clear();
            //Prüfen auf Version der Speicher Datei
            if (strings[0] == "SaveTypeVersion=2")
            {
                string test = s.Substring(18);
                strings = s.Substring(18).Split("\n");
            }
            //einfügen Zeile zb test;0;10 ind idie Griedview
            for (int i = 0; i < strings.Length; i++)
            {


                string[] stringss = strings[i].Split(";");
                string text = stringss[0];
                int gewichtung;

                //Prüfen ob gewichtung mit gespeichert wurde
                try
                {
                    gewichtung = int.Parse(stringss[2]);
                }
                catch (Exception)
                {

                    gewichtung = 1;
                }
                if (stringss[1] == "") { stringss[1] = "false"; }
                bool b = Boolean.Parse(stringss[1]);

                //einfügen in die Griedview (boolean , String , int)
                dataGridView1.Rows.Add(b, text, gewichtung);


            }
            Prüfe();
        }
       
        //Manuell Einfügen in die Liste
        private void button5_Click(object sender, EventArgs e)
        {
            int v = dataGridView1.Rows.Add(0, textBox1.Text, 1);
            label1.Text = "Added as Number: " + v;
            Prüfe();
            textBox1.Clear();
        }
        //Speichern als Datei
        private void button4_Click(object sender, EventArgs e)
        {

            string s = "SaveTypeVersion=2";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //zuweisen von Objekten die in einem Basis objekt gespeichert werden
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;

                //Prüfen ob alle felder gefüllt sind mit gültigen daten
                if (Checkbox != null && numericUpDown1 != null && textbox != null)
                {
                    s += "\n";
                    s += textbox.Value.ToString() + ";" + Checkbox.Value.ToString() + ";" + numericUpDownCell.Value.ToString();

                }
            }
            //Configurieren des FileSave Dialoges
            saveFileDialog1.Title = "Save to CSV";
            saveFileDialog1.Filter = "Comma-separated values|*.csv";
            saveFileDialog1.FileName = "";

            //Prüfen ob der Dialog mit ok geschlossen wurde
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                //Sichern der Daten der im s angegeben Path
                string filep = saveFileDialog1.FileName;
                this.s.Path = filep;
                File.WriteAllText(filep, s);
            }

        }
        //löschen des ausgewählten Elements aus der Liste
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int i = dataGridView1.SelectedCells[0].RowIndex;
                label1.Text = "Item no " + i + "(" + dataGridView1.SelectedColumns[1] + ") Gelöscht";
                dataGridView1.Rows.RemoveAt(i);

            }
            
            Prüfe();

        }
        //Laden der Liste aus einer CVS Datei
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Import CSV File";
            openFileDialog1.Filter = "Comma-separated values|*.csv";
            openFileDialog1.FileName = "";
            
            //Prüfen ob der Dialog mit ok geschlossen wurde und Laden der Daten
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filep = openFileDialog1.FileName;
                string s = File.ReadAllText(filep);
                LoadFile(s);
            }
            Prüfe();

        }
        //Laden der Einstellungen aus einer XML Datei
        private void button2_Click(object sender, EventArgs e)
        {
            //Konfigurieren des Open File Dialogs
            openFileDialog1.Title = "Öffne Settings";
            openFileDialog1.Filter = "XML|*.xml";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            //setzten des Tool Tipps das es noch Work in Progness ist
            toolTip1.RemoveAll();
            toolTip1.InitialDelay = 0;
            toolTip1.SetToolTip(button2, "Work on Progness");
            /*
             *--> EINFÜGEN EINER ABFRAGE OB MIT OK GESCHLOSSEN WURDE
            */
            if (File.Exists(openFileDialog1.FileName))
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                
                //Deserialisieren des GrSettings Objektes

                SoapFormatter formatter = new SoapFormatter();
                s = (GrSettings)formatter.Deserialize(stream);
                stream.Close();

                //verknüpfen des GrSettings Objektes mit der Form
                f.setSettings(s);
                //Prüfen ob die Verzögerung 0 ist wenn 0 dann auf 1000 (Standart) setzten
                if (s.verzögerung == 0) { s.verzögerung = 1000; }

                //Setzten der anderen Einstellungen und Kovertieren in die Richtigen werte

                textBox2.Text = ((float)s.MinDuration / 1000).ToString();
                textBox3.Text = ((float)s.MaxDuration / 1000).ToString();
                textBox4.Text = s.speed.ToString();
                textBox5.Text = ((float)s.verzögerung / 1000).ToString();

                //Ürüfen ob der hinterlegte Pfad exestiert und ob die Checkbox betätigt ist
                if (File.Exists(s.Path) && checkBox2.Checked)
                {   
                    //laden der Daten aus einer CSV Datei
                    string s = File.ReadAllText(this.s.Path);
                    LoadFile(s);
                }
            }
        }
        //Sichern der Einstellungen in einer XML datei
        private void button3_Click(object sender, EventArgs e)
        {
            //Konfigurieren des Dialogs
            saveFileDialog1.Title = "Save Settings";
            saveFileDialog1.Filter = "XML|*.xml";
            saveFileDialog1.FileName = "";
            DialogResult rmd = saveFileDialog1.ShowDialog();

            //setzten des Tool Tipps das es noch Work in Progness ist
            toolTip1.RemoveAll();
            toolTip1.InitialDelay = 0;
            toolTip1.SetToolTip(button3, "Work on Progness");

            //Prüfen ob der Dialog mit Ok geschlossen wurde
            if (rmd == DialogResult.OK)
            {   
                //setzten der Einstellungen
                s.MaxDuration = (int)(float.Parse(textBox3.Text) * 1000);
                s.MinDuration = (int)(float.Parse(textBox2.Text) * 1000);
                s.verzögerung = (int)(float.Parse(textBox5.Text) * 1000);
                s.speed = (int.Parse(textBox4.Text));
                //Erstellen der Datei worin die Einstellungen gespeichert werden
                Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                
                //Serialisieren des GrSettings Objektes und speichern in der Datei
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, s);

                //Wichtig schliesen der Datei
                stream.Close();

            }

        }

        //Öffne Glücksrad und betätigen des Spines
        private void button7_Click(object sender, EventArgs e)
        {
            
            //Prüfen ob die anzahl der Elemente in der Farbliste 0 ist
            if (s.Color.Count == 0)
            {
                MessageBox.Show("Bitte Lade erst die Settings oder Lege im Tab Farben und co die Farben fürs Rad Fest.")
                ;
                return;
            }
            //Prüfe ob Form2 schon geöffnet ist falls nein dann öffne
            if (f.Visible == false)
            {

                f.Visible = true;
                Prüfe();
                button7.Text = "SPINN!";
            }
            //wenn Form 2 geöffnet ist dann führe den Spinn durch
            else
            {   
                //setzten der Werte in das Einstellungs Objekt
                s.MaxDuration = (int)(float.Parse(textBox3.Text) * 1000);
                s.MinDuration = (int)(float.Parse(textBox2.Text) * 1000);
                s.verzögerung = (int)(float.Parse(textBox5.Text) * 1000);
                s.speed = (int.Parse(textBox4.Text));

                //schicke das Einstellungs Objekt an Form2 damit es die werde nutzten kann
                f.setSettings(s);

                //Deklarieren der Lokalen Variable anzahlPices
                int anzahlPices;
                anzahlPices = 0;

                //Schleife zum erstellen wie viele Pices das Glücksrad hat
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    
                    //Prüfen ob die Zelle 0 der Reihe eine Checkbox ist und ob sie nicht abgestrichen ist
                    if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                    {
                        DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                        
                        //Prüfen ob die Zelle 2 der Reihe eine numericUpDownCell ist wenn ja dann addiere den wert mit anzahlPices
                        if (numericUpDownCell != null)
                        {
                            anzahlPices += Convert.ToInt32(numericUpDownCell.Value);
                        }
                    }
                }

                //Übergeben der Variable anzahlPices und dem Ergebnis der Methode MakeList an die Mathode spin von Form2
                f.spin(anzahlPices, MakeList());

                

            }

        }
        //Methode MakeList die eine Liste von allen Feldern im Glücksrad enthält
        private List<string> MakeList()
        {   

            //erstellen der Liste vom Typ String
            List<string> notCheckedItem = new List<string>();

            //Schleife um aus jeder Zeile der GriedView daten zu lesen
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                //Prüfen ob die Zelle 0 der Reihe eine Checkbox ist und ob sie nicht abgestrichen ist
                if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                {
                    DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;

                    //Prüfen ob die Zelle 2 der Reihe eine numericUpDownCell ist
                    if (numericUpDownCell != null)
                    {
                        DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;

                        //Schleife die ii von 0 bis wert in numericUpDownCell durchlaufen lässt und jedes mal den wert der Zelle 1 in die Liste schreibt 
                        for (int ii = 0; ii < Convert.ToInt32(numericUpDownCell.Value); ii++)
                        {
                            notCheckedItem.Add(textbox.Value.ToString());
                        }
                    }
                }
            }
            //rückgabe der Liste
            return notCheckedItem;
        }
        //Methode MakeoneList die eine Liste von allen Feldern im Glücksrad enthält aber nur einmal
        private List<string> MakeoneList()
        {
            List<string> notCheckedItem = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                //Prüfen ob die Zelle 0 der Reihe eine Checkbox ist und ob sie nicht abgestrichen ist
                if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                {
                    DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;

                    //Prüfen ob die Zelle 2 der Reihe eine numericUpDown ist 
                    if (numericUpDownCell != null)
                    {
                        DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;

                        //Prüfen ob die Zelle 1 der Reihe eine Textbox ist wenn ja füge Einmal den wert der Textbox in die Liste ein
                        if (textbox != null)
                        {
                            notCheckedItem.Add(textbox.Value.ToString());
                        }
                    }
                }
            }
            //Rückgabe der Liste
            return notCheckedItem;
        }
        //Knopf zum Streichen des gewinners
        private void button8_Click(object sender, EventArgs e)
        {   
            //Pfrüfen ob getWin nicht ein Leer String zurückgibt und dann die Methode Streichen aufrufe 
            if (f.getWin() != "")
            {
                Streiche();
            }
        }

        //Methode zum Speichern in der CSV Datei beim schließen
        public void save()
        {   
            //Prüfen ob es in der Griedview Zeilen vorhanden sind
            if (dataGridView1.Rows.Count != 0)
            {
                //Erhalten des Paths zum benutzerverzeichnisses
                string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


                MessageBox.Show("Daten werden in '" + userProfilePath + "\\Documents\\GlücksradClosed.csv' Gespeichert.");
                
                //Erstellen des Strings mit der Version der Datei
                string s = "SaveTypeVersion=2";

                //Schleife zum auslesen der griedview zeile für zeile
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                    DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;

                    //Prüfen ob die Zellen der Zeile auch den erwarteten Elementen entsprechen
                    if (Checkbox != null && numericUpDown1 != null && textbox != null)
                    {   
                        //einfügen des Steucherzeichens für eine neue zeile und der Werte getrennt mit ;
                        s += "\n";
                        s += textbox.Value.ToString() + ";" + Checkbox.Value.ToString() + ";" + numericUpDownCell.Value.ToString();

                    }
                }
                //überschreiben der Datei verhindern und hochzählen der datei
                int ii = 0;
                string ss = "";
                while (File.Exists(userProfilePath + "\\Documents\\GlücksradClosed" + ss + ".csv"))
                {
                    ii++;
                    ss = ii.ToString();
                }
                File.WriteAllText(userProfilePath + "\\Documents\\GlücksradClosed" + ss + ".csv", s);
            }
            
        }
        //Event wenn Enter in der Texbox zum einfügen in die Liste gedrückt wird das der Knopf Einfügen in Liste betätigt wird
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { button5.PerformClick(); }
        }


        //Speichern der Griedview in der beim Öffnen automatisch geöffneten datei
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                string s = "SaveTypeVersion=2";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                    DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;
                    if (Checkbox != null && numericUpDown1 != null && textbox != null)
                    {
                        s += "\n";
                        s += textbox.Value.ToString() + ";" + Checkbox.Value.ToString() + ";" + numericUpDownCell.Value.ToString();

                    }
                }

                File.WriteAllText(userProfilePath + "\\Documents\\GlücksradLastOpen.csv", s);
            }
        }

        //Löschen der Gesamten GridView
        private void button9_Click(object sender, EventArgs e) => dataGridView1.Rows.Clear();

        //Methode die den aktuellen wert von checkbox1 zurückgibt
        public bool IsAutoStreich() => checkBox1.Checked;

        //Event wenn chckbox1 (Autostreichen) gedrückt wird das der Knopf Streichen ausgegraut wird
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                button8.Enabled = true;
            }
            else
            {
                button8.Enabled = false;
            }
        }

        //Die Methode zum Streichen des Gewinners aus der Liste
        public void Streiche()
        {
            //Schleife zum lesen aus der Gridview
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string s = f.getWin();
                
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;

                //Prüfen ob alle angenommen Contols auch den Zellen entsprechen
                if (Checkbox != null && numericUpDown1 != null && textbox != null)
                {
                    //Prüfen ob der String der gewonnen hat gleich der Textbox ist wann ja dann setzte die Checkbox in zelle 0
                    if (s == textbox.Value.ToString())
                    {
                        Checkbox.Value = true;
                    }
                }
            }

            //Setzte den Tex des Labels zum gewinner 
            label1.Text = f.getWin();
        }

        //Methode zum Prüfen ob das Rad überhaubt gespinnt werden darf (0 Elemente auf dem rad sind nicht möglich)
        private void Prüfe()
        {
            //Prüf Varialble anzahlPices erzeugen und durch jeder Reihe der Grieview gehen
            int anzahlPices = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                //Wenn die Checkbox exestiert und sie nicht gesetzt ist dann addiere zu anzahlPices 1 dazu
                if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                {


                    anzahlPices += 1;

                }
            }
            //Prüfen ob anzahlPices kleiner gleich 0 ist wenn nein dann wird der Knopf7 Aktiviert wenn ja dann Deaktiviert
            if (anzahlPices <= 0) { button7.Enabled = false; } else { button7.Enabled = true; }
            
        }
        //wenn über den aktivieren Knopf7 die Maus bewegt wird wird die Mehtode Prüfen ausgeführt
        private void button7_MouseEnter(object sender, EventArgs e) => Prüfe();


        //wenn über der GriedView die Maus bewegt wird dann wird die Mehtode Prüfen ausgeführt
        private void checkedListBox1_MouseMove(object sender, MouseEventArgs e) => Prüfe();

        //Knopf um alle Elemente in der Liste wieder im Rad zu haben
        private void button10_Click(object sender, EventArgs e)
        {
            //gehe durch jede Reihe und setzt die Checkbox wieder auf False
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string s = f.getWin();
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;
                if (Checkbox != null && numericUpDown1 != null && textbox != null)
                {


                    Checkbox.Value = false;

                }
            }

            
        }

        //Event wenn der Wert in der numericUpDown geändert wird dann wird der ausgewählte element vom Lable angezeigt
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //aktualliesiren des Maximums welches die numericUpDown anzeigen kann
            int anzahlPices = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                {

                    anzahlPices += 1;

                }
            }

            numericUpDown1.Maximum = anzahlPices;

            //Liest aus der Liste der Methode MakeoneList das den wert aus und schreibt ihn in das Label2 welches unter der numericUpDown ist

            if (MakeoneList().Count > 0)
            {
                label2.Text = MakeoneList()[(int)numericUpDown1.Value - 1].ToString();
            }
        }

        //Knopf zum Bestechen des Rades
        private void button11_Click(object sender, EventArgs e)
        {
            label2.Text = "Das Rad wird bestochen!";
            f.Bestochen(MakeoneList()[(int)numericUpDown1.Value - 1]);
        }

        //Knopf zum öffnen der Farb auswahl
        private void button12_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();
            ff.ShowDialog(s);
        }

        //Event wenn der Text der Texbox geändert wird um zu prüfen ob der input auch richtig ist
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float res;
            //versuchen ob es zum sich nicht zum Float Prasen lässt
            if (!float.TryParse(textBox2.Text, out res))
            {

                //wenn die textbox leer ist wird der Settingswert auf 1 (1ms) gesetzt
                if (textBox2.Text == "")
                {
                    s.MinDuration = 1;
                }
                //wenn die Textbox sich nicht Pasen lies dann wird sie mit den Standart werten gefüllt
                else
                {
                    s.MinDuration = 5000;
                    textBox2.Text = 5.ToString();
                    toolTip1.RemoveAll();
                    toolTip1.InitialDelay = 0;
                    toolTip1.SetToolTip(textBox2, "Bitte nur Zahlen eingeben");
                }


            }
        }
        //Event wenn der Text der Texbox geändert wird um zu prüfen ob der input auch richtig ist
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float res;
            //versuchen ob es zum sich nicht zum Float Prasen lässt
            if (!float.TryParse(textBox3.Text, out res))
            {

                //wenn die textbox leer ist wird der Settingswert auf 100 (100ms) gesetzt
                if (textBox3.Text == "")
                {
                    s.MaxDuration = 100;
                }
                //wenn die Textbox sich nicht Pasen lies dann wird sie mit den Standart werten gefüllt
                else
                {
                    s.MaxDuration = 10000;
                    textBox3.Text = 10.ToString();
                    toolTip1.RemoveAll();
                    toolTip1.InitialDelay = 0;
                    toolTip1.SetToolTip(textBox3, "Bitte nur Zahlen eingeben");
                }


            }
        }
        //Event wenn der Text der Texbox geändert wird um zu prüfen ob der input auch richtig ist
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            float res;
            //versuchen ob es zum sich nicht zum Float Prasen lässt
            if (!float.TryParse(textBox4.Text, out res))
            {

                //wenn die textbox leer ist wird der Settingswert auf 15 gesetzt
                if (textBox4.Text == "")
                {
                    s.speed = 15;
                }
                //wenn die Textbox sich nicht Pasen lies dann wird sie mit den Standart werten gefüllt
                else
                {
                    s.speed = 15;
                    textBox4.Text = 15.ToString();
                    toolTip1.RemoveAll();
                    toolTip1.InitialDelay = 0;
                    toolTip1.SetToolTip(textBox4, "Bitte nur Zahlen eingeben");
                }


            }
        }
        //Event wenn der Text der Texbox geändert wird um zu prüfen ob der input auch richtig ist
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            float res;
            //versuchen ob es zum sich nicht zum Float Prasen lässt
            if (!float.TryParse(textBox5.Text, out res))
            {

                //wenn die textbox leer ist wird der Settingswert auf 15 gesetzt
                if (textBox5.Text == "")
                {
                    s.verzögerung = 100;
                }
                //wenn die Textbox sich nicht Pasen lies dann wird sie mit den Standart werten gefüllt
                else
                {
                    s.verzögerung = 1000;
                    textBox5.Text = 1.ToString();
                    toolTip1.RemoveAll();
                    toolTip1.InitialDelay = 0;
                    toolTip1.SetToolTip(textBox3, "Bitte nur Zahlen eingeben");
                }
                //wenn der wert 0 ist dann wird die verzögerung auf 1000 ms gestellt
                if (textBox5.Text == "0")
                {
                    s.verzögerung = 1000;
                    textBox5.Text = "1";
                }


            }
        }
        //Event wenn man auf eine zelle in der Grieview drückt wird geprüft wie hoch der Maximum wer der numericUpDown1 ist und welches element die Ausgewählte Reihe ist
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int anzahlPices = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                {

                    anzahlPices += 1;

                }
            }
            numericUpDown1.Maximum = anzahlPices;
            DataGridViewTextBoxCell textbox = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1] as DataGridViewTextBoxCell;
            if (textbox != null)
            {
                int i = MakeoneList().IndexOf(textbox.Value.ToString());
                if (i > -1)
                {
                    numericUpDown1.Value = i + 1;
                }

            }

        }
        //Evnet das man nur einmal auf die checkbox in der Griedview klicken muss um die checkbox zu erreichen
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Überprüfe, ob die angeklickte Zelle eine CheckBox-Zelle ist
            if (e.ColumnIndex == 0 && e.RowIndex != -1 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                // Setze den Fokus auf die angeklickte Zelle
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Wechsle in den Bearbeitungsmodus
                dataGridView1.BeginEdit(false);

                // Beende die Bearbeitung
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.EndEdit();
                }
            }
        }

        //Event welches den wert der numericUpDownEditControl  in den der zelle in der Griedview ändert
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewNumericUpDownEditingControl numericUpDown)
            {
                numericUpDown.Value = Convert.ToDecimal(dataGridView1.CurrentCell.Value);
            }
        }
    }
}