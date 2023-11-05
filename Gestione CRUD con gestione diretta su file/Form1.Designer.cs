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
            this.cancella = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nomexmodifica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nomemodificato = new System.Windows.Forms.TextBox();
            this.prezzomodificato = new System.Windows.Forms.TextBox();
            this.modifica = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 76);
            this.button1.TabIndex = 0;
            this.button1.Text = "AGGIUNGI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "INSERISCI NUOVO PRODOTTO";
            // 
            // PREZZO
            // 
            this.PREZZO.Location = new System.Drawing.Point(13, 68);
            this.PREZZO.Name = "PREZZO";
            this.PREZZO.Size = new System.Drawing.Size(100, 20);
            this.PREZZO.TabIndex = 2;
            this.PREZZO.TextChanged += new System.EventHandler(this.PREZZO_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "INSERISCI IL PREZZO DEL NUOVO PRODOTTO";
            // 
            // NOMEPRODOTTO
            // 
            this.NOMEPRODOTTO.Location = new System.Drawing.Point(13, 28);
            this.NOMEPRODOTTO.Name = "NOMEPRODOTTO";
            this.NOMEPRODOTTO.Size = new System.Drawing.Size(100, 20);
            this.NOMEPRODOTTO.TabIndex = 4;
            this.NOMEPRODOTTO.TextChanged += new System.EventHandler(this.NOMEPRODOTTO_TextChanged);
            // 
            // cancella
            // 
            this.cancella.Location = new System.Drawing.Point(309, 303);
            this.cancella.Name = "cancella";
            this.cancella.Size = new System.Drawing.Size(107, 76);
            this.cancella.TabIndex = 5;
            this.cancella.Text = "CANCELLAZIONE  LOGICA";
            this.cancella.UseVisualStyleBackColor = true;
            this.cancella.Click += new System.EventHandler(this.cancella_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 319);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "INSERISCI IL NOME DEL PRODOTTO DA CANCELLARE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "INSERISCI IL NOME DEL PRODOTTO DA MODIFICARE";
            // 
            // nomexmodifica
            // 
            this.nomexmodifica.Location = new System.Drawing.Point(13, 141);
            this.nomexmodifica.Name = "nomexmodifica";
            this.nomexmodifica.Size = new System.Drawing.Size(100, 20);
            this.nomexmodifica.TabIndex = 9;
            this.nomexmodifica.TextChanged += new System.EventHandler(this.prezzoxmodifica_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "INSERISCI IL NUOVO NOME DEL PRODOTTO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "INSERISCI IL NUOVO PREZZO";
            // 
            // nomemodificato
            // 
            this.nomemodificato.Location = new System.Drawing.Point(13, 181);
            this.nomemodificato.Name = "nomemodificato";
            this.nomemodificato.Size = new System.Drawing.Size(100, 20);
            this.nomemodificato.TabIndex = 12;
            this.nomemodificato.TextChanged += new System.EventHandler(this.nomemodificato_TextChanged);
            // 
            // prezzomodificato
            // 
            this.prezzomodificato.Location = new System.Drawing.Point(13, 220);
            this.prezzomodificato.Name = "prezzomodificato";
            this.prezzomodificato.Size = new System.Drawing.Size(100, 20);
            this.prezzomodificato.TabIndex = 13;
            this.prezzomodificato.TextChanged += new System.EventHandler(this.prezzomodificato_TextChanged);
            // 
            // modifica
            // 
            this.modifica.Location = new System.Drawing.Point(393, 125);
            this.modifica.Name = "modifica";
            this.modifica.Size = new System.Drawing.Size(78, 76);
            this.modifica.TabIndex = 14;
            this.modifica.Text = "MODIFICA";
            this.modifica.UseVisualStyleBackColor = true;
            this.modifica.Click += new System.EventHandler(this.modifica_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 76);
            this.button2.TabIndex = 15;
            this.button2.Text = "CANCELLAZIONE FISICA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 431);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "INSERISCI IL NOME DEL PRODOTTO DA CANCELLARE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 551);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.modifica);
            this.Controls.Add(this.prezzomodificato);
            this.Controls.Add(this.nomemodificato);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nomexmodifica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancella);
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
        private System.Windows.Forms.Button cancella;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nomexmodifica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nomemodificato;
        private System.Windows.Forms.TextBox prezzomodificato;
        private System.Windows.Forms.Button modifica;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
    }
}

