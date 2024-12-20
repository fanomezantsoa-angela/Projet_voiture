using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetGVoiture
{
    internal class Class3
    {
        public int idcli { get; set; }
        public string? nom { get; set; }
        public string? contact { get; set; }
        public static ObservableCollection<Class3> _getClass3(string filter)
        {
            string connnectionstring = "SERVER=localhost;DATABASE=gestionventevoiture;UID=root;PASSWORD=";
            string selectQuery = "SELECT * FROM client" + filter;
            using (MySqlConnection conn = new MySqlConnection(connnectionstring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        var class3 = new ObservableCollection<Class3>();
                        while (reader.Read())
                        {
                            class3.Add(new Class3()
                            {
                                idcli = Convert.ToInt32(reader["idcli"]),
                                nom = reader["nom"].ToString(),
                                contact = reader["contact"].ToString()
                            });
                        }
                        return class3;

                    }
                }

            }
        }
    }
}
