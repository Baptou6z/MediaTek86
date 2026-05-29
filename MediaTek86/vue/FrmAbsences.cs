using MediaTek86.dal;
using MediaTek86.modele; // N'oublie pas cette ligne pour utiliser la classe Personnel
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public partial class FrmAbsences : Form
    {
        // On crée une variable pour mémoriser l'employé sur lequel on travaille
        private Personnel lePersonnel;

        // On modifie le constructeur pour qu'il reçoive l'employé
        public FrmAbsences(Personnel pSelectionne)
        {
            InitializeComponent();

            // On stocke l'employé reçu dans notre variable
            this.lePersonnel = pSelectionne;

            // Petit bonus : on change le titre de la fenêtre pour afficher le nom de l'employé !
            this.Text = "Gestion des absences de " + lePersonnel.Nom + " " + lePersonnel.Prenom;
        }

        private void FrmAbsences_Load(object sender, EventArgs e)
        {
            RemplirComboBoxMotifs();
            RemplirListeAbsences();
        }

        private void RemplirListeAbsences()
        {
            // lePersonnel a été envoyé par la fenêtre principale
            List<Absence> lesAbsences = AbsenceDal.GetLesAbsences(lePersonnel.Idpersonnel);

            // Adapte "dgvAbsences" selon le vrai nom de ton tableau
            dgvAbsences.DataSource = lesAbsences;
        }

        private void RemplirComboBoxMotifs()
        {
            // Adapte selon ta vraie classe MotifDal
            List<Motif> lesMotifs = MotifDal.GetLesMotifs();

            // Adapte "cbxMotif" selon le nom de ta liste déroulante
            cbxMotif.DataSource = lesMotifs;
            cbxMotif.DisplayMember = "Libelle";
            cbxMotif.ValueMember = "Idmotif";
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // On récupère les dates des sélecteurs (je suppose qu'ils s'appellent dtpDateDebut et dtpDateFin)
            DateTime dateDebut = dtpDebut.Value.Date;
            DateTime dateFin = dtpFin.Value.Date;

            // 1. Petite sécurité : la date de fin ne peut pas être avant la date de début !
            if (dateDebut <= dateFin)
            {
                // 2. On récupère l'ID du motif sélectionné
                int idMotifSelectionne = (int)cbxMotif.SelectedValue;

                // 3. On crée un nouvel objet Absence
                // On utilise 'lePersonnel.Idpersonnel' pour lier l'absence au bon employé
                Absence nouvelleAbsence = new Absence(lePersonnel.Idpersonnel, dateDebut, dateFin, idMotifSelectionne);

                // 4. On l'envoie à la DAL pour insertion
                AbsenceDal.AddAbsence(nouvelleAbsence);

                // 5. On rafraîchit le tableau pour voir la nouvelle absence
                RemplirListeAbsences();
            }
            else
            {
                MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // 1. Vérifier qu'une ligne est bien sélectionnée dans le tableau des absences
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                // 2. Demander confirmation avant de supprimer
                DialogResult confirmation = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette absence ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    // 3. Récupérer l'absence sélectionnée
                    Absence absenceSelectionnee = (Absence)dgvAbsences.SelectedRows[0].DataBoundItem;

                    // 4. Appeler la méthode de suppression de la DAL
                    AbsenceDal.DeleteAbsence(absenceSelectionnee);

                    // 5. Rafraîchir le tableau
                    RemplirListeAbsences();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une absence dans le tableau.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvAbsences_SelectionChanged(object sender, EventArgs e)
        {
            // On vérifie qu'une ligne est sélectionnée
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                // On récupère l'absence cliquée
                Absence a = (Absence)dgvAbsences.SelectedRows[0].DataBoundItem;

                // On met à jour les champs de l'interface
                dtpDebut.Value = a.DateDebut;
                dtpFin.Value = a.DateFin;
                cbxMotif.SelectedValue = a.Idmotif;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            // 1.On vérifie qu'une ligne est bien sélectionnée
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                // 2. On mémorise l'ancienne date de début à partir du tableau
                Absence ancienneAbsence = (Absence)dgvAbsences.SelectedRows[0].DataBoundItem;
                DateTime ancienneDateDebut = ancienneAbsence.DateDebut;

                // 3. On récupère les nouvelles dates des sélecteurs
                DateTime dateDebut = dtpDebut.Value.Date;
                DateTime dateFin = dtpFin.Value.Date;

                if (dateDebut <= dateFin)
                {
                    // 4. On récupère le motif et on crée la nouvelle absence
                    int idMotifSelectionne = (int)cbxMotif.SelectedValue;
                    Absence absenceModifiee = new Absence(lePersonnel.Idpersonnel, dateDebut, dateFin, idMotifSelectionne);

                    // 5. On envoie tout à la DAL
                    AbsenceDal.UpdateAbsence(absenceModifiee, ancienneDateDebut);

                    // 6. On rafraîchit l'affichage
                    RemplirListeAbsences();
                }
                else
                {
                    MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une absence à modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}