using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projetJamdas
{
    public partial class Produits : Form
    {
        public Produits()
        {
            InitializeComponent();
        }

        readonly SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samaèl\Documents\CigaretteBD.mdf;Integrated Security=True;Connect Timeout=30");
        private void AjoutProd_click_Click(object sender, EventArgs e)
        {
            if(ProdNomTb.Text == "" || ProdCouleurTb.Text == "" || ProdDateTb.Text == "" || ProdTimeTb.Text == "")
            {
                MessageBox.Show("Information Vide");
            }else
            {
                try
                {

                }catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }
    }
}
