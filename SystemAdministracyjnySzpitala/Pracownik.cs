using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemAdministracyjnySzpitala
{
    public class Pracownik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public long Pesel { get; set; }
        public string NazwaUzytkownika { get; set; }
        public string Haslo { get; set; }

        public Pracownik() {}

        public Pracownik(string imie, string nazwisko, long pesel, string nazwaUzytkownika, string haslo)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            NazwaUzytkownika = nazwaUzytkownika;
            Haslo = haslo;
        }
    }
}
