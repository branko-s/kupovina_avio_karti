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

        public MainWindow()
        {
            InitializeComponent();
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
            //validacija iz baze podataka.
        }

        private void Bttn_preskoci_Click(object sender, RoutedEventArgs e)
        {
            //novi prozor
        }

        private void Txtbx_kor_ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbx_kor_ime.Text.Length < 8)
            {
                txtblck_kor_ime_val.Visibility = Visibility.Visible;
                val_kor_ime = false;
                txtbx_kor_ime.BorderBrush = (Brush)Application.Current.Resources["crvena"];
            }
            else
            {
                txtblck_kor_ime_val.Visibility = Visibility.Hidden;
                val_kor_ime = true;
                txtbx_kor_ime.BorderBrush = (Brush) Application.Current.Resources["zelena"];
            }

            if ((val_kor_ime == true) && (val_loz == true)) bttn_potvrdi.IsEnabled = true;
            else bttn_potvrdi.IsEnabled = false;
        }

        private void Psswrdbx_lozinka_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psswrdbx_lozinka.Password.Length < 8)
            {
                val_loz = false;

                txtblck_loz_val.Visibility = Visibility.Visible;
                psswrdbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["crvena"];
                txtbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["crvena"];
                bttn_vidljivost.BorderBrush = (Brush)Application.Current.Resources["crvena"];
                bttn_vidljivost.Background = (ImageBrush)Application.Current.Resources["crveno_oko"];
            }
            else
            {
                val_loz = true;

                txtblck_loz_val.Visibility = Visibility.Hidden;
                psswrdbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["zelena"];
                txtbx_lozinka.BorderBrush = (Brush)Application.Current.Resources["zelena"];
                bttn_vidljivost.BorderBrush = (Brush)Application.Current.Resources["zelena"];
                bttn_vidljivost.Background = (ImageBrush)Application.Current.Resources["zeleno_oko"];
            }

            if ((val_kor_ime == true) && (val_loz == true)) bttn_potvrdi.IsEnabled = true;
            else bttn_potvrdi.IsEnabled = false;
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

                txtbx_lozinka.Width = (double)Application.Current.Resources["sirina_1_loz"];
                txtbx_lozinka.IsTabStop = true;

                txtbx_lozinka.Text = psswrdbx_lozinka.Password;
                txtbx_lozinka.SelectionStart = txtbx_lozinka.Text.Length;
                txtbx_lozinka.Focus();
            }
            else
            {
                txtbx_lozinka.Width = 0;
                txtbx_lozinka.IsTabStop = false;

                psswrdbx_lozinka.Width = (double)Application.Current.Resources["sirina_1_loz"];
                psswrdbx_lozinka.IsTabStop = true;

                psswrdbx_lozinka.Focus();

                // "hack"
                InputManager.Current.ProcessInput(new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.End){RoutedEvent = Keyboard.KeyDownEvent});
                // nakon promene lozinke sa vidljivo na nevidljivo, sa txtbx na psswrdbx simulira unos tipke "End" kako bi kursor postavio na kraj.
            }
        }
    }
}
