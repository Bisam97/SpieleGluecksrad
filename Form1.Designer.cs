namespace SpieleGlücksrad
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
            groupBox1 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            groupBox2 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            checkedListBox1 = new CheckedListBox();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
            button5 = new Button();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            groupBox4 = new GroupBox();
            button9 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(115, 96);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Laden";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button2
            // 
            button2.Location = new Point(11, 61);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 1;
            button2.Text = "Load Settings";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(11, 23);
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
            groupBox2.Size = new Size(115, 96);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Speichern";
            // 
            // button4
            // 
            button4.Location = new Point(11, 61);
            button4.Name = "button4";
            button4.Size = new Size(100, 23);
            button4.TabIndex = 1;
            button4.Text = "Export als CSV Datei";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(11, 22);
            button3.Name = "button3";
            button3.Size = new Size(100, 23);
            button3.TabIndex = 0;
            button3.Text = "Save Settings";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(271, 21);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(325, 490);
            checkedListBox1.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(button5);
            groupBox3.Location = new Point(12, 114);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(236, 100);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Einfügen in die Liste";
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
            label1.Location = new Point(12, 321);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button9);
            groupBox4.Controls.Add(button6);
            groupBox4.Location = new Point(12, 220);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(236, 96);
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
            button6.Location = new Point(11, 21);
            button6.Name = "button6";
            button6.Size = new Size(198, 23);
            button6.TabIndex = 0;
            button6.Text = "Ausgewähltes Löschen";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(12, 340);
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
            button8.Location = new Point(12, 430);
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
            checkBox1.Location = new Point(12, 405);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(145, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Automatisch streichen";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 521);
            Controls.Add(checkBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(groupBox4);
            Controls.Add(label1);
            Controls.Add(groupBox3);
            Controls.Add(checkedListBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Glücksrad Einstellungen";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
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
        private CheckedListBox checkedListBox1;
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
    }
}