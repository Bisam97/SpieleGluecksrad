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

            // Spalten hinzufügen
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
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (File.Exists(userProfilePath + "\\Documents\\GlücksradLastOpen.csv"))
            {
                string s = File.ReadAllText(userProfilePath + "\\Documents\\GlücksradLastOpen.csv");
                LoadFile(s);

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
            // checkedListBox1.Items.Clear();
            if (strings[0] == "SaveTypeVersion=2")
            {
                string test = s.Substring(18);
                strings = s.Substring(18).Split("\n");
            }
            for (int i = 0; i < strings.Length; i++)
            {


                string[] stringss = strings[i].Split(";");
                string text = stringss[0];
                int gewichtung;
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
                dataGridView1.Rows.Add(b, text, gewichtung);
                //checkedListBox1.Items.Add(text);
                //checkedListBox1.SetItemChecked(i, b);

            }
            Prüfe();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int v = dataGridView1.Rows.Add(0, textBox1.Text, 1);
            //int v = checkedListBox1.Items.Add(textBox1.Text, 0);
            label1.Text = "Added as Number: " + v;
            Prüfe();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

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
            /*  
              for (int i = 0; i < checkedListBox1.Items.Count; i++)
              {
                  if (i > 0) { s += "\n"; }
                  s += checkedListBox1.Items[i] + ";" + checkedListBox1.GetItemChecked(i);
              }
            */
            saveFileDialog1.Title = "Save to CSV";
            saveFileDialog1.Filter = "Comma-separated values|*.csv";
            saveFileDialog1.FileName = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filep = saveFileDialog1.FileName;
                this.s.Path = filep;
                File.WriteAllText(filep, s);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int i = dataGridView1.SelectedCells[0].RowIndex;
                label1.Text = "Item no " + i + "(" + dataGridView1.SelectedColumns[1] + ") Gelöscht";
                dataGridView1.Rows.RemoveAt(i);

            }
            /*int i = checkedListBox1.SelectedIndex;
            if (i > -1)
            {
                label1.Text = "Item no " + i + "(" + checkedListBox1.Items[checkedListBox1.SelectedIndex] + ") Gelöscht";
                checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
            }
            */
            Prüfe();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Import CSV File";
            openFileDialog1.Filter = "Comma-separated values|*.csv";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filep = openFileDialog1.FileName;
                string s = File.ReadAllText(filep);
                LoadFile(s);
            }
            Prüfe();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LOAD
            openFileDialog1.Title = "Öffne Settings";
            openFileDialog1.Filter = "XML|*.xml";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();


            toolTip1.RemoveAll();
            toolTip1.InitialDelay = 0;
            toolTip1.SetToolTip(button2, "Work on Progness");
            if (File.Exists(openFileDialog1.FileName))
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);

                SoapFormatter formatter = new SoapFormatter();
                s = (GrSettings)formatter.Deserialize(stream);
                stream.Close();
                f.setSettings(s);
                if (s.verzögerung == 0) { s.verzögerung = 1000; }

                textBox2.Text = ((float)s.MinDuration / 1000).ToString();
                textBox3.Text = ((float)s.MaxDuration / 1000).ToString();
                textBox4.Text = s.speed.ToString();
                textBox5.Text = ((float)s.verzögerung / 1000).ToString();


                if (File.Exists(s.Path) && checkBox2.Checked)
                {
                    string s = File.ReadAllText(this.s.Path);
                    LoadFile(s);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SAVE
            saveFileDialog1.Title = "Save Settings";
            saveFileDialog1.Filter = "XML|*.xml";
            saveFileDialog1.FileName = "";
            DialogResult rmd = saveFileDialog1.ShowDialog();


            toolTip1.RemoveAll();
            toolTip1.InitialDelay = 0;
            toolTip1.SetToolTip(button3, "Work on Progness");

            if (rmd == DialogResult.OK)
            {

                Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, s);
                stream.Close();

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (s.Color.Count == 0)
            {
                MessageBox.Show("Bitte Lade erst die Settings oder Lege im Tab Farben und co die Farben fürs Rad Fest.")
                ;
                return;
            }
            if (f.Visible == false)
            {

                f.Visible = true;
                Prüfe();
                button7.Text = "SPINN!";
            }
            else
            {
                s.MaxDuration = (int)(float.Parse(textBox3.Text) * 1000);
                s.MinDuration = (int)(float.Parse(textBox2.Text) * 1000);
                s.verzögerung = (int)(float.Parse(textBox5.Text) * 1000);
                s.speed = (int.Parse(textBox4.Text));
                f.setSettings(s);
                //f.setMdMdSpeed(int.Parse(textBox2.Text), int.Parse(textBox2.Text), int.Parse(textBox2.Text));
                int anzahlPices;
                anzahlPices = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                    if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                    {
                        DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                        if (numericUpDownCell != null)
                        {
                            anzahlPices += Convert.ToInt32(numericUpDownCell.Value);
                        }
                    }
                }
                f.spin(anzahlPices, MakeList());

                //f.spin(checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count, MakeList());

            }

        }

        private List<string> MakeList()
        {
            List<string> notCheckedItem = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                {
                    DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                    if (numericUpDownCell != null)
                    {
                        DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;
                        for (int ii = 0; ii < Convert.ToInt32(numericUpDownCell.Value); ii++)
                        {
                            notCheckedItem.Add(textbox.Value.ToString());
                        }
                    }
                }
            }
            return notCheckedItem;
        }
        private List<string> MakeoneList()
        {
            List<string> notCheckedItem = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                if (Checkbox != null && Convert.ToBoolean(Checkbox.Value) == false)
                {
                    DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                    if (numericUpDownCell != null)
                    {
                        DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;
                        if (textbox != null)
                        {
                            notCheckedItem.Add(textbox.Value.ToString());
                        }
                    }
                }
            }
            return notCheckedItem;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (f.getWin() != "")
            {
                Streiche();
            }
        }
        public void save()
        {
            if (dataGridView1.Rows.Count != 0)
            {

                string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                MessageBox.Show("Daten werden in '" + userProfilePath + "\\Documents\\GlücksradClosed.csv' Gespeichert.");

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
                int ii = 0;
                string ss = "";
                while (File.Exists(userProfilePath + "\\Documents\\GlücksradClosed" + ss + ".csv"))
                {
                    ii++;
                    ss = ii.ToString();
                }
                File.WriteAllText(userProfilePath + "\\Documents\\GlücksradClosed" + ss + ".csv", s);
            }
            /*
            if (checkedListBox1.Items.Count != 0)
            {

                string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                MessageBox.Show("Daten werden in '" + userProfilePath + "\\Documents\\GlücksradClosed.csv' Gespeichert.");

                string s = "";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i > 0) { s += "\n"; }
                    s += checkedListBox1.Items[i] + ";" + checkedListBox1.GetItemChecked(i);
                }
                int ii = 0;
                string ss = "";
                while (File.Exists(userProfilePath + "\\Documents\\GlücksradClosed" + ss + ".csv"))
                {
                    ii++;
                    ss = ii.ToString();
                }
                File.WriteAllText(userProfilePath + "\\Documents\\GlücksradClosed" + ss + ".csv", s);
            }
    */
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { button5.PerformClick(); }
        }

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

        private void button9_Click(object sender, EventArgs e) => dataGridView1.Rows.Clear();

        public bool IsAutoStreich() => checkBox1.Checked;

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
        public void Streiche()
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string s = f.getWin();
                DataGridViewCheckBoxCell Checkbox = dataGridView1.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                DataGridViewNumericUpDownCell numericUpDownCell = dataGridView1.Rows[i].Cells[2] as DataGridViewNumericUpDownCell;
                DataGridViewTextBoxCell textbox = dataGridView1.Rows[i].Cells[1] as DataGridViewTextBoxCell;
                if (Checkbox != null && numericUpDown1 != null && textbox != null)
                {
                    if (s == textbox.Value.ToString())
                    {
                        Checkbox.Value = true;
                    }
                }
            }

            //  checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(f.getWin()), true);
            label1.Text = f.getWin();
        }
        private void Prüfe()
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
            if (anzahlPices <= 0) { button7.Enabled = false; } else { button7.Enabled = true; }
            // MessageBox.Show(anzahlPices.ToString());
        }

        private void button7_MouseEnter(object sender, EventArgs e) => Prüfe();



        private void checkedListBox1_MouseMove(object sender, MouseEventArgs e) => Prüfe();

        private void button10_Click(object sender, EventArgs e)
        {

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

            /*  for (int i = 0; i < checkedListBox1.Items.Count; i++)
              {
                  checkedListBox1.SetItemChecked(i, false);
              }
          */
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
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

            //numericUpDown1.Maximum = checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count;

            if (MakeoneList().Count > 0)
            {


                label2.Text = MakeoneList()[(int)numericUpDown1.Value - 1].ToString();



            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label2.Text = "Das Rad wird bestochen!";
            f.Bestochen(MakeoneList()[(int)numericUpDown1.Value - 1]);
        }

        /*private void checkedListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            numericUpDown1.Maximum = checkedListBox1.Items.Count;
            int i = MakeList().IndexOf(checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString());
            if (i > -1)
            {
                numericUpDown1.Value = i + 1;
            }
        }
        */
        private void button12_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();
            ff.ShowDialog(s);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float res;
            if (!float.TryParse(textBox2.Text, out res))
            {


                if (textBox2.Text == "")
                {
                    s.MinDuration = 1;
                }
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float res;
            if (!float.TryParse(textBox3.Text, out res))
            {


                if (textBox3.Text == "")
                {
                    s.MaxDuration = 100;
                }
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
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            float res;
            if (!float.TryParse(textBox4.Text, out res))
            {


                if (textBox4.Text == "")
                {
                    s.speed = 15;
                }
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            float res;
            if (!float.TryParse(textBox5.Text, out res))
            {


                if (textBox5.Text == "")
                {
                    s.verzögerung = 100;
                }
                else
                {
                    s.verzögerung = 1000;
                    textBox5.Text = 1.ToString();
                    toolTip1.RemoveAll();
                    toolTip1.InitialDelay = 0;
                    toolTip1.SetToolTip(textBox3, "Bitte nur Zahlen eingeben");
                }
                if (textBox5.Text == "0")
                {
                    s.verzögerung = 1000;
                    textBox5.Text = "1";
                }


            }
        }

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


        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewNumericUpDownEditingControl numericUpDown)
            {
                numericUpDown.Value = Convert.ToDecimal(dataGridView1.CurrentCell.Value);
            }
        }
    }
}