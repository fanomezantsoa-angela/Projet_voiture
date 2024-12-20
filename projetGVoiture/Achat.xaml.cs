using Google.Protobuf.WellKnownTypes;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace projetGVoiture
{
    /// <summary>
    /// Logique d'interaction pour Achat.xaml
    /// </summary>
    public partial class Achat : Window
    {
        //private object dataGrid;

        //public object ViewOrdersGrid { get; private set; }
        // Variable booléenne
        private ObservableCollection<Class1> voitures;

        
        string filter = "";
        public Achat()
        {
            InitializeComponent();

            voitures = Class1._getClass1(filter);
            dtgridachat.ItemsSource = voitures;
            

        }




       

        

        //combobox client
        private void Clients_Initialized(object sender, EventArgs e)
        {
            string db = "server=localhost;database=gestionventevoiture;username=root;password=;";
            MySqlConnection conn = new(db);
            conn.Open();
            string cmd = "SELECT nom FROM client ";
            MySqlCommand req = new(cmd, conn);
            MySqlDataReader dr = req.ExecuteReader();
            while (dr.Read())
            {
                string user1 = dr.GetString(0);

                Clients.Items.Add(user1);
            }
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
        //Log OUT BAS DROITE

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        



        //datagrid boutton 
        private void ecr_Click(object sender, RoutedEventArgs e)
        {
                
                // Obtenez la ligne sélectionnée correspondante
                var button = (Button)sender;
                var selectedVoiture = (Class1)button.DataContext;
                button.Content = "-";
            // Utilisez l'objet "selectedVoiture" pour effectuer des opérations sur la voiture sélectionnée
            var numachat = this.NUMEROACHAT.Text;
                int voitureId = selectedVoiture.idvoit;
                string? design = selectedVoiture.design;
                int prix = selectedVoiture.prix;
                int nbrstock = selectedVoiture.nbrstock;
                int  nombreduvoiture = selectedVoiture.nombre;
                 string design2 = design + $"({nombreduvoiture})";

            int total = prix * nombreduvoiture;
                nbrstock -= nombreduvoiture;
            MessageBox.Show($" Ajouter cette voiture à votre achat?:{this.NUMEROACHAT.Text}");

            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string manalaisa = $"UPDATE voiture SET nbrstock={nbrstock} WHERE idvoit={voitureId}";
                string query = "INSERT INTO listecar (numachat,design,prixunitaire,nombre,prixtotal,idvoiture)VALUES(@numachat,@design2,@prix,@nombreduvoiture,@total,@voitureId)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlCommand dmc= new MySqlCommand(manalaisa, connection);
                cmd.Parameters.AddWithValue("@voitureId", voitureId);
                cmd.Parameters.AddWithValue("@design2", design2);
                cmd.Parameters.AddWithValue("@nombreduvoiture", nombreduvoiture);
                cmd.Parameters.AddWithValue("@prix", prix);
                cmd.Parameters.AddWithValue("@numachat", numachat);
                cmd.Parameters.AddWithValue("@total", total);
                connection.Open();
                cmd.ExecuteNonQuery();
                dmc.ExecuteNonQuery();

            }

            selectedVoiture.nombre = 1;
        }

       
        private void bout_Click(object sender, RoutedEventArgs e)
        {
           
            var button = (Button)sender;
            var selectedVoiture = (Class1)button.DataContext;
            int  nombreduvoiture = selectedVoiture.nombre;
            nombreduvoiture++;
            selectedVoiture.nombre = nombreduvoiture;
            button.Content = nombreduvoiture;
        }

        private void ajoutachat_Click(object sender, RoutedEventArgs e)
        {
            var numachat = this.NUMEROACHAT.Text;
            var cli = Clients.SelectedItem as string;
            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                var cmd2 = new MySqlCommand();
                var cmd = new MySqlCommand($"INSERT INTO achat (numachat,nomclient,listevoiture,sommetotal) SELECT '{numachat}','{cli}',GROUP_CONCAT(design SEPARATOR '-'),SUM(prixtotal) FROM listecar WHERE numachat='{numachat}' GROUP BY  numachat; ",connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            Archives archives = new Archives();
            archives.Show();
            this.Close();
            }

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

        
    }
}
