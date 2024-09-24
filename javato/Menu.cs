using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetJamdas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Produits Prod = new Produits();
            Prod.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Produits Prod = new Produits();
            Prod.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Produits Prod = new Produits();
            Prod.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Produits Prod = new Produits();
            Prod.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Sortie Vente = new Sortie();
            Vente.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Sortie Vente = new Sortie();
            Vente.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Administrateur Admin = new Administrateur();
            Admin.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Administrateur Admin = new Administrateur();
            Admin.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Statistiques Stat = new Statistiques();
            Stat.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Statistiques Stat = new Statistiques();
            Stat.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login logout = new Login();
            logout.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login logout = new Login();
            logout.Show();
            this.Hide();
        }
    }
}
