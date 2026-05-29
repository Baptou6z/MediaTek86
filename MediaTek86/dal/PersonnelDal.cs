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
                MySqlDataReader reader = bdd.ReqSelect(req, null);
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

        /// <summary>
        /// Ajoute un nouvel employé dans la base de données.
        /// </summary>
        /// <param name="p">L'objet Personnel contenant les informations à insérer</param>
        public static void AddPersonnel(Personnel p)
        {
            BddManager bdd = BddManager.GetInstance();

            // La requête SQL avec des paramètres (@nom, @prenom...) pour la sécurité
            string req = "INSERT INTO personnel (nom, prenom, tel, mail, idservice) VALUES (@nom, @prenom, @tel, @mail, @idservice)";

            // On associe les valeurs de l'objet aux paramètres SQL
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@nom", p.Nom);
            parameters.Add("@prenom", p.Prenom);
            parameters.Add("@tel", p.Tel);
            parameters.Add("@mail", p.Mail);
            parameters.Add("@idservice", p.Idservice);

            try
            {
                bdd.OpenConnection();
                // On exécute la requête de mise à jour (insertion)
                bdd.ReqUpdate(req, parameters);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                bdd.CloseConnection();
            }
        }
        /// <summary>
        /// Supprime un employé de la base de données.
        /// </summary>
        /// <param name="id">L'identifiant du personnel à supprimer</param>
        public static void DeletePersonnel(int id)
        {
            BddManager bdd = BddManager.GetInstance();
            string req = "DELETE FROM personnel WHERE idpersonnel = @id";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            try
            {
                bdd.OpenConnection();
                bdd.ReqUpdate(req, parameters);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erreur lors de la suppression : " + e.Message);
            }
            finally
            {
                bdd.CloseConnection();
            }
        }
    }
}