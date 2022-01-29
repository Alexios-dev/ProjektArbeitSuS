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
        public void Refresh()
        {
            datenFachLehrerverwaltung.Init(Lehrer);
            DataGrid_DataGrid.Items.Clear();
            foreach (var item in datenFachLehrerverwaltung.FehlzeitenFachLehrerList)
            {
                DataGrid_DataGrid.Items.Add(item);
            }
            DataGrid_DataGrid.Items.Refresh();
        }
        public SiteFachLehrerAuswahl1(Label help, Model.Lehrer lehrer)
        {
            Lehrer = lehrer;
            Label_Help = help;
            InitializeComponent();
            Refresh();
        }

        private void DataGrid_DataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Help.Content = "Hier werden\nalle Fehlstunden\nangezeigt\nmit Uhrzeit\nund Fach ";
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
            if(ComboBox_Sort.SelectedItem == ComboBox_Item_Reset)
            {
                ComboBox_Sort.SelectedItem = null;
                TextBox_Sort.Text = "";
                TextBox_Sort.Visibility = Visibility.Hidden;
            }
            else if (ComboBox_Sort.SelectedItem == null)
            {
                TextBox_Sort.Visibility = Visibility.Hidden;
                Refresh();
            }
            else
            {
                TextBox_Sort.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_Sort_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBox_Sort.SelectedItem == ComboBox_Item_Fach)
            {

            }
            else if (ComboBox_Sort.SelectedItem == ComboBox_Item_Klasse)
            {

            }
            else if(ComboBox_Sort.SelectedItem == ComboBox_Item_Schueler)
            {

            }
            else if(ComboBox_Sort.SelectedItem == ComboBox_Item_Datum)
            {

            }
        }
    }
}
