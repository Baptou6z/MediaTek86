using System;
using System.Windows.Forms;
using MediaTek86.modele;
using MediaTek86.dal;
using MediaTek86.vue;

namespace MediaTek86
{
    /// <summary>
    /// Fenêtre de connexion au logiciel.
    /// </summary>
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe FrmLogin.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement lors du clic sur le bouton de connexion.
        /// </summary>
        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            // 1. Récupération du responsable
            Responsable resp = ResponsableDal.GetResponsableByLogin(txbLogin.Text);

            if (resp != null)
            {
                // 2. Vérification directe (puisque le mdp en base est maintenant en clair)
                // On utilise .Trim() pour ignorer les espaces accidentels dans la base
                if (resp.Pwd.Trim() == txbPwd.Text.Trim())
                {
                    FrmGestion frm = new FrmGestion();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Mot de passe incorrect. Veuillez réessayer.");
                }
            }
            else
            {
                MessageBox.Show("Identifiant introuvable.");
            }
        }
    }
}