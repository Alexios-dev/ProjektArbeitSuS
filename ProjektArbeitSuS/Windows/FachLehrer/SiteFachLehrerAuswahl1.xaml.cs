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

namespace ProjektArbeitSuS.Windows.FachLehrer
{
    /// <summary>
    /// Interaktionslogik für SiteFachLehrerAuswahl1.xaml
    /// </summary>
    public partial class SiteFachLehrerAuswahl1 : Page
    {
        public Model.Lehrer Lehrer;
        public Label Label_Help = new Label();
        public MainWindow mainwindow = Application.Current.MainWindow as MainWindow;
        private Model.Verwaltung.datenFachLehrerverwaltung datenFachLehrerverwaltung = new Model.Verwaltung.datenFachLehrerverwaltung();
        public SiteFachLehrerAuswahl1(Label help, Model.Lehrer lehrer)
        {
            Lehrer = lehrer;
            Label_Help = help;
            InitializeComponent();
        }
    }
}
