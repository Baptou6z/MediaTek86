namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un motif d'absence.
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Identifiant unique du motif.
        /// </summary>
        public int Idmotif { get; set; }

        /// <summary>
        /// Libellé descriptif du motif (ex: Maladie, Congés).
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur de la classe Motif.
        /// </summary>
        /// <param name="idmotif">Identifiant.</param>
        /// <param name="libelle">Libellé du motif.</param>
        public Motif(int idmotif, string libelle)
        {
            Idmotif = idmotif;
            Libelle = libelle;
        }
    }
}
