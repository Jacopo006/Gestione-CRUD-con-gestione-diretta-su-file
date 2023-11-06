using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestione_CRUD_con_gestione_diretta_su_file
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int record = 64;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //cancellazione logica
        private void cancella_Click(object sender, EventArgs e)
        {
                int indice = ricercaindice(textBox1.Text);
                if (indice != -1)
                {
                    string[] prodotto = ricercaprod(textBox1.Text);
                    string linea;
                    var file = new FileStream("File.txt", FileMode.Open, FileAccess.Write);
                    BinaryWriter writer = new BinaryWriter(file);
                    file.Seek(record * indice, SeekOrigin.Begin);
                    linea = $"{prodotto[0]};{prodotto[1]};{prodotto[3]};1;".PadRight(record - 4) + "##";
                    byte[] bytes = Encoding.UTF8.GetBytes(linea);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                    file.Close();
                }
                else
                {
                    // Gestisci il caso in cui l'elemento non è stato trovato
                    MessageBox.Show("L'elemento da cancellare non è stato trovato.");
                }
        }

        //bottone modifica
        private void modifica_Click(object sender, EventArgs e)
        {
            int indice = ricercaindice(nomexmodifica.Text);

            if (indice != -1)
            {
                // Verifica se l'indice è valido
               
                    string linea;
                    var file = new FileStream("File.txt", FileMode.Open, FileAccess.Write);
                    BinaryWriter writer = new BinaryWriter(file);
                    file.Seek(record * indice, SeekOrigin.Begin);
                    linea = $"{nomemodificato.Text};{prezzomodificato.Text};1;0;".PadRight(record - 4) + "##";
                    byte[] bytes = Encoding.UTF8.GetBytes(linea);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                    file.Close();
            }
            else
            {
                // Gestisci il caso in cui l'elemento da modificare non è stato trovato
                MessageBox.Show("L'elemento da modificare non è stato trovato.");
            }
        }

        //cancellazione fisica
        private void button2_Click(object sender, EventArgs e)
        {
            int indice = ricercaindice(textBox2.Text);

            string[] linea = File.ReadAllLines("File.txt");
            for (int i = indice; i < linea.Length - 1; i++)
            {
                linea[i] = linea[i + 1];
            }

            var file = new FileStream("File.txt", FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(string.Empty);
            sw.Close();

            var files = new FileStream("File.txt", FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sws = new StreamWriter(files);
            for (int i = 0; i < linea.Length - 1; i++)
            {
                sws.WriteLine(linea[i]);
            }
            sws.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Apre il file "File.txt" in modalità append (aggiunta), con accesso in scrittura,consentendo la lettura da altri processi.
            var file = new FileStream("File.txt", FileMode.Append, FileAccess.Write, FileShare.Read);

            // Crea un oggetto StreamWriter per scrivere nel file aperto.
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine($"{NOMEPRODOTTO.Text};{PREZZO.Text};1;0;".PadRight(record - 4) + "##");

                // Chiude il file e il StreamWriter per rilasciare le risorse.
                sw.Close();
            }
        }

        public int ricercaindice(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText("File.txt"))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] prodotti = linea.Split(';');
                    if (prodotti[3] == "0" && prodotti[0].Equals(nome))
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
            }
            return -1;
        }
        public string[] ricercaprod(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText("File.txt"))
            {
                string linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    string[] prodotti = linea.Split(';');
                    if (prodotti[3] == "0" && prodotti[0] == nome)
                    {
                        sr.Close();
                        return prodotti;
                    }
                    riga++;
                }
            }
            return null;
        }




        private void NOMEPRODOTTO_TextChanged(object sender, EventArgs e)
        {

        }
        private void PREZZO_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void prezzoxmodifica_TextChanged(object sender, EventArgs e)
        {

        }

        private void nomemodificato_TextChanged(object sender, EventArgs e)
        {

        }

        private void prezzomodificato_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
