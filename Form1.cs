using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace SpieleGlücksrad
{
    public partial class Form1 : Form
    {
        Form2? f;
        public Form1()
        {
            InitializeComponent();
            f = new Form2(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (File.Exists(userProfilePath + "\\Documents\\GlücksradLastOpen.csv"))
            {
                string s = File.ReadAllText(userProfilePath + "\\Documents\\GlücksradLastOpen.csv");
                string[] strings = s.Split("\n");
                checkedListBox1.Items.Clear();
                for (int i = 0; i < strings.Length; i++)
                {
                    string[] stringss = strings[i].Split(";");
                    string text = stringss[0];
                    if (stringss[1] == "") { stringss[1] = "false"; }
                    bool b = Boolean.Parse(stringss[1]);
                    checkedListBox1.Items.Add(text);
                    checkedListBox1.SetItemChecked(i, b);

                }
                Prüfe();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int v = checkedListBox1.Items.Add(textBox1.Text, 0);
            label1.Text = "Added as Number: " + v;
            Prüfe();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string s = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i > 0) { s += "\n"; }
                s += checkedListBox1.Items[i] + ";" + checkedListBox1.GetItemChecked(i);
            }

            saveFileDialog1.Title = "Save to CSV";
            saveFileDialog1.Filter = "Comma-separated values|*.csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filep = saveFileDialog1.FileName;
                File.WriteAllText(filep, s);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

            int i = checkedListBox1.SelectedIndex;
            if (i > -1)
            {
                label1.Text = "Item no " + i + "(" + checkedListBox1.Items[checkedListBox1.SelectedIndex] + ") Gelöscht";
                checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
            }
            Prüfe();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Import CSV File";
            openFileDialog1.Filter = "Comma-separated values|*.csv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filep = openFileDialog1.FileName;
                string s = File.ReadAllText(filep);
                string[] strings = s.Split("\n", StringSplitOptions.RemoveEmptyEntries);

                checkedListBox1.Items.Clear();
                for (int i = 0; i < strings.Length; i++)
                {
                    string[] stringss = strings[i].Split(";");
                    string text = stringss[0];
                    bool b = Boolean.Parse(stringss[1]);
                    checkedListBox1.Items.Add(text);
                    checkedListBox1.SetItemChecked(i, b);
                }
            }
            Prüfe();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();
            toolTip1.InitialDelay = 0;
            toolTip1.SetToolTip(button2, "Work on Progness");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();
            toolTip1.InitialDelay = 0;
            toolTip1.SetToolTip(button3, "Work on Progness");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<string> notCheckedItem = new List<string>();
            if (f.Visible == false)
            {

                f.Visible = true;
                Prüfe();
                button7.Text = "SPINN!";
            }
            else
            {


                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (!checkedListBox1.GetItemChecked(i))
                    {
                        notCheckedItem.Add(checkedListBox1.Items[i].ToString());
                        // Hier können Sie das nicht angeklickte Element weiterverarbeiten.
                    }
                }
                f.spin(checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count, notCheckedItem);
            }

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

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { button5.PerformClick(); }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkedListBox1.Items.Count != 0)
            {
                string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string s = "";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i > 0) { s += "\n"; }
                    s += checkedListBox1.Items[i] + ";" + checkedListBox1.GetItemChecked(i);
                }

                File.WriteAllText(userProfilePath + "\\Documents\\GlücksradLastOpen.csv", s);
            }



        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
        }

        public bool IsAutoStreich()
        {
            return checkBox1.Checked;
        }

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
            checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(f.getWin()), true);
            label1.Text = f.getWin();
        }
        private void Prüfe()
        {
            if (checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count <= 0) { button7.Enabled = false; } else { button7.Enabled = true; }
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            Prüfe();
        }

      

        private void checkedListBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Prüfe();
        }
    }
}