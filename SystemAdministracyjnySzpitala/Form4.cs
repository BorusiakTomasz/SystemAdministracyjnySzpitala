using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAdministracyjnySzpitala
{
    public partial class Form4 : Form
    {
        private List<Specializacja> listaSpecializacji;
        private Form3 form3;
        private Administrator administrator;
        private Lekarz lekarz;
        private Pielegniarka pielegniarka;
        private bool isEdited;

        public Form4(Form3 form3)
        {
            InitializeComponent();

            this.form3 = form3;
            isEdited = false;

            ZainicjujListeSpecializacji();
        }

        public Form4(Form3 form3, Administrator a)
        {
            InitializeComponent();

            this.form3 = form3;
            administrator = a;
            isEdited = true;

            ZainicjujListeSpecializacji();
            WypelnijPola(a);
        }

        public Form4(Form3 form3, Lekarz l)
        {
            InitializeComponent();

            this.form3 = form3;
            lekarz = l;
            isEdited = true;

            ZainicjujListeSpecializacji();
            WypelnijPola(l);
        }

        public Form4(Form3 form3, Pielegniarka p)
        {
            InitializeComponent();

            this.form3 = form3;
            pielegniarka = p;
            isEdited = true;

            ZainicjujListeSpecializacji();
            WypelnijPola(p);
        }

        private void ZainicjujListeSpecializacji()
        {
            listaSpecializacji = Enum.GetValues(typeof(Specializacja)).OfType<Specializacja>().ToList();
            specializacja.DataSource = listaSpecializacji;
        }

        private void WypelnijPola<T>(T pracownik)
        {
            if (pracownik is Administrator)
            {
                Administrator a = pracownik as Administrator;

                imie.Text = a.Imie;
                nazwisko.Text = a.Nazwisko;
                pesel.Text = Convert.ToString(a.Pesel);
                nazwaUzytkownika.Text = a.NazwaUzytkownika;
                haslo.Text = a.Haslo;

                groupBox1.Enabled = false;
                rolaAdministrator.Checked = true;
                specializacja.Enabled = false;
                specializacja.SelectedItem = null;
                posada.Enabled = false;
                numerPWZ.Enabled = false;
            }

            if (pracownik is Lekarz)
            {
                Lekarz l = pracownik as Lekarz;

                imie.Text = l.Imie;
                nazwisko.Text = l.Nazwisko;
                pesel.Text = Convert.ToString(l.Pesel);
                nazwaUzytkownika.Text = l.NazwaUzytkownika;
                haslo.Text = l.Haslo;

                groupBox1.Enabled = false;
                rolaLekarz.Checked = true;
                specializacja.Enabled = true;
                specializacja.SelectedItem = l.Specializacja;
                posada.Enabled = true;
                posada.Text = l.Posada;
                numerPWZ.Enabled = true;
                numerPWZ.Text = Convert.ToString(l.NumerPWZ);
            }

            if (pracownik is Pielegniarka)
            {
                Pielegniarka p = pracownik as Pielegniarka;

                imie.Text = p.Imie;
                nazwisko.Text = p.Nazwisko;
                pesel.Text = Convert.ToString(p.Pesel);
                nazwaUzytkownika.Text = p.NazwaUzytkownika;
                haslo.Text = p.Haslo;

                groupBox1.Enabled = false;
                rolaPielegniarka.Checked = true;
                specializacja.Enabled = false;
                specializacja.SelectedItem = null;
                posada.Enabled = true;
                posada.Text = p.Posada;
                numerPWZ.Enabled = false;
            }
        }

        private void rolaAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            specializacja.Enabled = false;
            specializacja.SelectedItem = null;
            posada.Enabled = false;
            numerPWZ.Enabled = false;
        }

        private void rolaLekarz_CheckedChanged(object sender, EventArgs e)
        {
            specializacja.Enabled = true;
            posada.Enabled = true;
            numerPWZ.Enabled = true;
        }

        private void rolaPielegniarka_CheckedChanged(object sender, EventArgs e)
        {
            specializacja.Enabled = false;
            specializacja.SelectedItem = null;
            posada.Enabled = true;
            numerPWZ.Enabled = false;
        }

        private void DodajEdytuj_Click(object sender, EventArgs e)
        {
            if (isEdited)
            {
                if (rolaAdministrator.Checked)
                {
                    Form1.UsunPracownika(administrator);
                }

                if (rolaLekarz.Checked)
                {
                    Form1.UsunPracownika(lekarz);
                }

                if (rolaPielegniarka.Checked)
                {
                    Form1.UsunPracownika(pielegniarka);
                }
            }
            
            if (rolaAdministrator.Checked)
            {
                Administrator a = new Administrator(imie.Text, nazwisko.Text, Convert.ToInt64(pesel.Text), nazwaUzytkownika.Text, haslo.Text);
                Form1.DodajPracownika(a);
            }

            if (rolaLekarz.Checked)
            {
                Lekarz l = new Lekarz(imie.Text, nazwisko.Text, Convert.ToInt64(pesel.Text), nazwaUzytkownika.Text, haslo.Text, posada.Text, (Specializacja)specializacja.SelectedItem, Convert.ToInt64(numerPWZ));
                Form1.DodajPracownika(l);
            }

            if (rolaPielegniarka.Checked)
            {
                Pielegniarka p = new Pielegniarka(imie.Text, nazwisko.Text, Convert.ToInt64(pesel.Text), nazwaUzytkownika.Text, haslo.Text, posada.Text);
                Form1.DodajPracownika(p);
            }
            
            form3.Visible = true;
            Close();
        }

        private void Wroc_Click(object sender, EventArgs e)
        {
            form3.Visible = true;
            Close();
        }
    }
}
