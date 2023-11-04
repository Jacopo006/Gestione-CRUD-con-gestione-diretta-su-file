namespace Gestione_CRUD_con_gestione_diretta_su_file
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PREZZO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NOMEPRODOTTO = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 76);
            this.button1.TabIndex = 0;
            this.button1.Text = "AGGIUNGI";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "INSERISCI NUOVO PRODOTTO";
            // 
            // PREZZO
            // 
            this.PREZZO.Location = new System.Drawing.Point(37, 138);
            this.PREZZO.Name = "PREZZO";
            this.PREZZO.Size = new System.Drawing.Size(100, 20);
            this.PREZZO.TabIndex = 2;
            this.PREZZO.TextChanged += new System.EventHandler(this.PREZZO_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "INSERISCI IL PREZZO DEL NUOVO PRODOTTO";
            // 
            // NOMEPRODOTTO
            // 
            this.NOMEPRODOTTO.Location = new System.Drawing.Point(37, 98);
            this.NOMEPRODOTTO.Name = "NOMEPRODOTTO";
            this.NOMEPRODOTTO.Size = new System.Drawing.Size(100, 20);
            this.NOMEPRODOTTO.TabIndex = 4;
            this.NOMEPRODOTTO.TextChanged += new System.EventHandler(this.NOMEPRODOTTO_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 551);
            this.Controls.Add(this.NOMEPRODOTTO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PREZZO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PREZZO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NOMEPRODOTTO;
    }
}

