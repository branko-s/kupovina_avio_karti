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
        bool val_kor_ime = false, val_loz = false;
        Color crvena, zelena;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bttn_reg_click(object sender, RoutedEventArgs e)
        {
            Registracija r = new Registracija();
            r.Show();
            this.Close();
            //dodati da se vred loz i kor_ime prenose izmedju prozora.
        }

        private void Bttn_potvrdi_Click(object sender, RoutedEventArgs e)
        {
            //validacija iz baze podataka.
        }

        private void Txtbx_kor_ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbx_kor_ime.Text.Length < 8)
            {
                lbl_kor_ime_val.Visibility = Visibility.Visible;
                val_kor_ime = false;
                txtbx_kor_ime.BorderBrush = (Brush)Application.Current.Resources["crvena"];
            }
            else
            {
                lbl_kor_ime_val.Visibility = Visibility.Hidden;
                val_kor_ime = true;
                txtbx_kor_ime.BorderBrush = (Brush)Application.Current.Resources["zelena"];
            }

            if ((val_kor_ime == true) && (val_loz == true)) bttn_potvrdi.IsEnabled = true;
            else bttn_potvrdi.IsEnabled = false;
        }

        private void Bttn_vidljivost_Click(object sender, RoutedEventArgs e)
        {
            if (psswrdbx_lozinka.Visibility == Visibility.Visible)
            {
                psswrdbx_lozinka.Visibility = Visibility.Hidden;
                txtbx_lozinka.Visibility = Visibility.Visible;
            }
            else
            {
                psswrdbx_lozinka.Visibility = Visibility.Visible;
                txtbx_lozinka.Visibility = Visibility.Hidden;
            }
        }

        private void Txtbx_lozinka_TextChanged(object sender, TextChangedEventArgs e)
        {
            psswrdbx_lozinka.Password = txtbx_lozinka.Text;
        }

        private void Psswrdbx_lozinka_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtbx_lozinka.Text = psswrdbx_lozinka.Password;

            if (psswrdbx_lozinka.Password.Length < 8)
            {
                lbl_loz_val.Visibility = Visibility.Visible;
                val_loz = false;
                psswrdbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["crvena"];
                txtbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["crvena"];
                bttn_vidljivost.BorderBrush = (Brush)Application.Current.Resources["crvena"];
            }
            else
            {
                lbl_loz_val.Visibility = Visibility.Hidden;
                val_loz = true;
                psswrdbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["zelena"];
                txtbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["zelena"];
                bttn_vidljivost.BorderBrush = (Brush)Application.Current.Resources["zelena"];
            }

            if ((val_kor_ime == true) && (val_loz == true)) bttn_potvrdi.IsEnabled = true;
            else bttn_potvrdi.IsEnabled = false;
        }
    }
}
