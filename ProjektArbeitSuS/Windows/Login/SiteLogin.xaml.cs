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

namespace ProjektArbeitSuS.Windows.Login
{
    /// <summary>
    /// Interaktionslogik für SiteLogin.xaml
    /// </summary>
    public partial class SiteLogin : Page
    {
        // Hier ist unser Fenster zum Einloggen 
        // Key ist die Martikelnummer
        public int Key;
        public SiteLogin()
        {
            
            InitializeComponent();
        }

        // MouseMove und Leave bewirken das anzeigen der info textbox wenn man über die TextBox Hoverd
        //------------------------------------------------------------------------------------------
        private void TextBox_Key_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Key.Content = "Martikelnummer";
        }


        private void TextBox_Key_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Key.Content = "";
        }
        //------------------------------------------------------------------------------------------
        // Hier geht es um den eigentlichen Login vorgang
        //------------------------------------------------------------------------------------------
        private void TextBox_Key_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox_Key.Text.Length != 0)
            {
                // zum prüfen ob die eingegebene Nummer auch wirklich eine nummer ist und keine zahlen enthält und zur begrenzung auf Maximal
                // 10 Zahlen die in die TextBox eingegeben werden können
                //------------
                try
                {
                    int a = Convert.ToInt32(TextBox_Key.Text);
                    //zum zurücksetzten des Label_Error.Content das kein wert angezeigt wird weil kein fehler auftritt 
                    Label_Error.Content = string.Empty; ;
                }
                catch
                {
                    if (TextBox_Key.Text.Length > 10)
                    {
                        TextBox_Key.Text = TextBox_Key.Text.Substring(0, 9);
                        Label_Error.Content = "Max 10 zahlen";
                    }
                    else
                    {
                        Label_Error.Content = "Nur Zahlen";
                    }
                    return;
                }
                //------------
                //hier wird der eigentliche Key überprüft
                //------------
                if (TextBox_Key.Text.Length == 10)
                {
                    // Neues Object wird mit dem bestehendem Mainwindow verbunden 
                    MainWindow mainwindow = Application.Current.MainWindow as MainWindow;
                    // Hier rückgabewert der überprüfung des Keys bei bool wird der neue Key hier gespeichert für zukünftige extensions
                    bool abfrage = mainwindow.LoginExit(Convert.ToInt32(TextBox_Key.Text));
                    if (abfrage)
                    {
                        Key = Convert.ToInt32(TextBox_Key.Text);

                    }
                    else
                    {
                        // Wenn der Key falsch ist wird das Hier im Label_Error ´übertragen
                        Label_Error.Content = "Falsche Martikelnummer";
                    }                    
                }
                //------------
            }
            else
            {
                //zum zurücksetzten des Label_Error.Content das kein wert angezeigt wird wenn nichts in der TextBox steht
                Label_Error.Content = string.Empty;
            }
        }
        //------------------------------------------------------------------------------------------
    }
}
