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
    /// Interaktionslogik für SiteSchülerAuswahl1.xaml
    /// </summary>
    public partial class SiteSchülerAuswahl1 : Page
    {
        private Model.Schueler Schueler;
        public MainWindow mainwindow = Application.Current.MainWindow as MainWindow;
        // Hier fügen wir ein Label hinzu um nachher in das objekt das objekt Label_Help zu importieren
        public Label Label_Help = new Label();
        public SiteSchülerAuswahl1(Label help, Model.Schueler schueler)
        {
            Schueler = schueler;
            InitializeComponent();
            Label_Help = help;
        }

        private void DataGrid_DataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "Hier werden\nalle aktuellen\nFehlzeiten\nAngezeigt";
        }

        private void DataGrid_DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "";
        }

        private void DataGridTextColumn_MouseMove(object sender, MouseEventArgs e)
        {

        }

        
    }
}
