using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Shapes;

namespace projetGVoiture
{
    /// <summary>
    /// Logique d'interaction pour Voiture.xaml
    /// </summary>
    public partial class Voiture : Window
    {
        private ObservableCollection<Class1> voitures;


        string filter = "";
        public Voiture()
        {
            InitializeComponent();

            voitures = Class1._getClass1(filter);
            dtgridachat.ItemsSource = voitures;
        }
        

        //Navigation gauche
        private void navvoiture_Click(object sender, RoutedEventArgs e)
        {
            Voiture voiture = new Voiture();
            voiture.Show();
            this.Close();
        }

        private void navfacture_Click(object sender, RoutedEventArgs e)
        {
            Facture facture = new Facture();
            facture.Show();
            this.Close();
        }

        private void navachat_Click(object sender, RoutedEventArgs e)
        {
            Achat achat = new Achat();
            achat.Show();
            this.Close();
        }

        private void navarchive_Click_1(object sender, RoutedEventArgs e)
        {
            Archives archives = new Archives();
            archives.Show();
            this.Close();
        }

        //logout bas droite
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //RECHERCHE DE VOITURE 
        private void recherchevoiture_Click_1(object sender, RoutedEventArgs e)
        {
            string filter = RECHERCHE.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                dtgridachat.ItemsSource = voitures;
            }
            else
            {
                var filteredVoitures = voitures.Where(v => v.idvoit.ToString().Contains(filter) || v.design.Contains(filter)).ToList();
                dtgridachat.ItemsSource = filteredVoitures;
            }
        }
        bool edit = false;
       int idvoit =0;
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedVoiture = (Class1)button.DataContext;
            idvoit = selectedVoiture.idvoit;
           var design = selectedVoiture.design;
            var prix = selectedVoiture.prix;
            var stock = selectedVoiture.nbrstock;
             textdesign.Text = design.ToString();
            textboxprix.Text = prix.ToString();
            textboxnombre.Text = stock.ToString();
            edit = true;
        }

        private void enregistrer_Click(object sender, RoutedEventArgs e)
        {
            var nbrstock = this.textboxnombre.Text.Trim();
            var prix = this.textboxprix.Text.Trim();
            var design = this.textdesign.Text.Trim();
            if (nbrstock =="" || prix== "" || design == "")
            {
                MessageBox.Show("Enregistrement n'a pas abouti, a cause d'une ou plusieurs champ vide");
                Voiture voitures = new Voiture();
                voitures.Show();
                this.Close();
            }
            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            if (edit)
            {
               using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    var cmd = new MySqlCommand($"UPDATE voiture SET design='{design}',prix='{prix}',nbrstock='{nbrstock}' WHERE idvoit={idvoit}", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modifier avec success");

                }
                edit = false;
                
            }
            else 
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    var cmd = new MySqlCommand($"INSERT INTO voiture (idvoit,design,prix,nbrstock) VALUES (NULL,'{design}','{prix}','{nbrstock}')", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Enregistrer avec success");
                }
            }
            Voiture voiture = new Voiture();
            voiture.Show();
            this.Close();
        }

        private void boute2_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedVoiture = (Class1)button.DataContext;
            idvoit = selectedVoiture.idvoit;
            var design = selectedVoiture.design;

            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand($"DELETE FROM voiture WHERE idvoit={idvoit}", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show($" Suppression de {design} des voitures , success");

        }
    }
}
