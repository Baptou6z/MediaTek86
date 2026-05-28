using MediaTek86.bddmanager;
using MediaTek86.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour les objets Absence.
    /// </summary>
    public class AbsenceDal
    {
        /// <summary>
        /// Récupère toutes les absences de la base de données
        /// </summary>
        /// <returns>Une liste d'objets Absence</returns>
        public static List<Absence> GetLesAbsences()
        {
            List<Absence> lesAbsences = new List<Absence>();
            BddManager bdd = BddManager.GetInstance();
            string req = "SELECT * FROM absence";
            try
            {
                bdd.OpenConnection();
                MySqlDataReader reader = bdd.ReqSelect(req, null);
                while (reader.Read())
                {
                    Absence a = new Absence(
                        (int)reader["idpersonnel"],
                        (DateTime)reader["dateDebut"],
                        (DateTime)reader["dateFin"],
                        (int)reader["idmotif"]
                    );
                    lesAbsences.Add(a);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            bdd.CloseConnection();
            return lesAbsences;
        }
    }
}