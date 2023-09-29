using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ListGeneriqueRevision
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gestion gestion=new Gestion();
        public MainWindow()
        {
            InitializeComponent();
            dtListe.ItemsSource = gestion.Articles;
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            double taux = 0.0;
            if (rb7.IsChecked==false && rb20.IsChecked==false)
            {
                MessageBox.Show("Entrer un Taux!");
            }
            if (rb7.IsChecked == true)
            {
                taux = 0.07;
            }
            else
            {
                taux = 0.2;
            }
            if (txtDesignation.Text!=string.Empty && txtPrix.Text!=string.Empty && txtQuantite.Text!=string.Empty)
            {               
                gestion.AjouterArticle(txtDesignation.Text,ConvertPoint(txtPrix.Text),int.Parse(txtQuantite.Text),taux);
                txtHT.Text = gestion.GetHT().ToString();
                txtTVA.Text=gestion.GetTva().ToString();
                txtNet.Text=gestion.GetTtc().ToString();
            }
            else
            {
                MessageBox.Show("Tous les champs son requis");
            }

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtDesignation.Text=string.Empty;
            txtPrix.Text=string.Empty;
            txtQuantite.Text=string.Empty;
            txtHT.Text= string.Empty;
            txtTVA.Text= string.Empty;
            txtNet.Text= string.Empty;
            gestion.Articles.Clear();
            if (rb7.IsChecked == true)
            {
                rb7.IsChecked = false;
            }
            else
            {
                rb20.IsChecked = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dtListe.SelectedIndex != -1)
            {
                gestion.Articles.RemoveAt(dtListe.SelectedIndex);
                txtHT.Text = gestion.GetHT().ToString();
                txtTVA.Text = gestion.GetTva().ToString();
                txtNet.Text = gestion.GetTtc().ToString();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner l'article à supprimer.");
            }
        }

        //Gestion de la de conversion des points décimaux
        double ConvertPoint(string sNumber)
        {
            string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            sNumber = sNumber.Replace(",", separator).Replace(".", separator);

            return double.Parse(sNumber);
        }

        private void txtPrix_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                //Détermine si la séquence de touches est un nombre du clavier.
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if ((e.Key != Key.Back) && (e.Key != Key.Tab) && (e.Key != Key.OemComma) && (e.Key != Key.Decimal))
                    {
                        e.Handled = true;
                        MessageBox.Show("J'accepte uniquement les chiffres, désolé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
