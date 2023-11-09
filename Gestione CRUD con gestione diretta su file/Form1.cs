﻿using System;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

            // trova il percorso del file
            string percorsoFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "File.txt");
            // apre il file
            Process.Start(percorsoFile);
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

        }


        //cancellazione logica
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
                linea = $"{prodotto[0]};{prodotto[1]};{prodotto[3]};1;".PadRight(record - 4) + "##";
                byte[] bytes = Encoding.UTF8.GetBytes(linea);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                file.Close();
            }
               
        }

        //bottone modifica
        private void modifica_Click(object sender, EventArgs e)
        {
            int indice = ricercaindice(nomexmodifica.Text);
            if (nomexmodifica.Text == string.Empty)
            {
                MessageBox.Show("Inserisci un elemento da modificare");
            }
            else if (indice == -1)
            {
                MessageBox.Show("L'elemento da modificare non è stato trovato.");
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

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (NOMEPRODOTTO.Text == string.Empty || PREZZO.Text == string.Empty)
            {
                MessageBox.Show("Devi inserire il nome del prodotto e il suo prezzo");
            }
            else if (float.TryParse(PREZZO.Text, out _) == false)
            {
                MessageBox.Show("Devi inserire il prezzo in valore numerico");
                PREZZO.Text = string.Empty;
            }
            else
            {
                var file = new FileStream("File.txt", FileMode.Append, FileAccess.Write, FileShare.Read);
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine($"{NOMEPRODOTTO.Text};{PREZZO.Text};1;0;".PadRight(record - 4) + "##");
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



        public string[] ricercaproddarecu(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText("File.dat"))
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
            using (StreamReader sr = File.OpenText("File.dat"))
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Devi prima inserire un prodotto");
            }
            else
            {
                int indice = ricercaindicedarecu(textBox3.Text);
                if (indice == -1)
                {
                    MessageBox.Show("Assicurati che il prodotto esista e che sia cancellato");
                    textBox3.Text = null;
                }
                else
                {
                    string[] prodotto = ricercaproddarecu(textBox3.Text);
                    string line;
                    var file = new FileStream("File.dat", FileMode.Open, FileAccess.Write);
                    BinaryWriter writer = new BinaryWriter(file);
                    file.Seek(record * indice, SeekOrigin.Begin);
                    line = $"{prodotto[0]};{prodotto[1]};1;0;".PadRight(record - 4) + "##";
                    byte[] bytes = Encoding.UTF8.GetBytes(line);


                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                    file.Close();
                    textBox3.Text = null;
                    MessageBox.Show("Prodotto Recuperato Correttamente");
                }
            }
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

        
        }
    }

