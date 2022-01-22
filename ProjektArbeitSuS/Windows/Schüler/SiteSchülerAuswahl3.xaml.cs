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

namespace ProjektArbeitSuS.Windows.Schüler
{
    /// <summary>
    /// Interaktionslogik für SiteSchülerAuswahl3.xaml
    /// </summary>
    public partial class SiteSchülerAuswahl3 : Page
    {
        public MainWindow mainwindow = Application.Current.MainWindow as MainWindow;
        DbConnection.SuSContext DBConnection = new DbConnection.SuSContext();
        // Hier fügen wir ein Label hinzu um nachher in das objekt das objekt Label_Help zu importieren
        public Label Label_Help = new Label();

        public bool Refresh()
        {
            
            try
            {
                DataGrid_DataGrid.Items.Clear();
                foreach(var a in DBConnection.Faches)
                {
                    DataGrid_DataGrid.Items.Add(a);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public SiteSchülerAuswahl3(Label help)
        {
            Label_Help = help;
            InitializeComponent();
        }

        private void DataGrid_DataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "Hier werden\nalle aufenthalts\nOrte angezeigt\nmit Uhrzeit\nund Lehrer ";
        }

        private void DataGrid_DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "";
        }
    }
}
