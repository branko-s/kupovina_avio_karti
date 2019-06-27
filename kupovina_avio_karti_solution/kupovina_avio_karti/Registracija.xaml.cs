using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kupovina_avio_karti
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        private bool val_ime, val_pol, val_ulica, val_broj, val_grad, val_pos_br, val_email, val_kor_ime, val_loz, val_loz_2;

        public Registracija()
        {
            InitializeComponent();
        }

        private string Povratna_info(bool email_duzina, bool email_sadrzaj, bool email_baza_pod) //za email
        {
            if (txtbx_email.Text.Length == 0) return "";
            else if (!email_baza_pod || !email_duzina) return "E-mail nije u zeljenom formatu.";
            else if (!email_baza_pod) return "E-mail je vec registrovan u bazi podataka.";
            else return "";
        }

        private string Povratna_info(object obj, bool duzina, bool sadrzaj, bool baza_pod) // za kor_ime i loz
        {
            string val_string_baza_pod;

            if (obj is TextBox) val_string_baza_pod = "Korisničko ime je zauzeto.";
            else val_string_baza_pod = "Lozinka je zauzeta.";

            if (!duzina) return (string) App.Current.Resources["val_string_duzina"];
            else if (!sadrzaj) return (string)App.Current.Resources["val_string_sadrzaj"];
            else if (!baza_pod) return val_string_baza_pod;
            else return "";
        }

        private void Aktivacija_dugmeta_potvrdi()
        {
            App.Aktivacija_dugmeta_potvrdi(bttn_potvrdi, val_ime, val_pol, val_ulica, val_broj, val_grad, val_pos_br, val_email, val_kor_ime, val_loz, val_loz_2);
        }

        private bool Jednakost_lozinki(string loz_1, string loz_2)
        {
            bool jednakost;
            Farba f;

            if ((loz_1 == loz_2) && loz_2!="")
            {
                jednakost = true;
                f = Farba.zelena;
            }
            else
            {
                jednakost = false;
                f = Farba.crvena;
            }

            App.Farbanje(psswrdbx_lozinka_2, txtbx_lozinka_2, bttn_vidljivost_2, f);

            return jednakost;
        }

        private void Txtbx_ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_ime"]);
            bool validacija_sadrzaj = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
            };

            val_ime = true;
            foreach (bool val in validacija) val_ime &= val;

            if (val_ime) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje((TextBox) sender, f);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Rdbttn_pol_Checked(object sender, RoutedEventArgs e)
        {
            val_pol = true;
            Aktivacija_dugmeta_potvrdi();
        }

        private void Txtbx_ulica_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_ulica"]);
            bool validacija_sadrzaj = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
            };

            val_ulica = true;
            foreach (bool val in validacija) val_ulica &= val;

            if (val_ulica) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje((TextBox)sender, f);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Txtbx_broj_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_broj"]);
            bool validacija_sadrzaj = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
            };

            val_broj = true;
            foreach (bool val in validacija) val_broj &= val;

            if (val_broj) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje((TextBox)sender, f);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Txtbx_grad_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_grad"]);
            bool validacija_sadrzaj = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
            };

            val_grad = true;
            foreach (bool val in validacija) val_grad &= val;

            if (val_grad) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje((TextBox)sender, f);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Txtbx_postanski_br_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_pos_br"]);
            bool validacija_sadrzaj = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
            };

            val_pos_br = true;
            foreach (bool val in validacija) val_pos_br &= val;

            if (val_pos_br) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje((TextBox)sender, f);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Txtbx_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_email"]);
            bool validacija_sadrzaj = true;
            bool validacija_baza_pod = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
                validacija_baza_pod
            };

            val_email = true;
            foreach (bool val in validacija) val_email &= val;

            if (val_email) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje((TextBox)sender, f);
            txtblck_email_val.Text = Povratna_info(validacija_duzine, validacija_sadrzaj, validacija_baza_pod);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Txtbx_kor_ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_kor_ime_loz"]);
            bool validacija_sadrzaj = true;
            bool validacija_baza_pod = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
                validacija_baza_pod
            };

            val_kor_ime = true;
            foreach (bool val in validacija) val_kor_ime &= val;

            if (val_kor_ime) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje(txtbx_kor_ime, f);
            txtblck_kor_ime_val.Text = Povratna_info(sender, validacija_duzine, validacija_sadrzaj, validacija_baza_pod);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Psswrdbx_lozinka_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Farba f;
            bool aktivator;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_kor_ime_loz"]);
            bool validacija_sadrzaj = true;
            bool validacija_baza_pod = true;

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine,
                validacija_sadrzaj,
                validacija_baza_pod
            };

            val_loz = true;
            foreach (bool val in validacija) val_loz &= val;

            if (val_loz)
            {
                f = Farba.zelena;
                aktivator = true;
            }
            else
            {
                f = Farba.crvena;
                aktivator = false;
                psswrdbx_lozinka_2.Password = "";
                txtbx_lozinka_2.Text = "";
                txtblck_loz_val_2.Text = "";
            }

            psswrdbx_lozinka_2.IsEnabled = aktivator;
            txtbx_lozinka_2.IsEnabled = aktivator;
            bttn_vidljivost_2.IsEnabled = aktivator;

            App.Farbanje(psswrdbx_lozinka, txtbx_lozinka, bttn_vidljivost, f);
            txtblck_loz_val.Text = Povratna_info(sender, validacija_duzine, validacija_sadrzaj, validacija_baza_pod);
            Aktivacija_dugmeta_potvrdi();
            val_loz_2 = Jednakost_lozinki(psswrdbx_lozinka.Password, psswrdbx_lozinka_2.Password);
        }

        private void Txtbx_lozinka_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((TextBox) sender == txtbx_lozinka)
            {
                psswrdbx_lozinka.Password = txtbx_lozinka.Text;
            }
            else
            {
                psswrdbx_lozinka_2.Password = txtbx_lozinka_2.Text;
            }
        }

        private void Psswrdbx_lozinka_2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            val_loz_2 = Jednakost_lozinki(psswrdbx_lozinka.Password, psswrdbx_lozinka_2.Password);
            Aktivacija_dugmeta_potvrdi();

            if (val_loz_2) txtblck_loz_val_2.Text = "";
            else txtblck_loz_val_2.Text = "Lozinke se ne poklapaju";
        }

        private void Psswrdbx_lozinka_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            App.Postavi_kursor_na_kraj();
        }

        private void Txtbx_kor_ime_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }

        private void Bttn_vidljivost_Click(object sender, RoutedEventArgs e)
        {
            Button bttn = (Button) sender;
            PasswordBox psswrdbx;
            TextBox txtbx;


            if (bttn == bttn_vidljivost)
            {
                psswrdbx = psswrdbx_lozinka;
                txtbx = txtbx_lozinka;
            }
            else
            {
                psswrdbx = psswrdbx_lozinka_2;
                txtbx = txtbx_lozinka_2;
            }

            if (psswrdbx.Width != 0)
            {
                psswrdbx.Width = 0;
                psswrdbx.IsTabStop = false;

                txtbx.Width = (double) this.Resources["sirina_loz"];
                txtbx.IsTabStop = true;

                txtbx.Text = psswrdbx.Password;
                txtbx.SelectionStart = txtbx.Text.Length;
                txtbx.Focus();
            }
            else
            {
                txtbx.Width = 0;
                txtbx.IsTabStop = false;

                psswrdbx.Width = (double) this.Resources["sirina_loz"];
                psswrdbx.IsTabStop = true;

                psswrdbx.Focus();

                App.Postavi_kursor_na_kraj();
            }
        }

        private void Bttn_odustani_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Bttn_potvrdi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}