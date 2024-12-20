using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Facture.xaml
    /// </summary>
    public partial class Facture : Window
    {
        private ObservableCollection<Class3> clients;


        string filter = "";
        public Facture()
        {
            InitializeComponent();
            clients = Class3._getClass3(filter);
            dtgridachat.ItemsSource = clients;
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
        //RECHERCHE DE CLIENT
        private void recherchevoiture_Click_1(object sender, RoutedEventArgs e)
        {
            string filter = RECHERCHE.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                dtgridachat.ItemsSource = clients;
            }
            else
            {
                var filteredClients = clients.Where(v => v.idcli.ToString().Contains(filter) || v.contact.Contains(filter)).ToList();
                dtgridachat.ItemsSource = filteredClients;
            }
        }
        bool edit = false;
        int idcli = 0;
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedVoiture = (Class3)button.DataContext;
            idcli = selectedVoiture.idcli;
            var nom = selectedVoiture.nom;
            var contact = selectedVoiture.contact;
            textdesign.Text = nom.ToString();
            textboxprix.Text = contact.ToString();
            edit = true;
        }
        private void enregistrer_Click(object sender, RoutedEventArgs e)
        {
            
            var contact = this.textboxprix.Text.Trim();
            var nom = this.textdesign.Text.Trim();
            
            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            if (edit)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    if (contact == "" || nom == "")
                    {
                        MessageBox.Show("Enregistrement n'a pas abouti, a cause d'une ou plusieurs champ vide");
                        Facture factures = new Facture();
                        factures.Show();
                        this.Close();
                    }
                    else {
                        var cmd = new MySqlCommand($"UPDATE client SET nom='{nom}',contact='{contact}' WHERE idcli={idcli}", connection);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Modifier avec success");
                    }
                }
                edit = false;

            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    var cmd = new MySqlCommand($"INSERT INTO client (idcli,nom,contact) VALUES (NULL,'{nom}','{contact}')", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Enregistrer avec success");
                }
            }
            Facture facture = new Facture();
            facture.Show();
            this.Close();
        }
        private void boute2_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedClient = (Class3)button.DataContext;
            idcli = selectedClient.idcli;
            var nom = selectedClient.nom;

            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand($"DELETE FROM client WHERE idcli={idcli}", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show($" Suppression de {nom} des clients , success");
            Facture facture1 = new Facture();
            facture1.Show();
            this.Close();
        }
    }
}
