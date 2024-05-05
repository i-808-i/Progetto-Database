namespace ProgettoDatabaseSiintTest
{
    partial class homepage
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.list_stampe = new System.Windows.Forms.ListBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_aggiorna = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkList_Ambienti = new System.Windows.Forms.CheckedListBox();
            this.cmb_GrpUtente = new System.Windows.Forms.ComboBox();
            this.btn_salva = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_stampe
            // 
            this.list_stampe.FormattingEnabled = true;
            this.list_stampe.ItemHeight = 20;
            this.list_stampe.Location = new System.Drawing.Point(12, 12);
            this.list_stampe.Name = "list_stampe";
            this.list_stampe.Size = new System.Drawing.Size(222, 384);
            this.list_stampe.TabIndex = 0;
            this.list_stampe.SelectedValueChanged += new System.EventHandler(this.list_stampe_SelectedValueChanged);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(12, 402);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(96, 37);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "Aggiungi";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_aggiorna
            // 
            this.btn_aggiorna.Location = new System.Drawing.Point(138, 402);
            this.btn_aggiorna.Name = "btn_aggiorna";
            this.btn_aggiorna.Size = new System.Drawing.Size(96, 37);
            this.btn_aggiorna.TabIndex = 2;
            this.btn_aggiorna.Text = "Aggiorna";
            this.btn_aggiorna.UseVisualStyleBackColor = true;
            this.btn_aggiorna.Click += new System.EventHandler(this.btn_aggiorna_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkList_Ambienti);
            this.panel1.Controls.Add(this.cmb_GrpUtente);
            this.panel1.Location = new System.Drawing.Point(270, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 384);
            this.panel1.TabIndex = 3;
            // 
            // chkList_Ambienti
            // 
            this.chkList_Ambienti.FormattingEnabled = true;
            this.chkList_Ambienti.Location = new System.Drawing.Point(17, 35);
            this.chkList_Ambienti.Name = "chkList_Ambienti";
            this.chkList_Ambienti.Size = new System.Drawing.Size(458, 349);
            this.chkList_Ambienti.TabIndex = 1;
            // 
            // cmb_GrpUtente
            // 
            this.cmb_GrpUtente.FormattingEnabled = true;
            this.cmb_GrpUtente.Location = new System.Drawing.Point(17, 0);
            this.cmb_GrpUtente.Name = "cmb_GrpUtente";
            this.cmb_GrpUtente.Size = new System.Drawing.Size(167, 28);
            this.cmb_GrpUtente.TabIndex = 0;
            this.cmb_GrpUtente.SelectedIndexChanged += new System.EventHandler(this.cmb_GrpUtente_SelectedIndexChanged);
            // 
            // btn_salva
            // 
            this.btn_salva.Location = new System.Drawing.Point(649, 402);
            this.btn_salva.Name = "btn_salva";
            this.btn_salva.Size = new System.Drawing.Size(96, 37);
            this.btn_salva.TabIndex = 4;
            this.btn_salva.Text = "Salva";
            this.btn_salva.UseVisualStyleBackColor = true;
            this.btn_salva.Click += new System.EventHandler(this.btn_salva_Click);
            // 
            // homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 447);
            this.Controls.Add(this.btn_salva);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_aggiorna);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.list_stampe);
            this.Name = "homepage";
            this.Text = "Homepage";
            this.Load += new System.EventHandler(this.homepage_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list_stampe;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_aggiorna;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox chkList_Ambienti;
        private System.Windows.Forms.ComboBox cmb_GrpUtente;
        private System.Windows.Forms.Button btn_salva;
    }
}

