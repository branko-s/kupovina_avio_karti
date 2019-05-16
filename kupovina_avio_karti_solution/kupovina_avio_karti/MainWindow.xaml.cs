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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace kupovina_avio_karti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool val_kor_ime, val_loz;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public static void Povratna_info_kor_ime_loz(TextBlock txtblck, bool duzina)
        {
            if (duzina) txtblck.Visibility = Visibility.Hidden;
            else
            {
                txtblck.Text = (string) App.Current.Resources["val_string_duzina"];
                txtblck.Visibility = Visibility.Visible;
            }
        }

        private void Aktivacija_dugmeta_potvrdi()
        {
            App.Aktivacija_dugmeta_potvrdi(bttn_potvrdi, val_kor_ime, val_loz);
        }

        private void Bttn_reg_click(object sender, RoutedEventArgs e)
        {
            Registracija r = new Registracija();

            r.txtbx_kor_ime.Text = txtbx_kor_ime.Text;
            r.psswrdbx_lozinka.Password = psswrdbx_lozinka.Password;

            r.Show();
            this.Close();
        }

        private void Bttn_potvrdi_Click(object sender, RoutedEventArgs e)
        {
            //fhsgjkdhkj
        }

        private void Bttn_preskoci_Click(object sender, RoutedEventArgs e)
        {
            //novi prozor
        }

        private void Txtbx_kor_ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int)Application.Current.Resources["min_br_kar_kor_ime_loz"]);

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine
            };

            val_kor_ime = true;
            foreach (bool val in validacija) val_kor_ime &= val;

            if (val_kor_ime) f = Farba.zelena;
            else f = Farba.crvena;

            App.Farbanje(txtbx_kor_ime, f);
            Povratna_info_kor_ime_loz(txtblck_kor_ime_val, validacija_duzine);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Psswrdbx_lozinka_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Farba f;

            bool validacija_duzine = App.Validacija_minimalne_duzine(sender, (int) Application.Current.Resources["min_br_kar_kor_ime_loz"]);

            List<bool> validacija = new List<bool>()
            {
                validacija_duzine
            };

            val_loz = true;
            foreach (bool val in validacija) val_loz &= val;

            if (val_loz) f = Farba.zelena;
            else f = Farba.crvena;
            
            App.Farbanje(psswrdbx_lozinka, txtbx_lozinka, bttn_vidljivost, f);
            Povratna_info_kor_ime_loz(txtblck_loz_val, validacija_duzine);
            Aktivacija_dugmeta_potvrdi();
        }

        private void Txtbx_lozinka_TextChanged(object sender, TextChangedEventArgs e)
        {
            psswrdbx_lozinka.Password = txtbx_lozinka.Text;
        }

        private void Bttn_vidljivost_Click(object sender, RoutedEventArgs e)
        {
            if (psswrdbx_lozinka.Width != 0)
            {
                psswrdbx_lozinka.Width = 0;
                psswrdbx_lozinka.IsTabStop = false;

                txtbx_lozinka.Width = (double) this.Resources["sirina_loz"];
                txtbx_lozinka.IsTabStop = true;

                txtbx_lozinka.Text = psswrdbx_lozinka.Password;
                txtbx_lozinka.SelectionStart = txtbx_lozinka.Text.Length;
                txtbx_lozinka.Focus();
            }
            else
            {
                txtbx_lozinka.Width = 0;
                txtbx_lozinka.IsTabStop = false;

                psswrdbx_lozinka.Width = (double) this.Resources["sirina_loz"];
                psswrdbx_lozinka.IsTabStop = true;

                psswrdbx_lozinka.Focus();

                App.Postavi_kursor_na_kraj();
            }
        }
    }
}