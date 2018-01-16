using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SystemAdministracyjnySzpitala
{
    [Serializable]
    public class Administrator : Pracownik, ISerializable
    {
        public Administrator(string imie, string nazwisko, long pesel, string nazwaUzytkownika, string haslo) : base(imie, nazwisko, pesel, nazwaUzytkownika, haslo) {}

        //serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Imie", Imie);
            info.AddValue("Nazwisko", Nazwisko);
            info.AddValue("Pesel", Pesel);
            info.AddValue("NazwaUzytkownika", NazwaUzytkownika);
            info.AddValue("Haslo", Haslo);
        }

        //deserialization
        public Administrator(SerializationInfo info, StreamingContext context)
        {
            Imie = (string)info.GetValue("Imie", typeof(string));
            Nazwisko = (string)info.GetValue("Nazwisko", typeof(string));
            Pesel = (long)info.GetValue("Pesel", typeof(long));
            NazwaUzytkownika = (string)info.GetValue("NazwaUzytkownika", typeof(string));
            Haslo = (string)info.GetValue("Haslo", typeof(string));
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }
    }
}
