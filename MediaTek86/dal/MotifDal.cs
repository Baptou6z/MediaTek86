using System;
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
        /// Récupère tous les motifs d'absence
        /// </summary>
        /// <returns>Une liste d'objets Motif</returns>
        public static List<Motif> GetLesMotifs()
        {
            List<Motif> lesMotifs = new List<Motif>();
            BddManager bdd = BddManager.GetInstance();
            string req = "SELECT * FROM motif";
            try
            {
                bdd.OpenConnection();
                MySqlDataReader reader = bdd.ReqSelect(req, null);
                while (reader.Read())
                {
                    Motif m = new Motif((int)reader["idmotif"], reader["libelle"].ToString());
                    lesMotifs.Add(m);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            bdd.CloseConnection();
            return lesMotifs;
        }
    }
}