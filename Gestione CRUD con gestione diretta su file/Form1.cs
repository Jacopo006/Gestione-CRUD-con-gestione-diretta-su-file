using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestione_CRUD_con_gestione_diretta_su_file
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int record = 64;
        public string filePath = "File.txt";
        int[] array1 = new int[10000];
        int[] array2 = new int[10000];

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica se il campo del nome del prodotto o del prezzo è vuoto
            if (NOMEPRODOTTO.Text == string.Empty || PREZZO.Text == string.Empty)
            {
                MessageBox.Show("Devi inserire il nome del prodotto e il suo prezzo");
            }
            // Verifica se il prezzo è un valore numerico
            else if (float.TryParse(PREZZO.Text, out _) == false)
            {
                MessageBox.Show("Devi inserire il prezzo in valore numerico");
                PREZZO.Text = string.Empty; // Cancella il campo del prezzo
            }
            else
            {
                // Booleana per verificare se il prodotto è già presente nel file
                bool prodottoEsistente = false;

                // Leggi tutte le righe dal file
                string[] righeEsistenti = File.ReadAllLines("File.txt");

                // Itera su ogni riga per verificare se il prodotto è già presente
                for (int i = 0; i < righeEsistenti.Length; i++)
                {
                    // Suddividi la riga nei suoi componenti utilizzando il punto e virgola come separatore
                    string[] parti = righeEsistenti[i].Split(';');

                    // Verifica che la riga abbia almeno due parti e che il nome del prodotto corrisponda
                    if (parti.Length >= 2 && parti[0] == NOMEPRODOTTO.Text && parti[1] == PREZZO.Text)
                    {
                        // Il prodotto con lo stesso nome è già presente
                        // Incrementa il contatore della quantità
                        int quantita = int.Parse(parti[2]) + 1;

                        // Aggiorna la riga con la nuova quantità
                        righeEsistenti[i] = $"{NOMEPRODOTTO.Text};{PREZZO.Text};{quantita};0;";
                        array1[i] = quantita;

                        // Imposta la booleana a true per indicare che il prodotto esiste
                        prodottoEsistente = true;

                        // Esci dal ciclo, poiché abbiamo trovato il prodotto
                        break;
                    }
                }

                // Se il prodotto è già presente, aggiorna il file con le nuove informazioni
                if (prodottoEsistente)
                {
                    File.WriteAllLines("File.txt", righeEsistenti);
                }
                else
                {
                    // Se il prodotto non esiste, aggiungi una nuova riga al file
                    // Apri un FileStream in modalità Append per scrivere su "File.txt"
                    using (var file = new FileStream("File.txt", FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        // Aggiungi una nuova riga per il prodotto
                        sw.WriteLine($"{NOMEPRODOTTO.Text};{PREZZO.Text};1;0;".PadRight(record - 4) + "##");
                    }
                }
            }
        }



        //bottone modifica
        private void modifica_Click(object sender, EventArgs e)
        {
            int indice = ricercaindice(nomexmodifica.Text);
            if (nomexmodifica.Text == string.Empty || nomemodificato.Text == string.Empty || prezzomodificato.Text == string.Empty)
            {
                MessageBox.Show("Inserisci le modifiche ");
            }
            else if (indice == -1)
            {
                MessageBox.Show("L'elemento da modificare non è stato trovato.");
            }
            else if (float.TryParse(prezzomodificato.Text, out _) == false)
            {
                MessageBox.Show("Inserisci un elemento numerico per il prezzo");
            }
            else
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
        }


        private void button3_Click(object sender, EventArgs e)
        {

            // trova il percorso del file
            string percorsoFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "File.txt");
            // apre il file
            Process.Start(percorsoFile);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var file = new FileStream("File.txt", FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(string.Empty);
            sw.Close();


        }

        //cancellazione fisica
        private void button2_Click(object sender, EventArgs e)
        {
            int x = ricercaindice(textBox2.Text);
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Inserisci un elemento da cancellare");
            }
            else if (x == -1)
            {
                MessageBox.Show("L'elemento non è stato trovato");
            }
            else
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

        }        //cancellazione logica
        private void cancella_Click(object sender, EventArgs e)
        {
            int x = ricercaindice(textBox1.Text);
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Inserisci un elemento da cancellare");
            }
            else if (x == -1)
            {
                MessageBox.Show("L'elemento non è stato trovato");
            }
            else
            {
                string[] prodotto = ricercaprod(textBox1.Text);
                string linea;
                var file = new FileStream("File.txt", FileMode.Open, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(file);
                file.Seek(record * x, SeekOrigin.Begin);
                linea = $"{prodotto[0]};{prodotto[1]};{array1[record*x]};1;".PadRight(record - 4) + "##";
                byte[] bytes = Encoding.UTF8.GetBytes(linea);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                file.Close();
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


        private void button4_Click(object sender, EventArgs e)
        {
            if (ricercaindicedarecu(textBox3.Text) == -1)
            {
                MessageBox.Show("Il prodotto non è stato trovato, assicurati che sia presente all'interno del file");
            }
            else
            {
                int indice = (ricercaindicedarecu(textBox3.Text));
                string[] prodotto = ricercaproddarecu(textBox3.Text);
                string line;
                var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(file);
                file.Seek(record * indice, SeekOrigin.Begin);
                line = $"{prodotto[0]};{prodotto[1]};{array1[record * indice]};0;".PadRight(record - 4) + "##";
                byte[] bytes = Encoding.UTF8.GetBytes(line);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                file.Close();
            }
        }


        public string[] ricercaproddarecu(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText("File.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "1" && dati[0] == nome)
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }
        public int ricercaindicedarecu(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText("File.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "1" && dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
            }
            return -1;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }


