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
    ///     Okno służące do dodawania, edytowania, usuwania i wyświetlania danych na temat wszystkich pracowników, wraz z ich dyzurami (nie dotyczy administratorów).
    /// </summary>
    public partial class Form3 : Form
    {
        private Form1 form1;
        private Administrator administrator;

        /// <summary>
        ///     Gdy zaloguje się Administrator, zostanie wykonany ten konstruktor. Inicjalizacja całego formularza.
        /// </summary>
        /// <param name="form1">Zmienna potrzeba mi była, aby sterować Form1.</param>
        /// <param name="administrator">Zmienna przechowuje aktualnie zalogowanego użytkownika.</param>
        /// <param name="listaAdministratorow">Informacje dla listBox1.</param>
        /// <param name="listaLekarzy">Informacje dla listBox2.</param>
        /// <param name="listaPielegniarek">Informacje dla listBox3.</param>
        public Form3(Form1 form1, Administrator administrator, List<Administrator> listaAdministratorow, List<Lekarz> listaLekarzy, List<Pielegniarka> listaPielegniarek)
        {
            InitializeComponent();

            this.form1 = form1;
            this.administrator = administrator;

            listBox1.DataSource = listaAdministratorow;
            listBox2.DataSource = listaLekarzy;
            listBox3.DataSource = listaPielegniarek;

            listBox1.SelectedItem = administrator;
            listBox2.ClearSelected();
            listBox3.ClearSelected();

            monthCalendar1.Enabled = false;
        }

        /// <summary>
        ///     Zdarzenie ma za zadanie odznaczyć wszystkich innym pracowników, wyczyścić kalendarz i zablokować dodawanie/usuwanie dyzurów, gdyż Administrator nie posiada dyżurów.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.ClearSelected();
                listBox3.ClearSelected();
                monthCalendar1.RemoveAllBoldedDates();
                
                groupBox1.Enabled = false;
            }
        }

        /// <summary>
        ///     Zdarzenie ma za zadanie odznaczyć wszystkich innym pracowników, wypełnić kalendarz dyżurami wybranej osoby i umożliwić dodawanie/usuwanie dyżurów.
        /// </summary>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.ClearSelected();
                listBox3.ClearSelected();
                if ((listBox2.SelectedItem as Lekarz).Dyzury != null)
                    monthCalendar1.MonthlyBoldedDates = (listBox2.SelectedItem as Lekarz).Dyzury.ToArray();
                
                groupBox1.Enabled = true;
            }
        }

        /// <summary>
        ///     Zdarzenie ma za zadanie odznaczyć wszystkich innym pracowników, wypełnić kalendarz dyżurami wybranej osoby i umożliwić dodawanie/usuwanie dyżurów.
        /// </summary>
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                listBox1.ClearSelected();
                listBox2.ClearSelected();
                if ((listBox3.SelectedItem as Pielegniarka).Dyzury != null)
                    monthCalendar1.MonthlyBoldedDates = (listBox3.SelectedItem as Pielegniarka).Dyzury.ToArray();
                
                groupBox1.Enabled = true;
            }
        }

        /// <summary>
        ///     Zdarzenie otwiera okno dodawania/edycji (Form4) dla nowego pracowników, przy ukryciu aktualnego okna.
        /// </summary>
        private void DodajPracownika_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(this);
            f.Show();
            Visible = false;
        }

        /// <summary>
        ///     Zdarzenie otwiera okno dodawania/edycji (Form4) dla wybranego pracownika, przy ukryciu aktualnego okna.
        /// </summary>
        private void EdytujPracownika_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Form4 f = new Form4(this, listBox1.SelectedItem as Administrator, ref listBox1);
                f.Show();
                Visible = false;
            }

            if (listBox2.SelectedItem != null)
            {
                Form4 f = new Form4(this, listBox2.SelectedItem as Lekarz, ref listBox2);
                f.Show();
                Visible = false;
            }

            if (listBox3.SelectedItem != null)
            {
                Form4 f = new Form4(this, listBox3.SelectedItem as Pielegniarka, ref listBox3);
                f.Show();
                Visible = false;
            }
        }

        /// <summary>
        ///     Zdarzenie usuwa wskazanego pracownika z listy.
        /// </summary>
        private void UsunPracownika_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Administrator a = listBox1.SelectedItem as Administrator;
                Form1.UsunPracownika(a);
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                listBox1.DataSource = Form1.listaAdministratorow;
            }

            if (listBox2.SelectedItem != null)
            {
                Lekarz l = listBox2.SelectedItem as Lekarz;
                Form1.UsunPracownika(l);
                listBox2.DataSource = null;
                listBox2.Items.Clear();
                listBox2.DataSource = Form1.listaLekarzy;
            }

            if (listBox3.SelectedItem != null)
            {
                Pielegniarka p = listBox3.SelectedItem as Pielegniarka;
                Form1.UsunPracownika(p);
                listBox3.DataSource = null;
                listBox3.Items.Clear();
                listBox3.DataSource = Form1.listaPielegniarek;
            }
        }

        /// <summary>
        ///     Zdarzenie dodaje dyzur wskazanemu pracownikowi
        /// </summary>
        private void DodajDyzur_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                DodajDyzurLekarzowi();
            }

            if (listBox3.SelectedItem != null)
            {
                DodajDyzurPielegniarce();
            }
        }

        /// <summary>
        ///     Funkcja sprawdza:
        ///       1. Czy w wskazanym dniu lekarz o tej samej specializacji nie ma dyżuru,
        ///       2. Czy lekarz w tym miesiacu nie ma 10 dyżurów,
        ///       3. Czy lekarz nie ma dyżuru dzień wcześniej.
        ///       
        ///     Jeśli wszystkie wymagania zostały spełnione, dodaje dyżur wybranemu lekarzowi.
        /// </summary>
        private void DodajDyzurLekarzowi()
        {
            Lekarz l = listBox2.SelectedItem as Lekarz;
            List<Lekarz> lekarzeMajacyDyzur = ListaLekarzyMajacychDyzurTegoDnia(dateTimePicker1.Value);
            bool isEqual = false;

            foreach (Lekarz lekarz in lekarzeMajacyDyzur)
            {
                if (l.Specializacja.Equals(lekarz.Specializacja))
                {
                    isEqual = true;
                    break;
                }
            }

            if (isEqual)
            {
                MessageBox.Show("Tego dnia " + l.Specializacja.ToString() + " ma juz dyzur.");
            }
            else
            {
                if (!CzyWczorajMialDyzur(l, dateTimePicker1.Value))
                {
                    if (CzyMogeWziascDyzur(l))
                    {
                        l.Dyzury.Add(dateTimePicker1.Value);
                        monthCalendar1.AddBoldedDate(dateTimePicker1.Value);
                    }
                    else
                    {
                        MessageBox.Show("Posiada już 10 dyzurów.");
                    }
                } 
                else
                    MessageBox.Show("Poprzedniego dnia miał/a dyżur.");
            }
        }

        /// <summary>
        ///     Funkcja sprawdza:
        ///       1. Czy pielęgniarka w tym miesiacu nie ma 10 dyżurów,
        ///       2. Czy pielęgniarka nie ma dyżuru dzień wcześniej.
        ///       
        ///     Jeśli wszystkie wymagania zostały spełnione, dodaje dyżur wybranej pielęgniarce.
        /// </summary>
        private void DodajDyzurPielegniarce()
        {
            Pielegniarka p = listBox3.SelectedItem as Pielegniarka;

            if (!CzyWczorajMialDyzur(p, dateTimePicker1.Value))
            {
                if (CzyMogeWziascDyzur(p))
                {
                    p.Dyzury.Add(dateTimePicker1.Value);
                    monthCalendar1.AddBoldedDate(dateTimePicker1.Value);
                }
                else
                {
                    MessageBox.Show("Posiada już 10 dyzurów.");
                }
            }
            else
                MessageBox.Show("Poprzedniego dnia miał/a dyżur.");
        }

        /// <summary>
        ///     Funkcja sprawdza czy Lekarz/Pielegniarka ma mniej niż 10 dyżurów w miesiącu.
        /// </summary>
        /// <typeparam name="T">
        ///     Obsługuje tylko 2 typy:
        ///       - Lekarz,
        ///       - Pielegniarka.
        /// </typeparam>
        /// <param name="pracownik">
        ///     Przechowuje aktualnie wybranego pracownika.
        /// </param>
        /// <returns>
        ///     @true - pracownik ma mniej dyżurów niż 10 w tym miesiącu.
        ///     @false - pracownik ma już 10 dyżurów w tym miesiącu.
        /// </returns>
        private bool CzyMogeWziascDyzur<T>(T pracownik)
        {
            DateTime data = monthCalendar1.TodayDate;
            int counter = 0;
            
            if (pracownik is Lekarz)
            {
                Lekarz l = pracownik as Lekarz;
                foreach (DateTime element in l.Dyzury)
                {
                    if (data.Month.Equals(element.Month) && data.Year.Equals(element.Year))
                    {
                        counter++;
                    }
                }
            }

            if (pracownik is Pielegniarka)
            {
                Pielegniarka p = pracownik as Pielegniarka;

                foreach (DateTime element in p.Dyzury)
                {
                    if (data.Month.Equals(element.Month) && data.Year.Equals(element.Year))
                    {
                        counter++;
                    }
                }
            }
            
            if (counter < 10) return true;
            return false;
        }

        /// <summary>
        ///     Funkcja sprawdza jacy lekarze mają dyżur w podanym dniu.
        /// </summary>
        /// <param name="dzisiaj">
        ///     Przechowuje podaną date dyżuru.
        /// </param>
        /// <returns>
        ///     liste lekarzy którzy mają dyżur w podanym dniu.
        /// </returns>
        private List<Lekarz> ListaLekarzyMajacychDyzurTegoDnia(DateTime dzisiaj)
        {
            List<Lekarz> result = null;

            foreach (Lekarz lekarz in listBox2.DataSource as List<Lekarz>)
            {
                foreach (DateTime data in lekarz.Dyzury)
                {
                    if (dzisiaj.ToShortDateString().Equals(data.ToShortDateString()))
                    {
                        result.Add(lekarz);
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Funkcja sprawdza czy pracownik ma dyżur dzień wcześniej.
        /// </summary>
        /// <typeparam name="T">
        ///     Obsługuje tylko 2 typy:
        ///       - Lekarz,
        ///       - Pielegniarka.
        /// </typeparam>
        /// <param name="pracownik">
        ///     Przechowuje aktualnie wybranego pracownika.
        /// </param>
        /// <param name="dzien">
        ///     Przechowuje date dyżuru.
        /// </param>
        /// <returns>
        ///     @true - Pracownik ma dyżur dzień wcześniej.
        ///     @false - Pracownik NIE ma dyżuru dzień wcześniej.
        /// </returns>
        private bool CzyWczorajMialDyzur<T>(T pracownik, DateTime dzien)
        {
            DateTime wczoraj = dzien.AddDays(-1);

            if (pracownik is Lekarz)
            {
                Lekarz l = pracownik as Lekarz;

                foreach (DateTime element in l.Dyzury)
                {
                    if (wczoraj.Day.Equals(element.Day) && wczoraj.Month.Equals(element.Month) && wczoraj.Year.Equals(element.Year))
                    {
                        return true;
                    }
                }
            }

            if (pracownik is Pielegniarka)
            {
                Pielegniarka p = pracownik as Pielegniarka;

                foreach (DateTime element in p.Dyzury)
                {
                    if (wczoraj.Day.Equals(element.Day) && wczoraj.Month.Equals(element.Month) && wczoraj.Year.Equals(element.Year))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Zdarzenie usuwa dyzur wskazanemu pracownikowi
        /// </summary>
        private void UsunDyzor_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Lekarz l = listBox2.SelectedItem as Lekarz;
                l.Dyzury.Remove(dateTimePicker1.Value);
                monthCalendar1.RemoveBoldedDate(dateTimePicker1.Value);
                monthCalendar1.Refresh();
            }

            if (listBox3.SelectedItem != null)
            {
                Pielegniarka p = listBox3.SelectedItem as Pielegniarka;
                p.Dyzury.Remove(dateTimePicker1.Value);
                monthCalendar1.RemoveBoldedDate(dateTimePicker1.Value);
                monthCalendar1.Refresh();
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
