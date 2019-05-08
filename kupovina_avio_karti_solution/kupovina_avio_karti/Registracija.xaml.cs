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
        bool val_kor_ime = false, val_loz = false;

        public Registracija()
        {
            InitializeComponent();
        }

        private void Bttn_odustani_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Txtbx_ime_TextChanged(object sender, TextChangedEventArgs e)
        {
            // regex
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
                txtbx_kor_ime.BorderBrush = (Brush)Application.Current.Resources["zelena"];
            }

            if ((val_kor_ime == true) && (val_loz == true)) bttn_potvrdi.IsEnabled = true;
            else bttn_potvrdi.IsEnabled = false;
        }

        private void Psswrdbx_lozinka_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox psswrdbx = (PasswordBox)sender;
            TextBox txtbx;
            TextBlock txtblck;


            if (psswrdbx.Name == "psswrdbx_lozinka")
            {
                psswrdbx = psswrdbx_lozinka;
                txtbx = txtbx_lozinka;

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
            else
            {
                if(psswrdbx.Password != psswrdbx_lozinka.Password)
                    // napisati funkcije crveno i zeleno da se kod ne ponavlja
            }

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
            Button bttn = (Button) sender;
            PasswordBox psswrdbx;
            TextBox txtbx;


            if (bttn.Name == "bttn_vidljivost")
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

                txtbx.Width = (double)Application.Current.Resources["sirina_2_loz"];
                txtbx.IsTabStop = true;

                txtbx.Text = psswrdbx.Password;
                txtbx.SelectionStart = txtbx.Text.Length;
                txtbx.Focus();
            }
            else
            {
                txtbx.Width = 0;
                txtbx.IsTabStop = false;

                psswrdbx.Width = (double)Application.Current.Resources["sirina_2_loz"];
                psswrdbx.IsTabStop = true;

                psswrdbx.Focus();

                // "hack"
                InputManager.Current.ProcessInput(new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.End) { RoutedEvent = Keyboard.KeyDownEvent });
                // nakon promene lozinke sa vidljivo na nevidljivo, sa txtbx na psswrdbx simulira unos tipke "End" kako bi kursor postavio na kraj.
            }
        }
    }
}