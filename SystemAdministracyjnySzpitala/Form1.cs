using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemAdministracyjnySzpitala
{
    /// <summary>
    ///     Główna klasa programu, która przechowuje listy wszystkich obiektów do obsługi listBox'ów.
    /// </summary>
    public partial class Form1 : Form
    {
        public static List<Lekarz> listaLekarzy;
        public static List<Pielegniarka> listaPielegniarek;
        public static List<Administrator> listaAdministratorow;

        /// <summary>
        ///     Konstruktor ma za zadanie wypełnić wszystkie listy danymi z plików.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ZainicjujListeLekarzy();
            ZainicjujListePielegniarek();
            ZainicjujListeAdministratorow();
        }
        
        /// <summary>
        ///     Funkcja ma za zadanie odczytac(zdeserializować) dane zapisane w pliku, innymi słowy odczyt z pliku i zapisanie do listaLekarzy.
        /// </summary>
        private void ZainicjujListeLekarzy()
        {
            Stream stream = File.Open("LekarzDB.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listaLekarzy = (List<Lekarz>)bf.Deserialize(stream);
            stream.Close();
        }

        /// <summary>
        ///     Funkcja ma za zadanie odczytac(zdeserializować) dane zapisane w pliku, innymi słowy odczyt z pliku i zapisanie do listaPielegniarek.
        /// </summary>
        private void ZainicjujListePielegniarek()
        {
            Stream stream = File.Open("PielegniarkaDB.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listaPielegniarek = (List<Pielegniarka>)bf.Deserialize(stream);
            stream.Close();
        }

        /// <summary>
        ///     Funkcja ma za zadanie odczytac(zdeserializować) dane zapisane w pliku, innymi słowy odczyt z pliku i zapisanie do listaAdministratorów.
        /// </summary>
        private void ZainicjujListeAdministratorow()
        {
            Stream stream = File.Open("AdministratorDB.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listaAdministratorow = (List<Administrator>)bf.Deserialize(stream);
            stream.Close();
        }

        /// <summary>
        ///     Zdarzenie sprawdza kto chce się zalogować i gdy dane były poprawne otwiera nowe okno z odpowiednim widokiem, a jeśli nie to wyświetli komunikat.
        ///     Po prawidłowym zalogowaniu się osoby zostaje otwarte odpowiednie okno (Lekarz/Pielegniarka - Form2, Administrator - Form3), a okno logowania zostaje ukryte.
        /// </summary>
        private void Zaloguj_Click(object sender, EventArgs e)
        {
            bool isLogin = false;

            if (nazwaUzytkownika.Text != "" && haslo.Text != "")
            {
                foreach (Lekarz l in listaLekarzy)
                {
                    if (l.NazwaUzytkownika.Equals(nazwaUzytkownika.Text) && l.Haslo.Equals(haslo.Text))
                    {
                        Form2 f = new Form2(this, l, listaLekarzy, listaPielegniarek);
                        f.Show();
                        Visible = false;
                        nazwaUzytkownika.Text = null;
                        haslo.Text = null;
                        isLogin = true;
                        break;
                    }
                }

                if (!isLogin)
                    foreach (Pielegniarka p in listaPielegniarek)
                    {
                        if (p.NazwaUzytkownika.Equals(nazwaUzytkownika.Text) && p.Haslo.Equals(haslo.Text))
                        {
                            Form2 f = new Form2(this, p, listaLekarzy, listaPielegniarek);
                            f.Show();
                            Visible = false;
                            nazwaUzytkownika.Text = null;
                            haslo.Text = null;
                            isLogin = true;
                            break;
                        }
                    }

                if (!isLogin)
                    foreach (Administrator a in listaAdministratorow)
                    {
                        if (a.NazwaUzytkownika.Equals(nazwaUzytkownika.Text) && a.Haslo.Equals(haslo.Text))
                        {
                            Form3 f = new Form3(this, a, listaAdministratorow, listaLekarzy, listaPielegniarek);
                            f.Show();
                            Visible = false;
                            nazwaUzytkownika.Text = null;
                            haslo.Text = null;
                            isLogin = true;
                            break;
                        }
                    }

                if (!isLogin)
                    MessageBox.Show("Złe dane logowania, bądź brak takiego użytkownika");
            }
            else 
            {
                MessageBox.Show("Nie wpisano danych.");
            }
        }

        /// <summary>
        ///     Zdarzenie zapisuje(serializuje) dane z list do pliku i zamyka aplikacje.
        /// </summary>
        private void Zamknij_Click(object sender, EventArgs e)
        {
            ZapiszDaneAdministratorow();
            ZapiszDaneLekarzy();
            ZapiszDanePielegniarek();

            Application.Exit();
        }

        /// <summary>
        ///     Funkcja zapisuje(serializuje) dane z listaAdministratorów do pliku.
        /// </summary>
        private void ZapiszDaneAdministratorow()
        {
            Stream stream = File.Open("AdministratorDB.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, listaAdministratorow);
            stream.Close();
        }

        /// <summary>
        ///     Funkcja zapisuje(serializuje) dane z listaLekarzy do pliku.
        /// </summary>
        private void ZapiszDaneLekarzy()
        {
            Stream stream = File.Open("LekarzDB.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, listaLekarzy);
            stream.Close();
        }

        /// <summary>
        ///     Funkcja zapisuje(serializuje) dane z listaPielegniarek do pliku.
        /// </summary>
        private void ZapiszDanePielegniarek()
        {
            Stream stream = File.Open("PielegniarkaDB.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, listaPielegniarek);
            stream.Close();
        }

        /// <summary>
        ///     Funkcja dodaje "pracownika" do odpowiadającej mu listy. Dziala to na takiej zasadzie, ze gdy użyje tej funkcji na obiekcie Administrator to Administrator zostanie dodany do 
        ///     listaAdministratorow. Jeśli to był Lekarz to do listaLekarzy zostanie dodany. Na potrzeby programu funkcja moze przyjac tylko 3 typy danych - Administrator, Lekarz i Pielegniarka.
        /// </summary>
        /// <typeparam name="T">
        ///     Obsługuje tylko 3 typy:
        ///       - Administrator,
        ///       - Lekarz,
        ///       - Pielegniarka.
        /// </typeparam>
        /// <param name="pracownik">
        ///     Przechowuje pracownika, który ma zostać dodany.
        /// </param>
        public static void DodajPracownika<T>(T pracownik)
        {
            if (pracownik is Administrator)
            {
                Administrator a = pracownik as Administrator;
                listaAdministratorow.Add(a);
            }

            if (pracownik is Lekarz)
            {
                Lekarz l = pracownik as Lekarz;
                listaLekarzy.Add(l);
            }

            if (pracownik is Pielegniarka)
            {
                Pielegniarka p = pracownik as Pielegniarka;
                listaPielegniarek.Add(p);
            }
        }

        /// <summary>
        ///     Analogicznie jak poprzednia, tylko ze do usuwania z listy. Program wyszukuje pracownika do usunięcia za pomocą obiektu, który został mu dostarczony.
        /// </summary>
        /// <typeparam name="T">
        ///     Obsługuje tylko 3 typy:
        ///       - Administrator,
        ///       - Lekarz,
        ///       - Pielegniarka.
        /// </typeparam>
        /// <param name="pracownik">
        ///     Przechowuje pracownika, który ma zostać usunięty.
        /// </param>
        public static void UsunPracownika<T>(T pracownik)
        {
            if (pracownik is Administrator)
            {
                Administrator a = pracownik as Administrator;
                listaAdministratorow.Remove(a);
            }

            if (pracownik is Lekarz)
            {
                Lekarz l = pracownik as Lekarz;
                listaLekarzy.Remove(l);
            }

            if (pracownik is Pielegniarka)
            {
                Pielegniarka p = pracownik as Pielegniarka;
                listaPielegniarek.Remove(p);
            }
        }
    }
}
