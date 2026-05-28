using System;
namespace MediaTek86.modele
{
    /// <summary>
    /// Représente une absence dans l'entreprise.
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Identifiant du personnel.
        /// </summary>
        public int Idpersonnel { get; set; }

        /// <summary>
        /// Date de début de l'absence.
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'absence.
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Identifiant du motif d'absence.
        /// </summary>
        public int Idmotif { get; set; }

        /// <summary>
        /// Constructeur de la classe Absence.
        /// </summary>
        /// <param name="idpersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début.</param>
        /// <param name="dateFin">Date de fin.</param>
        /// <param name="idmotif">Identifiant du motif.</param>
        public Absence(int idpersonnel, DateTime dateDebut, DateTime dateFin, int idmotif)
        {
            Idpersonnel = idpersonnel;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Idmotif = idmotif;
        }
    }
}