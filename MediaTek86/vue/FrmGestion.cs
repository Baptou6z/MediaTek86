using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.modele; // Pour accéder à la classe Motif
using MediaTek86.dal;    // Pour accéder à MotifDal

namespace MediaTek86.vue
{
    /// <summary>
    /// Fenêtre principale de gestion de l'application.
    /// </summary>
    public partial class FrmGestion : Form
    {
        /// <summary>
        /// Initialise une nouvelle instance de la fenêtre FrmGestion.
        /// </summary>
        public FrmGestion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement des données au démarrage de la fenêtre.
        /// </summary>
        private void FrmGestion_Load(object sender, EventArgs e)
        {
            // Appel à la DAL pour récupérer la liste
            List<Motif> lesMotifs = MotifDal.GetLesMotifs();

            // Affectation au DataGridView (assure-toi que ton composant se nomme bien dgvMotifs)
            dgvPersonnel.DataSource = lesMotifs;
        }

        private void FrmGestion_Load_1(object sender, EventArgs e)
        {

        }
    }
}