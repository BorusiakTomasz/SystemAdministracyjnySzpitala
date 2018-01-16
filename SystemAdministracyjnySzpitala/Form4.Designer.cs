namespace SystemAdministracyjnySzpitala
{
    partial class Form4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rolaPielegniarka = new System.Windows.Forms.RadioButton();
            this.rolaLekarz = new System.Windows.Forms.RadioButton();
            this.rolaAdministrator = new System.Windows.Forms.RadioButton();
            this.DodajEdytuj = new System.Windows.Forms.Button();
            this.Wroc = new System.Windows.Forms.Button();
            this.imie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nazwisko = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pesel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nazwaUzytkownika = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.haslo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.posada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numerPWZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.specializacja = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rolaPielegniarka);
            this.groupBox1.Controls.Add(this.rolaLekarz);
            this.groupBox1.Controls.Add(this.rolaAdministrator);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rola:";
            // 
            // rolaPielegniarka
            // 
            this.rolaPielegniarka.AutoSize = true;
            this.rolaPielegniarka.Location = new System.Drawing.Point(24, 68);
            this.rolaPielegniarka.Name = "rolaPielegniarka";
            this.rolaPielegniarka.Size = new System.Drawing.Size(83, 17);
            this.rolaPielegniarka.TabIndex = 2;
            this.rolaPielegniarka.TabStop = true;
            this.rolaPielegniarka.Text = "Pielęgniarka";
            this.rolaPielegniarka.UseVisualStyleBackColor = true;
            this.rolaPielegniarka.CheckedChanged += new System.EventHandler(this.rolaPielegniarka_CheckedChanged);
            // 
            // rolaLekarz
            // 
            this.rolaLekarz.AutoSize = true;
            this.rolaLekarz.Location = new System.Drawing.Point(24, 44);
            this.rolaLekarz.Name = "rolaLekarz";
            this.rolaLekarz.Size = new System.Drawing.Size(57, 17);
            this.rolaLekarz.TabIndex = 1;
            this.rolaLekarz.TabStop = true;
            this.rolaLekarz.Text = "Lekarz";
            this.rolaLekarz.UseVisualStyleBackColor = true;
            this.rolaLekarz.CheckedChanged += new System.EventHandler(this.rolaLekarz_CheckedChanged);
            // 
            // rolaAdministrator
            // 
            this.rolaAdministrator.AutoSize = true;
            this.rolaAdministrator.Location = new System.Drawing.Point(24, 20);
            this.rolaAdministrator.Name = "rolaAdministrator";
            this.rolaAdministrator.Size = new System.Drawing.Size(85, 17);
            this.rolaAdministrator.TabIndex = 0;
            this.rolaAdministrator.TabStop = true;
            this.rolaAdministrator.Text = "Administrator";
            this.rolaAdministrator.UseVisualStyleBackColor = true;
            this.rolaAdministrator.CheckedChanged += new System.EventHandler(this.rolaAdministrator_CheckedChanged);
            // 
            // DodajEdytuj
            // 
            this.DodajEdytuj.Location = new System.Drawing.Point(494, 93);
            this.DodajEdytuj.Name = "DodajEdytuj";
            this.DodajEdytuj.Size = new System.Drawing.Size(91, 23);
            this.DodajEdytuj.TabIndex = 1;
            this.DodajEdytuj.Text = "Dodaj / Edytuj";
            this.DodajEdytuj.UseVisualStyleBackColor = true;
            this.DodajEdytuj.Click += new System.EventHandler(this.DodajEdytuj_Click);
            // 
            // Wroc
            // 
            this.Wroc.Location = new System.Drawing.Point(591, 93);
            this.Wroc.Name = "Wroc";
            this.Wroc.Size = new System.Drawing.Size(75, 23);
            this.Wroc.TabIndex = 2;
            this.Wroc.Text = "Wróć";
            this.Wroc.UseVisualStyleBackColor = true;
            this.Wroc.Click += new System.EventHandler(this.Wroc_Click);
            // 
            // imie
            // 
            this.imie.Location = new System.Drawing.Point(142, 29);
            this.imie.Name = "imie";
            this.imie.Size = new System.Drawing.Size(100, 20);
            this.imie.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Imię:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nazwisko:";
            // 
            // nazwisko
            // 
            this.nazwisko.Location = new System.Drawing.Point(248, 29);
            this.nazwisko.Name = "nazwisko";
            this.nazwisko.Size = new System.Drawing.Size(100, 20);
            this.nazwisko.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pesel:";
            // 
            // pesel
            // 
            this.pesel.Location = new System.Drawing.Point(354, 29);
            this.pesel.Name = "pesel";
            this.pesel.Size = new System.Drawing.Size(100, 20);
            this.pesel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nazwa użytkownika:";
            // 
            // nazwaUzytkownika
            // 
            this.nazwaUzytkownika.Location = new System.Drawing.Point(460, 29);
            this.nazwaUzytkownika.Name = "nazwaUzytkownika";
            this.nazwaUzytkownika.Size = new System.Drawing.Size(100, 20);
            this.nazwaUzytkownika.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(563, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hasło:";
            // 
            // haslo
            // 
            this.haslo.Location = new System.Drawing.Point(566, 29);
            this.haslo.Name = "haslo";
            this.haslo.Size = new System.Drawing.Size(100, 20);
            this.haslo.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Specializacja:";
            // 
            // posada
            // 
            this.posada.Location = new System.Drawing.Point(269, 88);
            this.posada.Name = "posada";
            this.posada.Size = new System.Drawing.Size(100, 20);
            this.posada.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Posada:";
            // 
            // numerPWZ
            // 
            this.numerPWZ.Location = new System.Drawing.Point(375, 88);
            this.numerPWZ.Name = "numerPWZ";
            this.numerPWZ.Size = new System.Drawing.Size(100, 20);
            this.numerPWZ.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "NumerPWZ:";
            // 
            // specializacja
            // 
            this.specializacja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specializacja.FormattingEnabled = true;
            this.specializacja.Location = new System.Drawing.Point(142, 88);
            this.specializacja.Name = "specializacja";
            this.specializacja.Size = new System.Drawing.Size(121, 21);
            this.specializacja.TabIndex = 18;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 128);
            this.ControlBox = false;
            this.Controls.Add(this.specializacja);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numerPWZ);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.posada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.haslo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nazwaUzytkownika);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pesel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nazwisko);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imie);
            this.Controls.Add(this.Wroc);
            this.Controls.Add(this.DodajEdytuj);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rolaPielegniarka;
        private System.Windows.Forms.RadioButton rolaLekarz;
        private System.Windows.Forms.RadioButton rolaAdministrator;
        private System.Windows.Forms.Button DodajEdytuj;
        private System.Windows.Forms.Button Wroc;
        private System.Windows.Forms.TextBox imie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazwisko;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pesel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nazwaUzytkownika;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox haslo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox posada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox numerPWZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox specializacja;
    }
}