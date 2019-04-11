using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kupovina_avio_karti
{
    class korisnik
    {
        private string username;
        private string password;
        private string email;
        private string ime_prezime;
        private string adresa;
        private char pol;
        private char tip;
        private List<karta> kupljene_karte;
    }

    class aerodrom
    {
        //private short id;
        private string naziv;
        private string grad;
        private let dolazni_letovi;
        private let odlazni_letovi;
    }

    class avio_kompanija
    {
        //private short id;
        private string naziv;
        private List<let> letovi;
        private List<pilot> piloti;
    }

    class let
    {
        //private long broj_leta;
        private pilot pilot;
        private DateTimeOffset vreme_polaska;
        private DateTimeOffset vreme_dolaska;
        private int cena;
        private aerodrom destinacija;
        private aerodrom odrediste;
        private avion avion;
        private avio_kompanija avio_kompanija;
    }

    class avion
    {
        //id
    }

    class karta
    {

    }

    class pilot
    {

    }
}
