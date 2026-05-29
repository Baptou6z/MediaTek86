namespace MediaTek86.modele
{
    /// <summary>
    /// Classe métier représentant un Service de l'entreprise.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Obtient l'identifiant du service.
        /// </summary>
        public int Idservice { get; }
        /// <summary>
        /// Obtient le nom du service.
        /// </summary>
        public string Nom { get; }
        /// <summary>
        /// Constructeur de la classe Service.
        /// </summary>
        /// <param name="idservice">L'identifiant unique du service.</param>
        /// <param name="nom">Le nom du service.</param>
        public Service(int idservice, string nom)
        {
            this.Idservice = idservice;
            this.Nom = nom;
        }

        /// <summary>
        /// Définit ce qui s'affichera par défaut dans la ComboBox
        /// </summary>
        public override string ToString()
        {
            return this.Nom;
        }
    }
}