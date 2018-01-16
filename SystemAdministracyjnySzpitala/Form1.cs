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
    public partial class Form1 : Form
    {
        private static List<Lekarz> listaLekarzy;
        private static List<Pielegniarka> listaPielegniarek;
        private static List<Administrator> listaAdministratorow;

        public Form1()
        {
            InitializeComponent();
            ZainicjujListeLekarzy();
            ZainicjujListePielegniarek();
            ZainicjujListeAdministratorow();
        }
        
        private void ZainicjujListeLekarzy()
        {
            Stream stream = File.Open("LekarzDB.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listaLekarzy = (List<Lekarz>)bf.Deserialize(stream);
            stream.Close();
        }
        
        private void ZainicjujListePielegniarek()
        {
            Stream stream = File.Open("PielegniarkaDB.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listaPielegniarek = (List<Pielegniarka>)bf.Deserialize(stream);
            stream.Close();
        }
        
        private void ZainicjujListeAdministratorow()
        {
            Stream stream = File.Open("AdministratorDB.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            listaAdministratorow = (List<Administrator>)bf.Deserialize(stream);
            stream.Close();
        }

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

        private void Zamknij_Click(object sender, EventArgs e)
        {
            ZapiszDaneAdministratorow();
            ZapiszDaneLekarzy();
            ZapiszDanePielegniarek();

            Application.Exit();
        }

        private void ZapiszDaneAdministratorow()
        {
            Stream stream = File.Open("AdministratorDB.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, listaAdministratorow);
            stream.Close();
        }

        private void ZapiszDaneLekarzy()
        {
            Stream stream = File.Open("LekarzDB.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, listaLekarzy);
            stream.Close();
        }

        private void ZapiszDanePielegniarek()
        {
            Stream stream = File.Open("PielegniarkaDB.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, listaPielegniarek);
            stream.Close();
        }

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
