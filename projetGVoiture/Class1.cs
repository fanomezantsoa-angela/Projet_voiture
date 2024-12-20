using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetGVoiture
{
    internal class Class1
    {
        public int idvoit { get; set; }
        public  string? design { get; set; }
        public int prix { get; set; }
        public int nbrstock { get; set; }
        public int nombre { get; set; }
        //public required ObservableCollection<Class1> donneess { get;  set; }

        public static ObservableCollection<Class1> _getClass1(string filter)
        {
            string connnectionstring = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            string selectQuery = "SELECT * FROM voiture" + filter;
            using (MySqlConnection conn = new MySqlConnection(connnectionstring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var class1 = new ObservableCollection<Class1>();

                        while (reader.Read())
                        {

                            class1.Add(new Class1()
                            {
                                idvoit = Convert.ToInt32(reader["idvoit"]),
                                design = reader["design"].ToString(),
                                prix = Convert.ToInt32(reader["prix"]),
                                nbrstock = Convert.ToInt32(reader["nbrstock"]),
                                nombre =1

                            });
                        }
                        return class1;

                    }
                }

            }
        }


    }
}
