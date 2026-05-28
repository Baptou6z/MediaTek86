using System;
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
        /// Récupère tous les services
        /// </summary>
        /// <returns>Une liste d'objets Service</returns>
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
                    Service s = new Service((int)reader["idservice"], reader["libelle"].ToString());
                    lesServices.Add(s);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            bdd.CloseConnection();
            return lesServices;
        }
    }
}
