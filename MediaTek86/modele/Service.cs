namespace MediaTek86.modele
{
    /// <summary>
    /// Classe métier représentant un Service de l'entreprise.
    /// </summary>
    public class Service
    {
        public int Idservice { get; }
        public string Nom { get; }

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