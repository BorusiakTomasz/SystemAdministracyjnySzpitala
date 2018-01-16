namespace SystemAdministracyjnySzpitala
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.haslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nazwaUzytkownika = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Zaloguj = new System.Windows.Forms.Button();
            this.Zamknij = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.haslo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nazwaUzytkownika);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zaloguj się:";
            // 
            // haslo
            // 
            this.haslo.Location = new System.Drawing.Point(141, 78);
            this.haslo.Name = "haslo";
            this.haslo.PasswordChar = '*';
            this.haslo.Size = new System.Drawing.Size(100, 20);
            this.haslo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasło:";
            // 
            // nazwaUzytkownika
            // 
            this.nazwaUzytkownika.Location = new System.Drawing.Point(141, 37);
            this.nazwaUzytkownika.Name = "nazwaUzytkownika";
            this.nazwaUzytkownika.Size = new System.Drawing.Size(100, 20);
            this.nazwaUzytkownika.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa uzytkownika:";
            // 
            // Zaloguj
            // 
            this.Zaloguj.Location = new System.Drawing.Point(72, 140);
            this.Zaloguj.Name = "Zaloguj";
            this.Zaloguj.Size = new System.Drawing.Size(75, 23);
            this.Zaloguj.TabIndex = 4;
            this.Zaloguj.Text = "Zaloguj";
            this.Zaloguj.UseVisualStyleBackColor = true;
            this.Zaloguj.Click += new System.EventHandler(this.Zaloguj_Click);
            // 
            // Zamknij
            // 
            this.Zamknij.Location = new System.Drawing.Point(153, 140);
            this.Zamknij.Name = "Zamknij";
            this.Zamknij.Size = new System.Drawing.Size(75, 23);
            this.Zamknij.TabIndex = 5;
            this.Zamknij.Text = "Zamknij";
            this.Zamknij.UseVisualStyleBackColor = true;
            this.Zamknij.Click += new System.EventHandler(this.Zamknij_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 172);
            this.ControlBox = false;
            this.Controls.Add(this.Zamknij);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Zaloguj);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System zarzadzania szpitalem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Zaloguj;
        private System.Windows.Forms.TextBox haslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazwaUzytkownika;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Zamknij;
    }
}

