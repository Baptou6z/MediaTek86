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
            RemplirComboBoxServices();
            RemplirListePersonnel();
        }

        private void RemplirListePersonnel()
        {
            // Appel à la DAL pour récupérer la liste du personnel
            List<Personnel> lesPersonnels = PersonnelDal.GetLesPersonnels();

            // Affectation de la liste au DataGridView
            dgvPersonnel.DataSource = lesPersonnels;
        }

        private void RemplirComboBoxServices()
        {
            // On récupère la liste des services depuis la DAL
            List<Service> lesServices = ServiceDal.GetLesServices();

            // On l'injecte dans la liste déroulante
            cbxService.DataSource = lesServices;
            cbxService.DisplayMember = "Nom";      // Ce que l'utilisateur voit (ex: "Administratif")
            cbxService.ValueMember = "Idservice";  // Ce que le code utilise (ex: "1")
        }

        /// <summary>
        /// Événement au clic sur le bouton Ajouter.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // 1. On vérifie que les champs obligatoires ne sont pas vides
            if (txbNom.Text != "" && txbPrenom.Text != "")
            {
                // On récupère le vrai ID du service sélectionné dans la liste déroulante
                int idServiceSelectionne = (int)cbxService.SelectedValue;

                // 2. On crée un nouvel objet métier Personnel avec les données tapées dans les cases
                Personnel nouveauPersonnel = new Personnel(0, txbNom.Text, txbPrenom.Text, txbTel.Text, txbMail.Text, idServiceSelectionne);

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

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // 1. Vérifier qu'une ligne est bien sélectionnée dans le tableau
            if (dgvPersonnel.SelectedRows.Count > 0)
            {
                // 2. Demander confirmation (très important pour le jury !)
                DialogResult confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet employé ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    // 3. Récupérer l'ID de la ligne sélectionnée
                    // On cast l'objet DataBoundItem en Personnel pour récupérer son ID
                    Personnel p = (Personnel)dgvPersonnel.SelectedRows[0].DataBoundItem;

                    // 4. Appeler la DAL
                    PersonnelDal.DeletePersonnel(p.Idpersonnel);

                    // 5. Rafraîchir le tableau
                    RemplirListePersonnel();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.");
            }
        }

        private void dgvPersonnel_SelectionChanged(object sender, EventArgs e)
        {
            // On vérifie qu'une ligne est bien sélectionnée
            if (dgvPersonnel.SelectedRows.Count > 0)
            {
                // On récupère l'employé sélectionné
                Personnel p = (Personnel)dgvPersonnel.SelectedRows[0].DataBoundItem;

                // On remplit les TextBox avec ses informations
                txbNom.Text = p.Nom;
                txbPrenom.Text = p.Prenom;
                txbTel.Text = p.Tel;
                txbMail.Text = p.Mail;

                // On sélectionne le bon service dans la liste déroulante
                cbxService.SelectedValue = p.Idservice;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            // 1. On vérifie qu'une ligne est sélectionnée dans le tableau
            if (dgvPersonnel.SelectedRows.Count > 0)
            {
                // 2. On vérifie que les champs obligatoires ne sont pas vides
                if (txbNom.Text != "" && txbPrenom.Text != "")
                {
                    // 3. On récupère l'ID de l'employé en cours de modification
                    Personnel pSelectionne = (Personnel)dgvPersonnel.SelectedRows[0].DataBoundItem;
                    int idEmploye = pSelectionne.Idpersonnel;

                    // On récupère le vrai ID du service sélectionné dans la liste déroulante
                    int idServiceSelectionne = (int)cbxService.SelectedValue;

                    // 4. On crée un nouvel objet métier avec les nouvelles informations des TextBox
                    Personnel personnelModifie = new Personnel(idEmploye, txbNom.Text, txbPrenom.Text, txbTel.Text, txbMail.Text, idServiceSelectionne);

                    // 5. On appelle la méthode Update de la DAL
                    PersonnelDal.UpdatePersonnel(personnelModifie);

                    // 6. On met à jour l'affichage
                    RemplirListePersonnel();

                    // 7. On vide les cases (optionnel mais plus propre)
                    txbNom.Text = "";
                    txbPrenom.Text = "";
                    txbTel.Text = "";
                    txbMail.Text = "";
                }
                else
                {
                    MessageBox.Show("Veuillez renseigner au moins le nom et le prénom.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé à modifier.");
            }
        }

        private void btnAbsences_Click(object sender, EventArgs e)
        {
            // 1. On vérifie qu'un employé est bien sélectionné dans le tableau
            if (dgvPersonnel.SelectedRows.Count > 0)
            {
                // 2. On récupère l'employé sélectionné
                Personnel pSelectionne = (Personnel)dgvPersonnel.SelectedRows[0].DataBoundItem;

                // 3. On ouvre la fenêtre des absences en lui "envoyant" l'employé sélectionné
                FrmAbsences frmAbsences = new FrmAbsences(pSelectionne);

                // ShowDialog() permet d'ouvrir la fenêtre par-dessus l'autre et de bloquer la fenêtre principale
                frmAbsences.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé pour gérer ses absences.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}