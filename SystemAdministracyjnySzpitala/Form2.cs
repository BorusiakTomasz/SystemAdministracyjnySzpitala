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
    ///     Okno służące do wyświetlania informacji na temat listaLekarzy i listaPielegniarek wraz z ich dyzurami.
    /// </summary>
    public partial class Form2 : Form
    {
        private Lekarz lekarz;
        private Pielegniarka pielegniarka;
        private Form1 form1;

        /// <summary>
        ///     Gdy zaloguje się Lekarz, zostanie wykonany ten konstruktor. Inicjalizacja całego formularza.
        /// </summary>
        /// <param name="form1">Zmienna potrzeba mi była, aby sterować Form1.</param>
        /// <param name="lekarz">Zmienna przechowuje aktualnie zalogowanego użytkownika.</param>
        /// <param name="listaLekarzy">Informacje dla listBox1.</param>
        /// <param name="listaPielegniarek">Informacje dla listBox2.</param>
        public Form2(Form1 form1, Lekarz lekarz, List<Lekarz> listaLekarzy, List<Pielegniarka> listaPielegniarek)
        {
            InitializeComponent();

            this.form1 = form1;
            this.lekarz = lekarz;
            pielegniarka = null;

            listBox1.DataSource = listaLekarzy;
            listBox2.DataSource = listaPielegniarek;

            listBox1.SelectedItem = lekarz;
            listBox2.SelectedItem = null;

            monthCalendar1.MonthlyBoldedDates = lekarz.Dyzury.ToArray();
        }

        /// <summary>
        ///     Natomiast jeśli zaloguje się Pielegniarka to wykona się ten konstrukor. Inicjalizacja całego formularza.
        /// </summary>
        /// <param name="form1">Zmienna potrzeba mi była, aby sterować Form1.</param>
        /// <param name="pielegniarka">Zmienna przechowuje aktualnie zalogowanego użytkownika.</param>
        /// <param name="listaLekarzy">Informacje dla listBox1.</param>
        /// <param name="listaPielegniarek">Informacje dla listBox2.</param>
        public Form2(Form1 form1, Pielegniarka pielegniarka, List<Lekarz> listaLekarzy, List<Pielegniarka> listaPielegniarek)
        {
            InitializeComponent();

            this.form1 = form1;
            lekarz = null;
            this.pielegniarka = pielegniarka;

            listBox1.DataSource = listaLekarzy;
            listBox2.DataSource = listaPielegniarek;

            listBox1.SelectedItem = null;
            listBox2.SelectedItem = pielegniarka;

            monthCalendar1.MonthlyBoldedDates = pielegniarka.Dyzury.ToArray();
        }

        /// <summary>
        ///     Zdarzęnie ma za zadanie odznaczyć wszystkie pozostałe pola z listBox2 i wypełnić kalendarz dyżurami aktualnie wybranej osoby.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.SelectedItem = null;
                lekarz = listBox1.SelectedItem as Lekarz;
                monthCalendar1.MonthlyBoldedDates = lekarz.Dyzury.ToArray();
            }
        }

        /// <summary>
        ///     Zdarzęnie ma za zadanie odznaczyć wszystkie pozostałe pola z listBox1 i wypełnić kalendarz dyżurami aktualnie wybranej osoby.
        /// </summary>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.SelectedItem = null;
                pielegniarka = listBox2.SelectedItem as Pielegniarka;
                monthCalendar1.MonthlyBoldedDates = pielegniarka.Dyzury.ToArray();
            }
        }

        /// <summary>
        ///     Zdarzenie ma za zadanie przywrócić widoczność Form1 i zamknąć aktualny widok.
        /// </summary>
        private void Wroc_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            Close();
        }
    }
}
