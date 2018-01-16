namespace SystemAdministracyjnySzpitala
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DodajDyzur = new System.Windows.Forms.Button();
            this.UsunDyzor = new System.Windows.Forms.Button();
            this.DodajPracownika = new System.Windows.Forms.Button();
            this.EdytujPracownika = new System.Windows.Forms.Button();
            this.UsunPracownika = new System.Windows.Forms.Button();
            this.Wroc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administratorzy:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lekarze:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(141, 26);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pielęgniarki:";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(267, 26);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 95);
            this.listBox3.TabIndex = 5;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 133);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // DodajDyzur
            // 
            this.DodajDyzur.Location = new System.Drawing.Point(38, 55);
            this.DodajDyzur.Name = "DodajDyzur";
            this.DodajDyzur.Size = new System.Drawing.Size(75, 23);
            this.DodajDyzur.TabIndex = 8;
            this.DodajDyzur.Text = "Dodaj";
            this.DodajDyzur.UseVisualStyleBackColor = true;
            this.DodajDyzur.Click += new System.EventHandler(this.DodajDyzur_Click);
            // 
            // UsunDyzor
            // 
            this.UsunDyzor.Location = new System.Drawing.Point(119, 55);
            this.UsunDyzor.Name = "UsunDyzor";
            this.UsunDyzor.Size = new System.Drawing.Size(75, 23);
            this.UsunDyzor.TabIndex = 9;
            this.UsunDyzor.Text = "Usuń";
            this.UsunDyzor.UseVisualStyleBackColor = true;
            this.UsunDyzor.Click += new System.EventHandler(this.UsunDyzor_Click);
            // 
            // DodajPracownika
            // 
            this.DodajPracownika.Location = new System.Drawing.Point(393, 30);
            this.DodajPracownika.Name = "DodajPracownika";
            this.DodajPracownika.Size = new System.Drawing.Size(75, 23);
            this.DodajPracownika.TabIndex = 10;
            this.DodajPracownika.Text = "Dodaj";
            this.DodajPracownika.UseVisualStyleBackColor = true;
            this.DodajPracownika.Click += new System.EventHandler(this.DodajPracownika_Click);
            // 
            // EdytujPracownika
            // 
            this.EdytujPracownika.Location = new System.Drawing.Point(393, 59);
            this.EdytujPracownika.Name = "EdytujPracownika";
            this.EdytujPracownika.Size = new System.Drawing.Size(75, 23);
            this.EdytujPracownika.TabIndex = 11;
            this.EdytujPracownika.Text = "Edytuj";
            this.EdytujPracownika.UseVisualStyleBackColor = true;
            this.EdytujPracownika.Click += new System.EventHandler(this.EdytujPracownika_Click);
            // 
            // UsunPracownika
            // 
            this.UsunPracownika.Location = new System.Drawing.Point(393, 88);
            this.UsunPracownika.Name = "UsunPracownika";
            this.UsunPracownika.Size = new System.Drawing.Size(75, 23);
            this.UsunPracownika.TabIndex = 12;
            this.UsunPracownika.Text = "Usuń";
            this.UsunPracownika.UseVisualStyleBackColor = true;
            this.UsunPracownika.Click += new System.EventHandler(this.UsunPracownika_Click);
            // 
            // Wroc
            // 
            this.Wroc.Location = new System.Drawing.Point(393, 272);
            this.Wroc.Name = "Wroc";
            this.Wroc.Size = new System.Drawing.Size(75, 23);
            this.Wroc.TabIndex = 13;
            this.Wroc.Text = "Wyloguj";
            this.Wroc.UseVisualStyleBackColor = true;
            this.Wroc.Click += new System.EventHandler(this.Wroc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UsunDyzor);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.DodajDyzur);
            this.groupBox1.Location = new System.Drawing.Point(187, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 94);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dyżur:";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 307);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Wroc);
            this.Controls.Add(this.UsunPracownika);
            this.Controls.Add(this.EdytujPracownika);
            this.Controls.Add(this.DodajPracownika);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button DodajDyzur;
        private System.Windows.Forms.Button UsunDyzor;
        private System.Windows.Forms.Button DodajPracownika;
        private System.Windows.Forms.Button EdytujPracownika;
        private System.Windows.Forms.Button UsunPracownika;
        private System.Windows.Forms.Button Wroc;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}