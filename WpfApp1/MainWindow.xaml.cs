using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string cesta;
        public MainWindow()
        {
            InitializeComponent();
        }

            private void nacti_btn(object sender, RoutedEventArgs e)
            {
                OpenFileDialog OFD = new OpenFileDialog
                {
                    Title = "Otevřít soubor",
                    Filter = "txt files (*.txt)|*.txt"
                };
                if (OFD.ShowDialog() == true)
                {
                    cesta = OFD.FileName;
                    uloz.IsEnabled = true;
                    Precti();
                }
            }
            
        private void Zapis(string obsah)
            {

                using (StreamWriter sw = new StreamWriter(cesta, true))
                {
                    sw.WriteLine(obsah + "\n" + DateTime.Now) ;
                }
            }

           
        private void Precti()
            {
                string obsah = "";
                using (StreamReader sr = new StreamReader(cesta))
                {
                    string radek;
                    while ((radek = sr.ReadLine()) != null)
                    {
                        obsah += radek + "\n";
                    }
                }
                TB.Text = obsah;
            }

            private void uloz_btn(object sender, RoutedEventArgs e)
            {
                Zapis(input.Text);
                input.Text = ""  ;
                Precti();
            }

            

        }
    }

