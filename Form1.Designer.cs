﻿namespace SpieleGlücksrad
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            checkBox2 = new CheckBox();
            button2 = new Button();
            button1 = new Button();
            groupBox2 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            groupBox3 = new GroupBox();
            button10 = new Button();
            textBox1 = new TextBox();
            button5 = new Button();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            label4 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            groupBox4 = new GroupBox();
            button9 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            checkBox1 = new CheckBox();
            groupBox5 = new GroupBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            button11 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label6 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            tabPage2 = new TabPage();
            button12 = new Button();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(115, 105);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Laden";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(11, 80);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "Reload List";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(11, 51);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 1;
            button2.Text = "Load Settings";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(11, 22);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 0;
            button1.Text = "Import CSV Datei";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Location = new Point(133, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(115, 105);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Speichern";
            // 
            // button4
            // 
            button4.Location = new Point(6, 22);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 1;
            button4.Text = "Export als CSV Datei";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(6, 51);
            button3.Name = "button3";
            button3.Size = new Size(100, 23);
            button3.TabIndex = 0;
            button3.Text = "Save Settings";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button10);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(button5);
            groupBox3.Location = new Point(12, 123);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(236, 124);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Einfügen in die Liste";
            // 
            // button10
            // 
            button10.Location = new Point(11, 89);
            button10.Name = "button10";
            button10.Size = new Size(198, 23);
            button10.TabIndex = 2;
            button10.Text = "Abgehackte Aufheben";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(198, 23);
            textBox1.TabIndex = 1;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button5
            // 
            button5.Location = new Point(11, 61);
            button5.Name = "button5";
            button5.Size = new Size(198, 23);
            button5.TabIndex = 0;
            button5.Text = "In die Liste einfügen";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 372);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 66);
            label4.Name = "label4";
            label4.Size = new Size(181, 15);
            label4.TabIndex = 4;
            label4.Text = "Start geschwindichkeit des Rades";
            toolTip1.SetToolTip(label4, "Drehgeschwindichkeit in Grad pro tick (1ms)");
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button9);
            groupBox4.Controls.Add(button6);
            groupBox4.Location = new Point(12, 253);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(236, 87);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Aus Liste löschen";
            // 
            // button9
            // 
            button9.Location = new Point(11, 50);
            button9.Name = "button9";
            button9.Size = new Size(198, 23);
            button9.TabIndex = 1;
            button9.Text = "Gesamte Liste Löschen";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button6
            // 
            button6.Location = new Point(11, 22);
            button6.Name = "button6";
            button6.Size = new Size(198, 23);
            button6.TabIndex = 0;
            button6.Text = "Ausgewähltes Löschen";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(12, 350);
            button7.Name = "button7";
            button7.Size = new Size(236, 59);
            button7.TabIndex = 6;
            button7.Text = "Öffne das Glücksrad";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            button7.MouseEnter += button7_MouseEnter;
            // 
            // button8
            // 
            button8.Location = new Point(12, 440);
            button8.Name = "button8";
            button8.Size = new Size(236, 36);
            button8.TabIndex = 7;
            button8.Text = "Streiche den Gewinner";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 415);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(145, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Automatisch streichen";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label2);
            groupBox5.Controls.Add(numericUpDown1);
            groupBox5.Controls.Add(button11);
            groupBox5.Location = new Point(271, 254);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(379, 86);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Bestechen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 53);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 2;
            label2.Text = "Hier Steht dann Text";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(190, 20);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(129, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // button11
            // 
            button11.Location = new Point(55, 20);
            button11.Name = "button11";
            button11.Size = new Size(129, 23);
            button11.TabIndex = 0;
            button11.Text = "Besteche das Rad";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(271, 350);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(379, 147);
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(371, 119);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Geschwindichkeit und Timer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 93);
            label6.Name = "label6";
            label6.Size = new Size(168, 15);
            label6.TabIndex = 7;
            label6.Text = "Start Verzögerung in Sekunden";
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(6, 91);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(51, 23);
            textBox5.TabIndex = 6;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(66, 37);
            label5.Name = "label5";
            label5.Size = new Size(174, 15);
            label5.TabIndex = 5;
            label5.Text = "Längste Drehdauer in Sekunden";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 8);
            label3.Name = "label3";
            label3.Size = new Size(177, 15);
            label3.TabIndex = 3;
            label3.Text = "Kürzeste Drehdauer in Sekunden";
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(6, 64);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(51, 23);
            textBox4.TabIndex = 2;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(6, 35);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(51, 23);
            textBox3.TabIndex = 1;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(6, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(51, 23);
            textBox2.TabIndex = 0;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(button12);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(371, 119);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Farben und co";
            // 
            // button12
            // 
            button12.Location = new Point(6, 6);
            button12.Name = "button12";
            button12.Size = new Size(125, 23);
            button12.TabIndex = 0;
            button12.Text = "Farben ändern";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(271, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(379, 235);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.MouseMove += checkedListBox1_MouseMove;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 529);
            Controls.Add(dataGridView1);
            Controls.Add(tabControl1);
            Controls.Add(groupBox5);
            Controls.Add(checkBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(groupBox4);
            Controls.Add(label1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Glücksrad Einstellungen";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Button button2;
        private GroupBox groupBox2;
        private Button button4;
        private Button button3;
        private GroupBox groupBox3;
        private TextBox textBox1;
        private Button button5;
        private Label label1;
        private ToolTip toolTip1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox4;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private CheckBox checkBox1;
        private Button button10;
        private GroupBox groupBox5;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button11;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button12;
        private CheckBox checkBox2;
        private Label label6;
        private TextBox textBox5;
        private DataGridView dataGridView1;
    }
}