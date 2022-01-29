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

namespace ProjektArbeitSuS.Windows.Controller
{
    /// <summary>
    /// Interaktionslogik für SiteConnector.xaml
    /// </summary>
    public partial class SiteConnector : Page
    {
        public Model.Schueler schueler;
        public Model.Lehrer lehrer;
        public bool Help;
        
        public SiteConnector()
        {
            
            InitializeComponent();
        }
        
        /*
         * Bei den Nummern bei:
         * Convert.ToString(Key).Substring(0,1) == "3"
         * würd überprüft ob sich hinter dieser Url ein Lehrer verbirgt oder ein Schüler dementsprechend
         * werden dann auch Buttons und Labels verknüpft
         * 
         * Bei if(Help):
         * Wenn Help Aktieviert werden hier in einem gesonderten bereich informationen über diesen button angezeigt
         * Deutlicher mehr aufwand besser benutzer freundlichkeit AssFuck
         * ----------------------------------------------------------------------------------------------------
        */
        private void Button_Auswahl1_MouseMove(object sender, MouseEventArgs e)
        {
            //Standard aufbau der nächsten Methoden

            if (schueler != null)
            {
                Label_Auswahl1.Content = "Fehlstunden Liste";
                if (Help)
                {
                    Label_Help.Content = "Hier werden alle \nFehlstunden \ngebündelt \nin einer Liste\n angezeigt.";
                }
            }
            else if(lehrer != null)
            {
                Label_Auswahl1.Content = "Fach Fehlstunden";
                if (Help)
                {
                    Label_Help.Content = "Hier werden\ndie Fehlstunden\nin den Fächern\nangezeigt\n";
                }
            }
        }
        //----------------------------------------------------------------------------------------------------
        //Hier werden die daten wenn der Mauszeiger den button verlässt wieder gelöscht
        //----------------------------------------------------------------------------------------------------
        private void Button_Auswahl1_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Auswahl1.Content = "";
            Label_Help.Content = "";
        }
        //----------------------------------------------------------------------------------------------------
        private void Button_Auswahl1_Click(object sender, RoutedEventArgs e)
        {
            if (schueler != null)
            {
                MainFrame.Content = new Windows.Schüler.SiteSchülerAuswahl1(Label_Help, schueler);
            }
            if (lehrer != null)
            {
                MainFrame.Content = new Windows.FachLehrer.SiteFachLehrerAuswahl1(Label_Help, lehrer);
            }
        }
        private void Button_Auswahl2_MouseMove(object sender, MouseEventArgs e)
        {
            if (schueler != null)
            {
                Label_Auswahl2.Content = "Diagram Ansicht";
                if (Help)
                {
                    Label_Help.Content = "Hier wird eine \ndetailierte \nAnsicht der \nFehlstunden \nAngezeigt";
                }
            }
        }
        private void Button_Auswahl2_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Auswahl2.Content = "";
            Label_Help.Content = "";
        }
        private void Button_Auswahl2_Click(object sender, RoutedEventArgs e)
        {
            if (schueler != null)
            {
                MainFrame.Content = new Windows.Schüler.SiteSchülerAuswahl2(Label_Help,schueler);
            }
        }
        private void Button_Auswahl3_MouseMove(object sender, MouseEventArgs e)
        {
            if (schueler != null)
            {
                Label_Auswahl3.Content = "Anwesenheits Liste";
                if (Help)
                {
                    Label_Help.Content = "Hier werden \nalle Logins bei \nden RFIDLesern \nangezeigt zur\nüberprüfung";
                }
            }
        }
        private void Button_Auswahl3_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Auswahl3.Content = "";
            Label_Help.Content = "";
        }
        private void Button_Auswahl3_Click(object sender, RoutedEventArgs e)
        {
            if (schueler != null)
            {
                MainFrame.Content = new Windows.Schüler.SiteSchülerAuswahl3(Label_Help, schueler);
            }
        }
        //Hier wird Help Aktieviert / Deaktieviert und beim drücken auf den button help resetet sollte es aus irgendwelchen
        //gründen mal hängen
        //----------------------------------------------------------------------------------------------------
        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            if (!Help)
            {
                Help = true;
                Label_Help.Content = null;
                Label_Help.Visibility = Visibility.Visible;
                Button_Help.Content = "Help OFF";
            }
            else
            {
                Help = false;
                Label_Help.Content = null;
                Label_Help.Visibility=Visibility.Hidden;
                Button_Help.Content = "Help ON";
            }
        }
        //----------------------------------------------------------------------------------------------------


    }
}
