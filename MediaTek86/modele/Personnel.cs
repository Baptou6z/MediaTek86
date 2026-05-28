namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un membre du personnel de l'entreprise.
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Identifiant unique du personnel.
        /// </summary>
        public int Idpersonnel { get; set; }

        /// <summary>
        /// Nom de famille du membre du personnel.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du membre du personnel.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro de téléphone.
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Adresse email.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Identifiant du service auquel appartient le membre du personnel.
        /// </summary>
        public int Idservice { get; set; }

        /// <summary>
        /// Constructeur de la classe Personnel.
        /// </summary>
        /// <param name="idpersonnel">Identifiant.</param>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        /// <param name="tel">Téléphone.</param>
        /// <param name="mail">Email.</param>
        /// <param name="idservice">Id du service.</param>
        public Personnel(int idpersonnel, string nom, string prenom, string tel, string mail, int idservice)
        {
            Idpersonnel = idpersonnel;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            Idservice = idservice;
        }
    }
}