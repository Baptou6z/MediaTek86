using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MediaTek86.modele;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour les objets Motif.
    /// </summary>
    public class MotifDal
    {
        /// <summary>
        /// Récupère tous les motifs d'absence.
        /// </summary>
        /// <returns>Une liste d'objets Motif.</returns>
        public static List<Motif> GetLesMotifs()
        {
            List<Motif> lesMotifs = new List<Motif>();
            string req = "SELECT * FROM motif";
            BddManager bdd = BddManager.GetInstance();

            bdd.OpenConnection();
            MySqlDataReader reader = bdd.ReqSelect(req, null);

            while (reader.Read())
            {
                Motif motif = new Motif(
                    (int)reader["idmotif"],
                    (string)reader["libelle"]
                );
                lesMotifs.Add(motif);
            }

            reader.Close();
            bdd.CloseConnection();
            return lesMotifs;
        }
    }
}