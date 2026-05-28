using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.modele; // Pour accéder à la classe Personnel
using MediaTek86.dal;    // Pour accéder à PersonnelDal

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
        /// Événement déclenché au chargement de la fenêtre.
        /// </summary>
        private void FrmGestion_Load(object sender, EventArgs e)
        {
            RemplirListePersonnel();
        }

        /// <summary>
        /// Récupère la liste du personnel via la DAL et met à jour le DataGridView.
        /// </summary>
        private void RemplirListePersonnel()
        {
            // Appel à la DAL pour récupérer la liste du personnel (et non des motifs)
            List<Personnel> lesPersonnels = PersonnelDal.GetLesPersonnels();

            // Affectation de la liste au DataGridView
            dgvPersonnel.DataSource = lesPersonnels;
        }
    }
}