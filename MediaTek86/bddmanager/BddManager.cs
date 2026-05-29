using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// Classe Singleton permettant de gérer la connexion à la base de données MySQL.
    /// </summary>
    public class BddManager
    {
        private static BddManager instance = null;
        private MySqlConnection connection;

        /// <summary>
        /// Constructeur privé pour le pattern Singleton.
        /// </summary>
        private BddManager()
        {
            string connectionString = dal.AccessDonnees.GetConnectionString();
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Retourne l'instance unique de BddManager.
        /// </summary>
        /// <returns>L'instance unique de BddManager.</returns>
        public static BddManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BddManager();
            }
            return instance;
        }

        /// <summary>
        /// Ouvre la connexion à la base de données si elle est fermée.
        /// </summary>
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        /// <summary>
        /// Exécute une requête SQL de type SELECT.
        /// </summary>
        /// <param name="req">La requête SQL à exécuter.</param>
        /// <param name="parametres">Dictionnaire des paramètres (clé, valeur).</param>
        /// <returns>Un lecteur de données (MySqlDataReader) pour parcourir les résultats.</returns>
        public MySqlDataReader ReqSelect(string req, Dictionary<string, object> parametres)
        {
            MySqlCommand command = new MySqlCommand(req, connection);

            if (parametres != null)
            {
                foreach (KeyValuePair<string, object> param in parametres)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            return command.ExecuteReader();
        }

        /// <summary>
        /// Exécute une requête SQL de type INSERT, UPDATE ou DELETE (Action).
        /// </summary>
        /// <param name="req">La requête SQL à exécuter.</param>
        /// <param name="parametres">Dictionnaire des paramètres (clé, valeur).</param>
        public void ReqUpdate(string req, Dictionary<string, object> parametres)
        {
            MySqlCommand command = new MySqlCommand(req, connection);

            if (parametres != null)
            {
                foreach (KeyValuePair<string, object> param in parametres)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Ferme la connexion à la base de données si elle est ouverte.
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Retourne l'objet de connexion MySqlConnection courant.
        /// </summary>
        /// <returns>L'objet MySqlConnection.</returns>
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}