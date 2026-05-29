using MediaTek86.bddmanager;
using MediaTek86.modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            MySqlDataReader reader = null;
            try
            {
                bdd.OpenConnection();
                reader = bdd.ReqSelect(req, parameters);
                if (reader.Read())
                {
                    resp = new Responsable(
                        0,
                        reader["login"].ToString(),
                        reader["pwd"].ToString()
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur SQL : " + e.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
                bdd.CloseConnection();
            }
            return resp;
        }
    }
}

     
