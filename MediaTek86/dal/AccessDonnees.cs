using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTek86.dal
{
    /// <summary>
    /// Classe utilitaire permettant de récupérer la chaîne de connexion à la base de données.
    /// </summary>
    public class AccessDonnees
    {
        /// <summary>
        /// Retourne la chaîne de connexion configurée pour la base MySQL.
        /// </summary>
        /// <returns>La chaîne de connexion sous forme de string.</returns>
        public static string GetConnectionString()
        {
            return "server=localhost;user id=root;password=;database=mediatek86;sslmode=none";
        }
    }
}