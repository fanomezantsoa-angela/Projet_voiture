using MySql.Data.MySqlClient;
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

namespace projetGVoiture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string db = "server=localhost;database=vente_voiture;username=root;password=;";
                MySqlConnection conn = new(db);
                conn.Open();
                if (user.Text != string.Empty || pass.Password != string.Empty)
                {
                    string usern = user.Text;
                    string passn = pass.Password;

                    string cmd = "select * from login ";
                    MySqlCommand req = new(cmd, conn);
                    MySqlDataReader dr = req.ExecuteReader();
                    while (dr.Read())
                    {
                        string user1 = dr.GetString(0);
                        string pass1 = dr.GetString(1);
                        if (user1 == usern || pass1 == passn)
                        {
                            Voiture voiture = new Voiture();
                            voiture.Show();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Vous avez saisir le mauvais mot de passe ou username");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Veuillez remplir tout les champs");
                }
            }




            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
