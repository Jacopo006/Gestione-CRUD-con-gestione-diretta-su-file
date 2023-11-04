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
        private void Aggiungi_Click(object sender, EventArgs e)
        {
            var file = new FileStream("File.dat", FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine($"{NOMEPRODOTTO.Text};{PREZZO.Text};1;0;".PadRight(record - 4) + "##");
            sw.Close();
        }

        private void NOMEPRODOTTO_TextChanged(object sender, EventArgs e)
        {

        }

        private void PREZZO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
