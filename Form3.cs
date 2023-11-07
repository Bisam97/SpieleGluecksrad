using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpieleGlücksrad
{
    public partial class Form3 : Form
    {
        private DataGridViewRow row = new DataGridViewRow();
        private List<FarbeMitName> farben;
        private GrSettings grSettings;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {


            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Farbe", "Farbe");
            this.row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = true;
            if (farben != null)
            {
                foreach (FarbeMitName c in farben)
                {
                    AddColor(c.Color, c.Name);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            AddColor(Color.FromArgb(255, 0, 0), "Rot");
            AddColor(Color.FromArgb(255, 85, 0), "Rotorange");
            AddColor(Color.FromArgb(255, 170, 0), "Orange");
            AddColor(Color.FromArgb(255, 255, 0), "Gelb");
            AddColor(Color.FromArgb(170, 255, 0), "Limette");
            AddColor(Color.FromArgb(85, 255, 0), "Hellgrün");
            AddColor(Color.FromArgb(0, 255, 0), "Grün");
            AddColor(Color.FromArgb(0, 255, 85), "Türkis");
            AddColor(Color.FromArgb(0, 255, 170), "Aquamarin");
            AddColor(Color.FromArgb(0, 255, 255), "Cyan");
            AddColor(Color.FromArgb(0, 170, 255), "Himmelblau");
            AddColor(Color.FromArgb(0, 85, 255), "Königsblau");
            AddColor(Color.FromArgb(0, 0, 255), "Blau");
            AddColor(Color.FromArgb(85, 0, 255), "Indigo");
            AddColor(Color.FromArgb(170, 0, 255), "Lila");
            AddColor(Color.FromArgb(255, 0, 255), "Rosa");
            AddColor(Color.FromArgb(255, 0, 170), "Magenta");
            AddColor(Color.FromArgb(255, 0, 85), "Himbeer");

        }
        private void AddColor(Color color, String name)
        {
            row.Cells[0].Value = name;
            DataGridViewImageCell cell = new DataGridViewImageCell();
            cell.ImageLayout = DataGridViewImageCellLayout.Normal;
            cell.Value = null;

            Bitmap bitmap = new Bitmap(20, 20);
            Graphics g = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(color);
            g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
            brush.Dispose();
            cell.Value = bitmap;
            this.row.Cells[1] = cell;
            this.row.Cells[1].Tag = color;


            dataGridView1.Rows.Add(this.row);
            row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
        }

        public void ShowDialog(GrSettings s)
        {
            
            this.farben = s.Color;
            base.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            farben.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Tag != null)
                {
                    FarbeMitName f = new FarbeMitName((Color)row.Cells[1].Tag, (string)row.Cells[0].Value);
                    farben.Add(f);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1) { return; }
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            AddColor(colorDialog1.Color, colorDialog1.Color.Name);
        }
    }
}
