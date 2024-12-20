using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetGVoiture
{
    internal class Class2
    {
        public int id { get; set; }
        public  int numachat { get; set; }
        public  string? nomclient { get; set; }
        public  string? listevoiture { get; set; }
        public int sommetotal { get; set; }
        public DateTime dateachat { get; set; }
        //public required ObservableCollection<Class1> donneess { get;  set; }

        public static ObservableCollection<Class2> _getClass2(string filter)
        {
            string connnectionstring = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            string selectQuery = "SELECT * FROM achat" + filter;
            using (MySqlConnection conn = new MySqlConnection(connnectionstring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var class2 = new ObservableCollection<Class2>();

                        while (reader.Read())
                        {

                            class2.Add(new Class2()
                            {
                                id = Convert.ToInt32(reader["id"]),
                                numachat = Convert.ToInt32(reader["numachat"]),
                                nomclient = reader["nomclient"].ToString(),
                                listevoiture = reader["listevoiture"].ToString(),
                                sommetotal = (int)Convert.ToInt64(reader["sommetotal"]),
                                dateachat = (DateTime)Convert.ToDateTime(reader["dateachat"])

                            });
                        }
                        return class2;

                    }
                }

            }
        }
    }
}
