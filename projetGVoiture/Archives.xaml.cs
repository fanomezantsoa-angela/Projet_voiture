using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace projetGVoiture
{
    /// <summary>
    /// Logique d'interaction pour Archives.xaml
    /// </summary>
    public partial class Archives : Window
    {
        private ObservableCollection<Class1> voitures;


        string filter2 = "";
        private ObservableCollection<Class2> achats;


        string filter = "";
        public Archives()
        {
            InitializeComponent();
            achats = Class2._getClass2(filter2);
            dtgridachat2.ItemsSource = achats;
            voitures = Class1._getClass1(filter);
            dtgridachat.ItemsSource = voitures;
        }
       
        string? nomclient = "";
        int idupdate = 0;
        
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedAchat = (Class2)button.DataContext;
             idupdate = selectedAchat.numachat;
             nomclient = selectedAchat.nomclient;
            listeachats.Visibility = Visibility.Hidden;
            tedroi.Visibility = Visibility.Hidden;
          
            ajoutachat.Visibility = Visibility.Hidden;
            droite.Visibility = Visibility.Visible;
            droite1.Visibility= Visibility.Visible;
            droite2.Visibility= Visibility.Visible;
            editachat.Visibility = Visibility.Visible;
            savemodifs.Visibility = Visibility.Visible;
            datepicker1.Visibility= Visibility.Hidden;
            datepicker2.Visibility= Visibility.Hidden;
            datepicker3.Visibility= Visibility.Hidden;
            datepicker4.Visibility= Visibility.Hidden;
            datapicker5.Visibility= Visibility.Hidden;
            
            MessageBox.Show($"Numero achats à modifier:{idupdate},{nomclient}");
        }
        //MODIFICATIONS ACHATS
        //COMBOBOX MODIFICATIONS
        private void Clients_Initialized(object sender, EventArgs e)
                    {
                        Clients.SelectedValue = nomclient;
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
                        //Action du boutton dans le datagrid de modification
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
                            int nombreduvoiture = selectedVoiture.nombre;
                            string design2 = design + $"({nombreduvoiture})";

                            int total = prix * nombreduvoiture;
                            nbrstock -= nombreduvoiture;
                            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";

                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                string manalaisa = $"UPDATE voiture SET nbrstock={nbrstock} WHERE idvoit={voitureId}";

                string query = $"UPDATE listecar SET design = @design2, prixunitaire = @prix, nombre = @nombreduvoiture, prixtotal = @total WHERE numachat = {idupdate}";

                //string query = "INSERT INTO listecar (numachat,design,prixunitaire,nombre,prixtotal,idvoiture)VALUES(@numachat,@design,@prix,@nombreduvoiture,@total,@voitureId)";
                MySqlCommand dmc= new MySqlCommand(manalaisa, connection);

                MySqlCommand cmd = new MySqlCommand(query, connection);
                                        cmd.Parameters.AddWithValue("@voitureId", voitureId);
                                        cmd.Parameters.AddWithValue("@design2", design2);
                                        cmd.Parameters.AddWithValue("@nombreduvoiture", nombreduvoiture);
                                        cmd.Parameters.AddWithValue("@prix", prix);
                                        //cmd.Parameters.AddWithValue("@numachat", numachat);
                                        cmd.Parameters.AddWithValue("@total", total); 
                                connection.Open();
                                cmd.ExecuteReader();
                                dmc.ExecuteReader();

            }

                            selectedVoiture.nombre = 1;
                            MessageBox.Show("Modification Reussi");
                        }
        //filtre dans achats
        private void recherchevoiture_Click_1(object sender, RoutedEventArgs e)
        {
            string filter = RECHERCHE.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                dtgridachat2.ItemsSource = achats;
            }
            else
            {
                var filteredAchats = achats.Where(v => v.numachat.ToString().Contains(filter) || v.nomclient.Contains(filter)).ToList();
                dtgridachat2.ItemsSource = filteredAchats;
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
        private void navarchive_Click(object sender, RoutedEventArgs e)
        {
            Archives archives = new Archives();
            archives.Show();
            this.Close();
        }
        // log out bas droite
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //suppression d'achats 
        private void bout2_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedAchat = (Class2)button.DataContext;
            int iddelete = selectedAchat.id;
            MessageBox.Show($"Supprimer l'achats : {iddelete}?");

            string connnectionstring = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";

            MySqlConnection connection = new MySqlConnection(connnectionstring);

            MySqlCommand cmd = new MySqlCommand($"DELETE FROM achat WHERE Id = {iddelete}", connection);
           

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Supprimer avec success");
            // reouvrire la fenetre archives
            Archives archives = new Archives();
            archives.Show();
            this.Close();
        }
        //modifications achats

        private void savemodifs_Click(object sender, RoutedEventArgs e)
        {
            var numachat = this.NUMEROACHAT.Text;
            var cli = Clients.SelectedItem as string;
            string connectionString = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            var query =$"UPDATE achat SET nomclient = '{cli}', listevoiture = (SELECT GROUP_CONCAT(design SEPARATOR '-') FROM listecar WHERE numachat = '{numachat}'), sommetotal = (SELECT SUM(prixtotal) FROM listecar WHERE numachat = '{numachat}')WHERE numachat = '{numachat}'";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand(query, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Modification enregistrer");
            Achat achat = new Achat();
            achat.Show();
            this.Close();
        }
        //nombre de voiture a acheter augmentant a chaque clic par voiture
        private void bout_Click(object sender, RoutedEventArgs e)
        {

            var button = (Button)sender;
            var selectedVoiture = (Class1)button.DataContext;
            int nombreduvoiture = selectedVoiture.nombre;
            nombreduvoiture++;
            selectedVoiture.nombre = nombreduvoiture;
            button.Content = nombreduvoiture;
        }
        //filtre entre deux date 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime date1 = datepicker1.SelectedDate ?? DateTime.MinValue;
            DateTime date2 = datepicker2.SelectedDate ?? DateTime.MaxValue;
            if (datepicker1.Text == "" || datepicker2.Text == "")
            {
                dtgridachat2.ItemsSource = achats;
            }
            else
            {
                string filter = $" WHERE dateachat BETWEEN '{date1.ToString("yyyy-MM-dd")}' AND '{date2.ToString("yyyy-MM-dd")}'";

                //string filter = $"dateachat BETWEEN {date1.ToString("yyyy-MM-dd")} AND {date2.ToString("yyyy-MM-dd")}";
                //string filter = "";
                ObservableCollection<Class2> AchatsFiltrees = Class2._getClass2(filter);
                dtgridachat2.ItemsSource = AchatsFiltrees;
            }

        }

    }
}
