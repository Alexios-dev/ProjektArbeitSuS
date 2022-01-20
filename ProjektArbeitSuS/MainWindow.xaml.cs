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
        public int Key;
        public Windows.Login.SiteLogin Login = new Windows.Login.SiteLogin();
        
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = Login.Content;
        }
        public bool LoginExit(int key)
        {
            //Hier kommt die spätere Login Lösung rein
            if(Convert.ToString(key).Length == 10)
            {
                Key = key;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}    
