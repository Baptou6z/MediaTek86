using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.modele;
using MediaTek86.dal;

namespace MediaTek86.vue
{
    public partial class FrmGestion : Form
    {
        public FrmGestion()
        {
            InitializeComponent();
            // On force manuellement le lien entre le bouton et la méthode
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
        }

        private void FrmGestion_Load(object sender, EventArgs e)
        {
            RemplirListePersonnel();
        }

        private void RemplirListePersonnel()
        {
            // Appel à la DAL pour récupérer la liste du personnel
            List<Personnel> lesPersonnels = PersonnelDal.GetLesPersonnels();

            // Affectation de la liste au DataGridView
            dgvPersonnel.DataSource = lesPersonnels;
        }

        /// <summary>
        /// Événement au clic sur le bouton Ajouter.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // 1. On vérifie que les champs obligatoires ne sont pas vides
            if (txbNom.Text != "" && txbPrenom.Text != "")
            {
                // Note : On met "1" par défaut pour le service en attendant de coder la liste déroulante (ComboBox)
                int idServiceTemp = 1;

                // 2. On crée un nouvel objet métier Personnel avec les données tapées dans les cases
                Personnel nouveauPersonnel = new Personnel(0, txbNom.Text, txbPrenom.Text, txbTel.Text, txbMail.Text, idServiceTemp);

                // 3. On envoie l'objet à la DAL pour l'insérer dans la base
                PersonnelDal.AddPersonnel(nouveauPersonnel);

                // 4. On rafraîchit immédiatement le tableau pour voir apparaître le nouveau salarié
                RemplirListePersonnel();

                // 5. On vide les cases pour faire propre
                txbNom.Text = "";
                txbPrenom.Text = "";
                txbTel.Text = "";
                txbMail.Text = "";
            }
            else
            {
                MessageBox.Show("Veuillez au moins renseigner le nom et le prénom de l'employé.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}