namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un responsable ayant accès à l'application.
    /// </summary>
    public class Responsable
    {
        /// <summary>
        /// Identifiant unique du responsable.
        /// </summary>
        public int Idresponsable { get; set; }

        /// <summary>
        /// Login utilisé par le responsable pour se connecter.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Mot de passe du responsable.
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// Constructeur de la classe Responsable.
        /// </summary>
        /// <param name="idresponsable">Identifiant.</param>
        /// <param name="login">Login de connexion.</param>
        /// <param name="pwd">Mot de passe.</param>
        public Responsable(int idresponsable, string login, string pwd)
        {
            Idresponsable = idresponsable;
            Login = login;
            Pwd = pwd;
        }
    }
}