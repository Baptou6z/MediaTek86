using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MediaTek86.modele;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour les objets Personnel.
    /// </summary>
    public class PersonnelDal
    {
        /// <summary>
        /// Récupère tous les employés de la base de données
        /// </summary>
        /// <returns>Une liste d'objets Personnel</returns>
        public static List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();

            // On récupère la connexion unique
            BddManager bdd = BddManager.GetInstance();
            string req = "SELECT * FROM personnel";

            try
            {
                bdd.OpenConnection();
                MySqlDataReader reader = bdd.ReqSelect(req, null); // Assure-toi d'avoir une méthode ReqSelect dans ton BddManager
                while (reader.Read())
                {
                    Personnel p = new Personnel(
                        (int)reader["idpersonnel"],
                        reader["nom"].ToString(),
                        reader["prenom"].ToString(),
                        reader["tel"].ToString(),
                        reader["mail"].ToString(),
                        (int)reader["idservice"]
                    );
                    lesPersonnels.Add(p);
                }
                reader.Close();
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            bdd.CloseConnection();
            return lesPersonnels;
        }
    }
}