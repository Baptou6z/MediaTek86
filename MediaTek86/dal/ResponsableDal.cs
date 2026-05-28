using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MediaTek86.modele;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe d'accès aux données pour les objets Responsable.
    /// </summary>
    public class ResponsableDal
    {
        /// <summary>
        /// Récupère un responsable par son login
        /// </summary>
        /// <param name="login">Le login du responsable</param>
        /// <returns>Un objet Responsable ou null si non trouvé</returns>
        public static Responsable GetResponsableByLogin(string login)
        {
            Responsable resp = null;
            BddManager bdd = BddManager.GetInstance();
            string req = "SELECT * FROM responsable WHERE login = @login";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@login", login);
            try
            {
                bdd.OpenConnection();
                MySqlDataReader reader = bdd.ReqSelect(req, parameters);
                if (reader.Read())
                {
                    resp = new Responsable(
                        (int)reader["idresponsable"],
                        reader["login"].ToString(),
                        reader["pwd"].ToString()
                    );
                }
                reader.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            bdd.CloseConnection();
            return resp;
        }
    }
}