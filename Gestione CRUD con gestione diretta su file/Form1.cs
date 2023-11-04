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

        private void NOMEPRODOTTO_TextChanged(object sender, EventArgs e)
        {

        }

        private void PREZZO_TextChanged(object sender, EventArgs e)
        {

        }







        public int ricercaindice(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText("File.dat"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
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
            using (StreamReader sr = File.OpenText("File.dat"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }



        //cancellazione logica
        private void cancella_Click(object sender, EventArgs e)
        {
            int indice = ricercaindice(nomexmodifica.Text.ToLower());
            string[] prodotto = ricercaprod(nomexmodifica.Text.ToLower());
            string line;
            var file = new FileStream("File.dat", FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(record * indice, SeekOrigin.Begin);
            line = $"{prodotto[0]};{prodotto[1]};{prodotto[3]};1;".PadRight(record - 4) + "##";
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            file.Close();
        }

        private void modifica_Click(object sender, EventArgs e)
        {
            int indice = ricercaindice(nomexmodifica.Text.ToLower());
            string line;
            var file = new FileStream("File.dat", FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(record * indice, SeekOrigin.Begin);
            line = $"{nomemodificato.Text.ToLower()};{prezzomodificato.Text};1;0;".PadRight(record - 4) + "##";
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            file.Close();
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
        //cancellazione fisica
        private void button2_Click(object sender, EventArgs e)
        {
            int indice = ricercaindice(textBox1.Text);
            string[] line = File.ReadAllLines("File.dat");
            for (int i = indice; i < line.Length - 1; i++)
            {
                line[i] = line[i + 1];
            }

            var file = new FileStream("File.dat", FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(string.Empty);
            sw.Close();

            var files = new FileStream("File.dat", FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sws = new StreamWriter(files);
            for (int i = 0; i < line.Length - 1; i++)
            {
                sws.WriteLine(line[i]);
            }
            sws.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Apre il file "File.dat" in modalità append (aggiunta), con accesso in scrittura,consentendo la lettura da altri processi.
            var file = new FileStream("File.dat", FileMode.Append, FileAccess.Write, FileShare.Read);

            // Crea un oggetto StreamWriter per scrivere nel file aperto.
            using (StreamWriter sw = new StreamWriter(file))
            {
                // Scrive una riga di dati nel file:
                // - {NOMEPRODOTTO.Text} e {PREZZO.Text} sono i valori dai campi di testo dell'interfaccia utente.
                // - "1;0;" sono valori fissi.
                // - .PadRight(record - 4) aggiunge spazi vuoti per raggiungere una lunghezza totale di "record - 4".
                // - "##" è un delimitatore alla fine della riga.
                sw.WriteLine($"{NOMEPRODOTTO.Text.ToLower()};{PREZZO.Text};1;0;".PadRight(record - 4) + "##");//to lower ti scrive in minuscolo

                // Chiude il file e il StreamWriter per rilasciare le risorse.
                sw.Close();
            }
        }
    }
}
