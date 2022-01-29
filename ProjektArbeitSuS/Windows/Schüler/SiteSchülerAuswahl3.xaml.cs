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
        
        public Model.Schueler Schueler;
        public MainWindow mainwindow = Application.Current.MainWindow as MainWindow;
        private Model.Verwaltung.datenSchuelersverwaltung DatenSchuelersverwaltung = new Model.Verwaltung.datenSchuelersverwaltung();
        // Hier fügen wir ein Label hinzu um nachher in das objekt das objekt Label_Help zu importieren
        public Label Label_Help = new Label();

        public void Refresh()
        {

            
            DataGrid_DataGrid.Items.Clear();
            foreach (var item in DatenSchuelersverwaltung.ListdatenSchuelers)
            {
                DataGrid_DataGrid.Items.Add(item);
            }
            DataGrid_DataGrid.Items.Refresh();

        }
        
        public SiteSchülerAuswahl3(Label help, Model.Schueler schueler)
        {
            
            Schueler = schueler;
            Label_Help = help;
            InitializeComponent();
            DatenSchuelersverwaltung.Init(Schueler);
            Refresh();
        }

        private void DataGrid_DataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "Hier werden\nalle aufenthalts\nOrte angezeigt\nmit Uhrzeit\nund Lehrer ";
        }

        private void DataGrid_DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "";
        }

        private void ComboBox_Sort_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "Hier wird\ndas Attribut\nangegeben \nnachdem\nSortiert werden\nsoll";
        }

        private void ComboBox_Sort_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "";
        }

        private void TextBox_Sort_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "Hier wird\ndas Schlagwort\nangegeben wonach\ngesucht werden\nsoll";
        }

        private void TextBox_Sort_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "";
        }

        private void ComboBox_Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (ComboBox_Sort.SelectedItem == ComboBox_Item_Reset)
            {
                
                ComboBox_Sort.SelectedItem = null;
                TextBox_Sort.Text = "";
                TextBox_Sort.Visibility = Visibility.Hidden;

            }
            else if(ComboBox_Sort.SelectedItem == null)
            {
                
                TextBox_Sort.Visibility = Visibility.Hidden;
            }
            else
            {
                
                TextBox_Sort.Visibility = Visibility.Visible;
            }
            
        }

        private void TextBox_Sort_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TextBox_Sort.Text == "")
            {
                DatenSchuelersverwaltung.Init(Schueler);
                Refresh();
            }
            else if(ComboBox_Sort.SelectedItem == ComboBox_Item_Raum)
            {
                DatenSchuelersverwaltung.Init(Schueler);
                DatenSchuelersverwaltung.RaumList(TextBox_Sort.Text);
                Refresh();
            }
            else if (ComboBox_Sort.SelectedItem == ComboBox_Item_DatumVon)
            {
                DatenSchuelersverwaltung.Init(Schueler);
                DatenSchuelersverwaltung.DatumVonList(TextBox_Sort.Text);
                Refresh();
            }

        }
    }
}
