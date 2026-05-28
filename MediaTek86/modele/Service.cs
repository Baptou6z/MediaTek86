namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un service dans l'entreprise.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant unique du service.
        /// </summary>
        public int Idservice { get; set; }

        /// <summary>
        /// Libellé descriptif du service (ex: Informatique, RH).
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur de la classe Service.
        /// </summary>
        /// <param name="idservice">Identifiant.</param>
        /// <param name="libelle">Libellé du service.</param>
        public Service(int idservice, string libelle)
        {
            Idservice = idservice;
            Libelle = libelle;
        }
    }
}