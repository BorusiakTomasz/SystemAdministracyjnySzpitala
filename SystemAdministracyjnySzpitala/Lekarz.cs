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
    public class Lekarz : Pracownik, ISerializable
    {
        public string Posada { get; set; }
        public Specializacja Specializacja { get; set; }
        public long NumerPWZ { get; set; }
        public List<DateTime> Dyzury { get; set; }

        public Lekarz()
        {
            Dyzury = new List<DateTime>();
        }

        public Lekarz(string imie, string nazwisko, long pesel, string nazwaUzytkownika, string haslo, string posada, 
            Specializacja specializacja, long numerPWZ) : base(imie, nazwisko, pesel, nazwaUzytkownika, haslo)
        {
            Posada = posada;
            Specializacja = specializacja;
            NumerPWZ = numerPWZ;
            Dyzury = new List<DateTime>();
        }

        //serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Imie", Imie);
            info.AddValue("Nazwisko", Nazwisko);
            info.AddValue("Pesel", Pesel);
            info.AddValue("NazwaUzytkownika", NazwaUzytkownika);
            info.AddValue("Haslo", Haslo);
            info.AddValue("Posada", Posada);
            info.AddValue("Specializacja", Specializacja);
            info.AddValue("NumerPWZ", NumerPWZ);
            info.AddValue("Dyzury", Dyzury);
        }

        //deserialization
        public Lekarz(SerializationInfo info, StreamingContext context)
        {
            Imie = (string)info.GetValue("Imie", typeof(string));
            Nazwisko = (string)info.GetValue("Nazwisko", typeof(string));
            Pesel = (long)info.GetValue("Pesel", typeof(long));
            NazwaUzytkownika = (string)info.GetValue("NazwaUzytkownika", typeof(string));
            Haslo = (string)info.GetValue("Haslo", typeof(string));
            Posada = (string)info.GetValue("Posada", typeof(string));
            Specializacja = (Specializacja)info.GetValue("Specializacja", typeof(Specializacja));
            NumerPWZ = (long)info.GetValue("NumerPWZ", typeof(long));
            Dyzury = (List<DateTime>)info.GetValue("Dyzury", typeof(List<DateTime>));
            Posada = (string)info.GetValue("Posada", typeof(string));
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }
    }
}
