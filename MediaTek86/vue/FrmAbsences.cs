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
    }
}