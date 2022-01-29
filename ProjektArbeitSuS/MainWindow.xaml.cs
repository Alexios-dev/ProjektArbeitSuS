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


namespace ProjektArbeitSuS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // scaffold-dbcontext "Data Source=localhost;Initial Catalog=SuS;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Klassen" -ContextDir "DbConnection"
        public Model.Schueler schueler;
        public Model.Lehrer lehrer;
        public Windows.Login.SiteLogin Window_Login = new Windows.Login.SiteLogin();
        public Windows.Controller.SiteConnector Window_Connector = new Windows.Controller.SiteConnector();
        Model.SUSContext DBConnection = new Model.SUSContext();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = Window_Login.Content;
        }
        public bool LoginExit(long key)
        {
            
            //Hier kommt die spätere Login Lösung rein
            if (Convert.ToString(key).Length == 10)
            {
                
                foreach (var item in DBConnection.Schuelers)
                {
                    if(key == item.Matrikelnummer)
                    {
                        schueler = item;
                        Label_Matrikelnummer.Content = Convert.ToString(schueler.Vorname);
                        Window_Connector.schueler = schueler;
                        MainFrame.Content = Window_Connector;

                        return true;
                    }
                }
                foreach (var item in DBConnection.Lehrers)
                {
                    if (key == item.Matrikelnummer)
                    {
                        lehrer = item;
                        Label_Matrikelnummer.Content = Convert.ToString(lehrer.Nachname);
                        Window_Connector.lehrer = lehrer;
                        MainFrame.Content = Window_Connector;
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }
}    
