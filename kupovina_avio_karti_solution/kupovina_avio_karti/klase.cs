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
        private List<let> dolazni_letovi;
        private List<let> odlazni_letovi;
    }

    class avio_kompanija
    {
        //private short id;
        private string naziv;
        //private List<let> lista_letova;
        private List<pilot> lista_pilota;
    }

    class avion
    {
        //private short id;
        private string naziv;
        private avio_kompanija vlasnik;
        private konfiguracija_sedista konfig_sed;
    }

    class let
    {
        private long broj_leta;
        private pilot pilot;
        private DateTimeOffset vreme_polaska;
        private DateTimeOffset vreme_dolaska;
        private int cena;
        private aerodrom destinacija;
        private aerodrom odrediste;
        private avion av;
        private avio_kompanija a_komp;
    }

    class konfiguracija_sedista
    {
        private byte br_redova;
        private byte br_kolona;
        private sediste[,] matrica_sedista;
    }

    class sediste
    {
        private byte red;
        private byte kolona;
        private char klasa;
        private char zauzetost;
    }

    class karta
    {
        //private long id;
        private let let;
        private sediste sediste;
        private korisnik putnik;
        private string kapija;
        private int cena;
    }

    class pilot
    {
        //private byte id;
        private string ime_prezime;
    }
}
