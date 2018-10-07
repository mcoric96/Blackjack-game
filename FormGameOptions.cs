using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Blackjack;

namespace OTTER
{
    public partial class FormGameOptions : Form
    {
        public FormGameOptions()
        {
            InitializeComponent();
            BrojSpilova = 0;
        }

        public int BrojSpilova;//varijabla u koju zabiljezimo s koliko igramo spilova
        public int Novac;//pamtimo novac koji imamo na pocetku

        private void FormGameOptions_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxBrojSpilova_SelectedIndexChanged(object sender, EventArgs e) //za odabiranje broj spilova
        {
            if (comboBoxBrojSpilova.SelectedIndex < 0)//ako nista nije odabrano
            { BrojSpilova = 0; }
            else  BrojSpilova = int.Parse(comboBoxBrojSpilova.SelectedItem.ToString());
        }

        private void textBoxNovac_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxNovac.Text, out Novac))//ako je upisani iznos dobar,tj ima int vrijednost
            {
                if (Novac <= 0 || Novac > 100000)//ako novac nije u zadanom intervalu
                {
                    Novac = 0;
                }
            }
            else Novac = 0; //inace ako upisni iznos nije dobar,ispod 0 ili nije int
        }

        private void btnIgraj_Click(object sender, EventArgs e)//kad zelimo igrati
        {
            if (BrojSpilova > 0 && Novac > 0) //ovi uvjeti su dobri,jer ako unos nije dobar postavi se vrjednost na 0
            {
                BlackjackGame.PocetniNovac = Novac;
                BlackjackGame.BrojSpilova = BrojSpilova;
                BlackjackGame.ActiveGame = true;
                Close();
            }
            else
            {
                MessageBox.Show("Odabrati broj spilova.\nNovac mora biti u intervalu [0,100 000]","Greska",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
