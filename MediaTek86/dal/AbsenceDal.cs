using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MediaTek86.modele;
using MediaTek86.bddmanager;

namespace MediaTek86.dal
{
    public class AbsenceDal
    {
        /// <summary>
        /// Récupère la liste des absences d'un employé spécifique.
        /// </summary>
        /// <param name="idPersonnel">L'identifiant de l'employé</param>
        public static List<Absence> GetLesAbsences(int idPersonnel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            BddManager bdd = BddManager.GetInstance();

            // Requête ciblée sur l'employé, triée par date la plus récente
            string req = "SELECT * FROM absence WHERE idpersonnel = @idpersonnel ORDER BY datedebut DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", idPersonnel);

            try
            {
                bdd.OpenConnection();
                MySqlDataReader reader = bdd.ReqSelect(req, parameters);
                while (reader.Read())
                {
                    Absence a = new Absence(
                        (int)reader["idpersonnel"],
                        (DateTime)reader["datedebut"],
                        (DateTime)reader["datefin"],
                        (int)reader["idmotif"]
                    );
                    lesAbsences.Add(a);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erreur SQL (Absence) : " + e.Message);
            }
            finally
            {
                bdd.CloseConnection();
            }
            return lesAbsences;
        }
        /// <summary>
        /// Ajoute une nouvelle absence dans la base de données.
        /// </summary>
        /// <param name="a">L'objet Absence contenant les informations à insérer</param>
        public static void AddAbsence(Absence a)
        {
            BddManager bdd = BddManager.GetInstance();

            // La requête SQL d'insertion
            string req = "INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) VALUES (@idpersonnel, @datedebut, @datefin, @idmotif)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", a.Idpersonnel);
            // Formatage de la date au format standard MySQL (Année-Mois-Jour)
            parameters.Add("@datedebut", a.DateDebut.ToString("yyyy-MM-dd"));
            parameters.Add("@datefin", a.DateFin.ToString("yyyy-MM-dd"));
            parameters.Add("@idmotif", a.Idmotif);

            try
            {
                bdd.OpenConnection();
                bdd.ReqUpdate(req, parameters);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erreur SQL (Ajout Absence) : " + e.Message, "Erreur", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                bdd.CloseConnection();
            }
        }
        /// <summary>
        /// Supprime une absence de la base de données.
        /// </summary>
        /// <param name="a">L'objet Absence à supprimer</param>
        public static void DeleteAbsence(Absence a)
        {
            BddManager bdd = BddManager.GetInstance();

            // On utilise l'ID du personnel ET la date de début pour cibler la bonne ligne
            string req = "DELETE FROM absence WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", a.Idpersonnel);
            parameters.Add("@datedebut", a.DateDebut.ToString("yyyy-MM-dd"));

            try
            {
                bdd.OpenConnection();
                bdd.ReqUpdate(req, parameters);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erreur SQL (Suppression Absence) : " + e.Message, "Erreur", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                bdd.CloseConnection();
            }
        }
        /// <summary>
        /// Modifie une absence existante dans la base de données.
        /// </summary>
        /// <param name="absenceModifiee">L'objet Absence avec les nouvelles données</param>
        /// <param name="ancienneDateDebut">La date de début originale pour trouver la ligne à modifier</param>
        public static void UpdateAbsence(Absence absenceModifiee, DateTime ancienneDateDebut)
        {
            BddManager bdd = BddManager.GetInstance();

            // On met à jour les données, en ciblant l'employé et son ancienne date de début
            string req = "UPDATE absence SET datedebut = @nouvelleDateDebut, datefin = @datefin, idmotif = @idmotif WHERE idpersonnel = @idpersonnel AND datedebut = @ancienneDateDebut";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@idpersonnel", absenceModifiee.Idpersonnel);
            parameters.Add("@nouvelleDateDebut", absenceModifiee.DateDebut.ToString("yyyy-MM-dd"));
            parameters.Add("@datefin", absenceModifiee.DateFin.ToString("yyyy-MM-dd"));
            parameters.Add("@idmotif", absenceModifiee.Idmotif);
            parameters.Add("@ancienneDateDebut", ancienneDateDebut.ToString("yyyy-MM-dd"));

            try
            {
                bdd.OpenConnection();
                bdd.ReqUpdate(req, parameters);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erreur SQL (Modification Absence) : " + e.Message, "Erreur", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                bdd.CloseConnection();
            }
        }
    }
}