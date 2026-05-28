namespace MediaTek86.vue
{
    partial class FrmGestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbNom = new System.Windows.Forms.Label();
            this.txbPrenom = new System.Windows.Forms.Label();
            this.txbTel = new System.Windows.Forms.Label();
            this.txbMail = new System.Windows.Forms.Label();
            this.txbService = new System.Windows.Forms.Label();
            this.cbxService = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAbsences = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPersonnel
            // 
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Location = new System.Drawing.Point(12, 12);
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.Size = new System.Drawing.Size(368, 409);
            this.dgvPersonnel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbsences);
            this.groupBox1.Controls.Add(this.btnSupprimer);
            this.groupBox1.Controls.Add(this.btnModifier);
            this.groupBox1.Controls.Add(this.btnAjouter);
            this.groupBox1.Controls.Add(this.cbxService);
            this.groupBox1.Controls.Add(this.txbService);
            this.groupBox1.Controls.Add(this.txbMail);
            this.groupBox1.Controls.Add(this.txbTel);
            this.groupBox1.Controls.Add(this.txbPrenom);
            this.groupBox1.Controls.Add(this.txbNom);
            this.groupBox1.Location = new System.Drawing.Point(441, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 233);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gérer un employé";
            // 
            // txbNom
            // 
            this.txbNom.AutoSize = true;
            this.txbNom.Location = new System.Drawing.Point(15, 33);
            this.txbNom.Name = "txbNom";
            this.txbNom.Size = new System.Drawing.Size(29, 13);
            this.txbNom.TabIndex = 0;
            this.txbNom.Text = "Nom";
            // 
            // txbPrenom
            // 
            this.txbPrenom.AutoSize = true;
            this.txbPrenom.Location = new System.Drawing.Point(15, 56);
            this.txbPrenom.Name = "txbPrenom";
            this.txbPrenom.Size = new System.Drawing.Size(43, 13);
            this.txbPrenom.TabIndex = 1;
            this.txbPrenom.Text = "Prenom";
            // 
            // txbTel
            // 
            this.txbTel.AutoSize = true;
            this.txbTel.Location = new System.Drawing.Point(15, 82);
            this.txbTel.Name = "txbTel";
            this.txbTel.Size = new System.Drawing.Size(22, 13);
            this.txbTel.TabIndex = 2;
            this.txbTel.Text = "Tel";
            // 
            // txbMail
            // 
            this.txbMail.AutoSize = true;
            this.txbMail.Location = new System.Drawing.Point(15, 106);
            this.txbMail.Name = "txbMail";
            this.txbMail.Size = new System.Drawing.Size(26, 13);
            this.txbMail.TabIndex = 3;
            this.txbMail.Text = "Mail";
            // 
            // txbService
            // 
            this.txbService.AutoSize = true;
            this.txbService.Location = new System.Drawing.Point(15, 131);
            this.txbService.Name = "txbService";
            this.txbService.Size = new System.Drawing.Size(43, 13);
            this.txbService.TabIndex = 4;
            this.txbService.Text = "Service";
            // 
            // cbxService
            // 
            this.cbxService.FormattingEnabled = true;
            this.cbxService.Location = new System.Drawing.Point(73, 131);
            this.cbxService.Name = "cbxService";
            this.cbxService.Size = new System.Drawing.Size(121, 21);
            this.cbxService.TabIndex = 5;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(18, 158);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 6;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(119, 158);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 7;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(221, 158);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(75, 23);
            this.btnSupprimer.TabIndex = 8;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            // 
            // btnAbsences
            // 
            this.btnAbsences.Location = new System.Drawing.Point(73, 204);
            this.btnAbsences.Name = "btnAbsences";
            this.btnAbsences.Size = new System.Drawing.Size(142, 23);
            this.btnAbsences.TabIndex = 9;
            this.btnAbsences.Text = "Gérer les absences";
            this.btnAbsences.UseVisualStyleBackColor = true;
            // 
            // FrmGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPersonnel);
            this.Name = "FrmGestion";
            this.Text = "FrmGestion";
            this.Load += new System.EventHandler(this.FrmGestion_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txbMail;
        private System.Windows.Forms.Label txbTel;
        private System.Windows.Forms.Label txbPrenom;
        private System.Windows.Forms.Label txbNom;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.ComboBox cbxService;
        private System.Windows.Forms.Label txbService;
        private System.Windows.Forms.Button btnAbsences;
    }
}