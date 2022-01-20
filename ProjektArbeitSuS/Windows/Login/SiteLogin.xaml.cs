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
        public int Key;
        public SiteLogin()
        {
            
            InitializeComponent();
        }

        private void TextBox_Key_MouseMove(object sender, MouseEventArgs e)
        {
            Label_Key.Content = "Martikelnummer";
        }


        private void TextBox_Key_MouseLeave(object sender, MouseEventArgs e)
        {
            Label_Key.Content = "";
        }

        private void TextBox_Key_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox_Key.Text.Length != 0)
            {
                try
                {
                    int a = Convert.ToInt32(TextBox_Key.Text);
                    Label_Error.Content = string.Empty; ;
                }
                catch
                {
                    if (TextBox_Key.Text.Length > 10)
                    {
                        TextBox_Key.Text = TextBox_Key.Text.Substring(0, 10);
                        Label_Error.Content = "Max 10 zahlen";
                    }
                    else
                    {
                        Label_Error.Content = "Nur Zahlen";
                    }
                    return;
                }
                if (TextBox_Key.Text.Length == 10)
                {
                    MainWindow mainwindow = Application.Current.MainWindow as MainWindow;
                    bool abfrage = mainwindow.LoginExit(Key);
                    if (abfrage)
                    {
                        this.Visibility = Visibility.Hidden;

                    }
                    else
                    {
                        Label_Error.Content = "Falsche Martikelnummer";
                    }                    
                }
                
            }
            else
            {
                Label_Error.Content = string.Empty;
            }
        }
    }
}
