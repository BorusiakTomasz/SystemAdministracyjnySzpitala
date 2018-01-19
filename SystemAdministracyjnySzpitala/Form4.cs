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
    /// <summary>
    ///     Okno służące do dodawanie, bądź edycji pracowników.
    /// </summary>
    public partial class Form4 : Form
    {
        private List<Specializacja> listaSpecializacji;
        private Form3 form3;
        private Administrator administrator;
        private Lekarz lekarz;
        private Pielegniarka pielegniarka;
        private bool isEdited;
        public ListBox lista;

        /// <summary>
        ///     Inicjalizuje wygląd domyślny dla dodawania nowego pracownika.
        /// </summary>
        /// <param name="form3"></param>
        public Form4(Form3 form3)
        {
            InitializeComponent();

            this.form3 = form3;
            isEdited = false;

            ZainicjujListeSpecializacji();
        }

        /// <summary>
        ///     Inicjalizuje wygląd dla edycji Administrator.
        /// </summary>
        /// <param name="form3">
        ///     Zmienna potrzeba mi była, aby sterować Form3.
        /// </param>
        /// <param name="a">
        ///     Przechowuje wybranego administratora.
        /// </param>
        /// <param name="lb_a">
        ///     Przechowuje referencje do listaAdministratorow, aby ją zaktualizować.
        /// </param>
        public Form4(Form3 form3, Administrator a, ref ListBox lb_a)
        {
            InitializeComponent();

            this.form3 = form3;
            administrator = a;
            isEdited = true;

            lista = lb_a;

            ZainicjujListeSpecializacji();
            WypelnijPola(a);
        }

        /// <summary>
        ///     Inicjalizuje wygląd dla edycji Lekarz.
        /// </summary>
        /// <param name="form3">
        ///     Zmienna potrzeba mi była, aby sterować Form3.
        /// </param>
        /// <param name="l">
        ///     Przechowuje wybranego lekarza.
        /// </param>
        /// <param name="lb_l">
        ///     Przechowuje referencje do listaLekarzy, aby ją zaktualizować.
        /// </param>
        public Form4(Form3 form3, Lekarz l, ref ListBox lb_l)
        {
            InitializeComponent();

            this.form3 = form3;
            lekarz = l;
            isEdited = true;

            lista = lb_l;

            ZainicjujListeSpecializacji();
            WypelnijPola(l);
        }

        /// <summary>
        ///     Inicjalizuje wygląd dla edycji Pielegniarka.
        /// </summary>
        /// <param name="form3">
        ///     Zmienna potrzeba mi była, aby sterować Form3.
        /// </param>
        /// <param name="p">
        ///     Przechowuje wybranego pielęgniarke.
        /// </param>
        /// <param name="lb_p">
        ///     Przechowuje referencje do listaPielegniarek, aby ją zaktualizować.
        /// </param>
        public Form4(Form3 form3, Pielegniarka p, ref ListBox lb_p)
        {
            InitializeComponent();

            this.form3 = form3;
            pielegniarka = p;
            isEdited = true;

            lista = lb_p;

            ZainicjujListeSpecializacji();
            WypelnijPola(p);
        }

        /// <summary>
        ///     Wypełnia specializacja danymi.
        /// </summary>
        private void ZainicjujListeSpecializacji()
        {
            listaSpecializacji = Enum.GetValues(typeof(Specializacja)).OfType<Specializacja>().ToList();
            specializacja.DataSource = listaSpecializacji;
        }

        /// <summary>
        ///     Funkcja użyta podczas edycji do wypełnienia pól formularza danymi wybranego pracownika.
        /// </summary>
        /// <typeparam name="T">
        ///     Obsługuje tylko 3 typy:
        ///       - Administrator,
        ///       - Lekarz,
        ///       - Pielegniarka.
        /// </typeparam>
        /// <param name="pracownik">
        ///     Przechowuje aktualnie wybranego pracownika.
        /// </param>
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

        /// <summary>
        ///     Zdarzenie, które blokuje pola nieużywane w tym obiekcie.
        /// </summary>
        private void rolaAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            specializacja.Enabled = false;
            specializacja.SelectedItem = null;
            posada.Enabled = false;
            numerPWZ.Enabled = false;
        }

        /// <summary>
        ///     W tym przypadku wszystkie pola są dostępne.
        /// </summary>
        private void rolaLekarz_CheckedChanged(object sender, EventArgs e)
        {
            specializacja.Enabled = true;
            posada.Enabled = true;
            numerPWZ.Enabled = true;
        }

        /// <summary>
        ///     Zdarzenie, które blokuje pola nieużywane w tym obiekcie.
        /// </summary>
        private void rolaPielegniarka_CheckedChanged(object sender, EventArgs e)
        {
            specializacja.Enabled = false;
            specializacja.SelectedItem = null;
            posada.Enabled = true;
            numerPWZ.Enabled = false;
        }

        /// <summary>
        ///     Zdarzenie dodaje, bądź edytuje pracownika w zależności od flagi isEdited.
        /// </summary>
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
                lista.DataSource = null;
                lista.Items.Clear();
                lista.DataSource = Form1.listaAdministratorow;
            }

            if (rolaLekarz.Checked)
            {
                Lekarz l = new Lekarz(imie.Text, nazwisko.Text, Convert.ToInt64(pesel.Text), nazwaUzytkownika.Text, haslo.Text, posada.Text, (Specializacja)specializacja.SelectedItem, Convert.ToInt64(numerPWZ));
                Form1.DodajPracownika(l);
                lista.DataSource = null;
                lista.Items.Clear();
                lista.DataSource = Form1.listaLekarzy;
            }

            if (rolaPielegniarka.Checked)
            {
                Pielegniarka p = new Pielegniarka(imie.Text, nazwisko.Text, Convert.ToInt64(pesel.Text), nazwaUzytkownika.Text, haslo.Text, posada.Text);
                Form1.DodajPracownika(p);
                lista.DataSource = null;
                lista.Items.Clear();
                lista.DataSource = Form1.listaPielegniarek;
            }
            
            form3.Visible = true;
            Close();
        }

        /// <summary>
        ///     Zdarzenie ma za zadanie przywrócić widoczność Form3 i zamknąć aktualny widok.
        /// </summary>
        private void Wroc_Click(object sender, EventArgs e)
        {
            form3.Visible = true;
            Close();
        }
    }
}
