using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace kupovina_avio_karti
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public enum Farba { crvena, zelena, plava };

    public partial class App : Application
    {
        public static void Farbanje(PasswordBox psswrdbx, TextBox txtbx, Button bttn, Farba f)
        {
            Brush boja;
            ImageBrush pozadina;

            if(f == Farba.crvena)
            {
                boja = (Brush) Application.Current.Resources["crvena"];
                pozadina = (ImageBrush) Application.Current.Resources["crveno_oko"];
            }
            else
            {
                boja = (Brush) Application.Current.Resources["zelena"];
                pozadina = (ImageBrush) Application.Current.Resources["zeleno_oko"];
            }
            
            psswrdbx.BorderBrush = boja;
            txtbx.BorderBrush = boja;
            bttn.BorderBrush = boja;
            bttn.Background = pozadina;
        }

        public static void Farbanje(TextBox txtbx, Farba f)
        {
            Brush boja;

            if (f == Farba.crvena)
            {
                boja = (Brush)Application.Current.Resources["crvena"];
            }
            else
            {
                boja = (Brush)Application.Current.Resources["zelena"];
            }

            txtbx.BorderBrush = boja;
        }

        public static void Postavi_kursor_na_kraj()
        {
            // "hack"
            InputManager.Current.ProcessInput(new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.End) { RoutedEvent = Keyboard.KeyDownEvent });
            // nakon promene lozinke sa vidljivo na nevidljivo, sa txtbx na psswrdbx simulira unos tipke "End" kako bi kursor postavio na kraj.
        }

        public static bool Validacija_minimalne_duzine(object obj, int min_br_kar)
        {
            bool validacija;

            if (obj is TextBox)
            {
                TextBox txtbx = (TextBox)obj;

                if (txtbx.Text.Length < min_br_kar) validacija = false;
                else validacija = true;
            }
            else
            {
                PasswordBox psswrdbx = (PasswordBox)obj;

                if (psswrdbx.Password.Length < min_br_kar) validacija = false;
                else validacija = true;
            }
            return validacija;
        }

        public static void Aktivacija_dugmeta_potvrdi(Button potvrdi, params bool[] uslovi)
        {
            bool aktivacija = true;
            foreach(bool uslov in uslovi)
            {
                aktivacija &= uslov;
            }

            if (aktivacija) potvrdi.IsEnabled = true;
            else potvrdi.IsEnabled = false;
        }
    }
}