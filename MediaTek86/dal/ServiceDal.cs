using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MediaTek86.modele;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour les objets Service.
    /// </summary>
    public class ServiceDal
    {
        /// <summary>
        /// Récupère tous les services de la base de données.
        /// </summary>
        public static List<Service> GetLesServices()
        {
            List<Service> lesServices = new List<Service>();
            BddManager bdd = BddManager.GetInstance();
            string req = "SELECT * FROM service";

            try
            {
                bdd.OpenConnection();
                MySqlDataReader reader = bdd.ReqSelect(req, null);
                while (reader.Read())
                {
                    // On crée l'objet Service avec l'ID et le Nom de la BDD
                    Service s = new Service((int)reader["idservice"], reader["nom"].ToString());
                    lesServices.Add(s);
                }
                reader.Close();
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erreur SQL (Service) : " + e.Message);
            }
            finally
            {
                bdd.CloseConnection();
            }

            return lesServices;
        }
    }
}
