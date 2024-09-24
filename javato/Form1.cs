using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
///// 
namespace javato
{
    public partial class Form1 : Form
    {
        string[] series = new string[] { "A", "C","D" };
        string[] prov = new string[] { "Antananarivo", "Fianarantsoa", "Toliara", "Toamasina", "Majunga", "Diego Suarez" };
        string notStr = "/*-+.0123456789><²&é\"'(-è_çà)=$^^*ù!:;,~#{[|`\\^@]}¤£¨µ%§/.?°";
        string notInt = "/*-+.azertyuiopqsdfghjklmwxcvbnAZERTYUIOPQSDFGHJKLMWXCVBN><²&é\"'(-è_çà)=$^^*ù!:;,~#{[|`\\^@]}¤£¨µ%§/.?°";
        DataBase DB = new DataBase();
        DateTime daty = DateTime.Now;
        int xxxxxxx = 1;
        public Form1()
        {
            InitializeComponent();
            //Controle Champs
            Annee.Text = daty.Year.ToString();
            Age.Text = 18.ToString();
            Moyenne.Text = "10";
            choixProv.Items.AddRange(prov);
            choixProv.SelectedIndex = 0;
            choixSerie.Items.Add("A");
            choixSerie.Items.Add("C");
            choixSerie.Items.Add("D");
            choixSerie.SelectedIndex = 0;
            sc.Items.Add("A");
            sc.Items.Add("C");
            sc.Items.Add("D");
            sc.SelectedIndex = 0;
            CentreChoix.Items.Clear();
            CentreChoix.Items.AddRange(prov.ToArray());
            CentreChoix.SelectedIndex = 0;
            controlChamp();
            provName.Text = prov[xxxxxxx];
            nbrPT.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}'").Count.ToString();
            nbrPA.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}' and moyenne>9").Count.ToString();
            NbrPNA.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}' and moyenne<10").Count.ToString();
            //
            List<Panel> list = new List<Panel>() { panelAcc, panelGere, panelStatic, panelClasser };
            List<Panel> list2 = new List<Panel>() { panel3, panel4, panel8, panel5 };
            foreach(Panel p in list2)
            {
                p.BackColor = Color.FromArgb(40, 40, 40);
                label13.BackColor = Color.FromArgb(40, 40, 40);
                button1.BackColor = Color.FromArgb(40, 40, 40);
                button2.BackColor = Color.FromArgb(40, 40, 40);
                button3.BackColor = Color.FromArgb(40, 40, 40);
                button4.BackColor = Color.FromArgb(40, 40, 40);
                
            }
            List<Label> labels = new List<Label>() { accText, GererText, StatText, ClassText};
            panel1.BackColor = Color.FromArgb(40, 40, 40);
            panel2.BackColor = Color.FromArgb(40, 40, 40);
            foreach(Label label in labels)
            {
                label.BackColor = Color.FromArgb(40, 40, 40);
                label.MouseEnter += (sender, e) =>
                {
                    Console.WriteLine(label.BackColor);
                    label.BackColor = Color.FromArgb(63,63,63);
                };
                label.MouseLeave += (sender, e) =>
                {
                    label.BackColor = Color.FromArgb(40, 40, 40);
                    label.ForeColor = Color.FromArgb(255, 255, 255);
                };
            }
            /////////
            ///
            updateALl();
            HideAll();
            panelAcc.Show();
        }
        /// ///////////////////////////////////////////////////////////////////
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideAll()
        {
            List<Panel> list = new List<Panel>() { panelAcc, panelGere, panelStatic, panelClasser};
            foreach(Panel p in list)
            {
                p.Hide();
            }
            miseEnplace();
            
        }
        /// <summary>
        /// /////////////////////////////////////////////////////
        /// </summary>
        private void updateALl()
        {
            initialisationTableRow();
            choixStat.Items.Clear();
            foreach(int i  in DB.daty())
            {
                choixStat.Items.Add(i.ToString());
            }
            choixStat.SelectedIndex = 0;
            choixAnnee.Items.Clear();
            foreach(int i in DB.daty())
            {
                choixAnnee.Items.Add(i.ToString());
                choixAnnee.SelectedIndex = 0;
            }
            provName.Text = prov[xxxxxxx];
            nbrPT.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}'").Count.ToString();
            nbrPA.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}' and moyenne>9").Count.ToString();
            NbrPNA.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}' and moyenne<10").Count.ToString();
            //////////////////////////
            LiveCharts.SeriesCollection serieAges = new SeriesCollection();
            for (int i = 0; i < 5; i++)
            {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = prov[i];
                pieSeries.Values = new ChartValues<double> { DB.voirEleve($" WHERE Centre = '{prov[i]}'").Count };
                pieSeries.DataLabels = true;
                serieAges.Add(pieSeries);
            }
            piePro.Series = serieAges;
            piePro.LegendLocation = LegendLocation.Bottom;
            ///////////////////////////
            LiveCharts.SeriesCollection xxx = new SeriesCollection();
            foreach(int i in DB.daty())
            {
                PieSeries pieSeries = new PieSeries();
                pieSeries.Title = i.ToString();
                int hhhhh;
                Int32.TryParse(choixStat.Text, out hhhhh);
                pieSeries.Values = new ChartValues<double> { DB.voirEleve($" WHERE Annee = {hhhhh}").Count };
                pieSeries.DataLabels = true;
                xxx.Add(pieSeries);
            }
            chertSerie.Series = xxx;
            ///////////////////////////

            foreach (Eleve e in DB.voirEleve(""))
            {
                tableRow1.Rows.Add(e.num, e.nom, e.prenom, e.age, e.moyenne, e.centre, e.annee, e.serie);
            }
            nbrA.Text = DB.voirEleve(" WHERE moyenne>9").Count.ToString();
            NbrT.Text = DB.voirEleve("").Count.ToString();
            nbrNA.Text = DB.voirEleve(" WHERE moyenne<10").Count.ToString();
            /////////////////////////// Evoooo
            evolution.Series.Clear();
            LiveCharts.SeriesCollection seriesEvolution = new LiveCharts.SeriesCollection();
            LineSeries a = new LineSeries();
            a.Title = "Admis";
            a.Values = new ChartValues<ObservablePoint>();
            LineSeries aa = new LineSeries();
            aa.Title = "Non Admis";
            aa.Values = new ChartValues<ObservablePoint>();
            foreach (int i in DB.daty())
            {
                //2024 2025
                ObservablePoint kkk = new ObservablePoint(DB.daty().IndexOf(i), DB.voirEleve($" WHERE moyenne>9 and Annee = {i}").Count);
                a.Values.Add(kkk);
            }
            foreach (int i in DB.daty())
            {
                //2024 2025
                ObservablePoint kkk = new ObservablePoint(DB.daty().IndexOf(i), DB.voirEleve($" WHERE moyenne<9 and Annee = {i}").Count);
                aa.Values.Add(kkk);
            }
            seriesEvolution.Add(a);
            seriesEvolution.Add(aa);

            evolution.Series = seriesEvolution;
            /////////// Barrraaaa
            ///new ColumnSeries
            LiveCharts.SeriesCollection provSerie = new LiveCharts.SeriesCollection();
            ColumnSeries ddd = new ColumnSeries();
            ColumnSeries ddd1 = new ColumnSeries();
            ddd.Title = "Admis";
            ddd1.Title = "Admis";
            ddd.Values = new ChartValues<int>();
            ddd1.Values = new ChartValues<int>();
            for(int i = 0; i < 6; i++)
            {
                ddd.Values.Add(DB.voirEleve($" Where moyenne>9 and Centre = '{prov[i]}'").Count);
                ddd1.Values.Add(DB.voirEleve($" Where moyenne<10 and Centre = '{prov[i]}'").Count);
            }
            provSerie.Add(ddd);
            provSerie.Add(ddd1);
            PROVcHART.Series = provSerie;


        }
        ////////////////////////////////////////////////

        private void miseEnplace()
        {
            List<Panel> list = new List<Panel>() { panelAcc, panelGere, panelStatic, panelClasser };
            foreach(Panel p in list)
            {
                //249; 46
                // size 1247; 763
                Point pts = new Point(249, 46);
                Size ss = new Size(1247, 763);
                p.Location = pts;
                p.Size = ss;
            }
        }

        private void accText_Click(object sender, EventArgs e)
        {
            HideAll();
            panelAcc.Show();
        }

        private void GererText_Click(object sender, EventArgs e)
        {
            HideAll();
            panelGere.Show();
        }

        private void ClassText_Click(object sender, EventArgs e)
        {
            HideAll();
            panelClasser.Show();
        }

        private void StatText_Click(object sender, EventArgs e)
        {
            HideAll();
            panelStatic.Show();
        }
        private void initialisationTableRow()
        {
            tableRow1.Columns.Clear();
            tableRow1.Rows.Clear();
            tableRow1.Columns.Add("0", "Numero");
            tableRow1.Columns.Add("1", "Nom");
            tableRow1.Columns.Add("2", "Prenom");
            tableRow1.Columns.Add("3", "Age");
            tableRow1.Columns.Add("4", "Moyenne");
            tableRow1.Columns.Add("5", "Centre");
            tableRow1.Columns.Add("6", "Annee");
            tableRow1.Columns.Add("7", "Serie");
            tableRow1.Columns[0].Width = 100;
            tableRow1.Columns[1].Width = 350;
            tableRow1.Columns[2].Width = 250;
            tableRow1.Columns[3].Width = 100;
            tableRow1.Columns[4].Width = 100;
            tableRow1.Columns[5].Width = 250;
            tableRow1.Columns[6].Width = 100;
            tableRow1.Columns[7].Width = 100;

            tableRow2.Columns.Clear();
            tableRow2.Rows.Clear();
            tableRow2.Columns.Add("0", "Numero");
            tableRow2.Columns.Add("1", "Nom");
            tableRow2.Columns.Add("2", "Prenom");
            tableRow2.Columns.Add("3", "Age");
            tableRow2.Columns.Add("4", "Moyenne");
            tableRow2.Columns.Add("5", "Centre");
            tableRow2.Columns.Add("6", "Annee");
            tableRow2.Columns.Add("7", "Serie");
            tableRow2.Columns[0].Width = 100;
            tableRow2.Columns[1].Width = 350;
            tableRow2.Columns[2].Width = 250;
            tableRow2.Columns[3].Width = 100;
            tableRow2.Columns[4].Width = 100;
            tableRow2.Columns[5].Width = 250;
            tableRow2.Columns[6].Width = 100;
            tableRow2.Columns[7].Width = 100;
        }

        private void controlChamp()
        {
            List<TextBox> listChampInt = new List<TextBox>() {Moyenne, Age, Annee};
            List<TextBox> listChampStr = new List<TextBox> {Nom, Prenom};
            //NombreOnly
            foreach (TextBox champ in listChampInt)
            {
                champ.KeyUp += (sender, e) =>
                {
                    foreach (char text in notInt)
                    {
                        if (champ.Text.Contains(text))
                        {
                            champ.Text = champ.Text.Replace(text.ToString(), "");
                        }
                    }
                    champ.Text = champ.Text.ToUpper();
                    champ.SelectionStart = 9999;

                };
            }
            foreach (TextBox champ in listChampStr)
            {
                champ.KeyUp += (sender, e) =>
                {
                    foreach (char text in notStr)
                    {
                        if (champ.Text.Contains(text))
                        {
                            champ.Text = champ.Text.Replace(text.ToString(), "");
                        }
                    }
                    champ.Text = champ.Text.ToUpper();
                    champ.SelectionStart = 9999;
                };
            }
        }
        //CheckBox AM Ajouter  
        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> listChampStr = new List<TextBox>() { Nom, Prenom, Age, Annee, Moyenne};
            bool verification = false;
            foreach(TextBox champ in listChampStr)
            {
                if (String.IsNullOrEmpty(champ.Text))
                {
                    verification = false;
                    break;
                }
                else { verification = true; }
            }

            int dateTest;
            Int32.TryParse(Annee.Text, out dateTest);
            if (dateTest > daty.Year)
            {
                MessageBox.Show("Verifier la date");
                verification = false;
            }

            if (verification)
            {
                
                string nom = Nom.Text;
                string prenom = Prenom.Text;
                int age;
                Int32.TryParse(Age.Text, out age);
                int moyenne;
                int annee;
                Int32.TryParse(Moyenne.Text, out moyenne);
                Int32.TryParse(Annee.Text, out annee);
                string centre = CentreChoix.Text;
                DB.AjouterEleve(nom, prenom, age, moyenne, annee, centre, sc.Text);
                MessageBox.Show("Element Ajouter Avec Succes");
                updateALl();
                Nom.Text = "";
                Prenom.Text = "";
            }
            else { MessageBox.Show("Veuiller respecter les Champs d entreeee"); }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            initialisationTableRow();
            foreach(Eleve eleve in DB.voirEleve($" WHERE Nom LIKE '%{search.Text}%' OR Prenom LIKE '%{search.Text}%'"))
            {
                tableRow1.Rows.Add(eleve.num, eleve.nom, eleve.prenom, eleve.age, eleve.moyenne, eleve.centre, eleve.annee, eleve.serie);
            }
            
        }/// <summary>
        /// modifififififi

        private void button2_Click(object sender, EventArgs e)
        {

            
            if (tableRow1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = tableRow1.SelectedRows[0];
                string valeur = selectedRow.Cells[0].Value.ToString();
                int nnnnnnnnnn;
                Int32.TryParse(valeur, out nnnnnnnnnn);
                List<TextBox> listChampStr = new List<TextBox>() { Nom, Prenom, Age, Annee, Moyenne };
                bool verification = false;
                foreach (TextBox champ in listChampStr)
                {
                    if (String.IsNullOrEmpty(champ.Text))
                    {
                        verification = false;
                        break;
                    }
                    else { verification = true; }
                }

                int dateTest;
                Int32.TryParse(Annee.Text, out dateTest);
                if (dateTest > daty.Year)
                {
                    MessageBox.Show("Verifier la date");
                    verification = false;
                }

                if (verification)
                {

                    string nom = Nom.Text;
                    string prenom = Prenom.Text;
                    int age;
                    Int32.TryParse(Age.Text, out age);
                    int moyenne;
                    int annee;
                    Int32.TryParse(Moyenne.Text, out moyenne);
                    Int32.TryParse(Annee.Text, out annee);
                    string centre = CentreChoix.Text;
                    DB.ModifierEleve(nnnnnnnnnn, nom, prenom, age, moyenne, annee, centre, sc.Text);
                    MessageBox.Show("Element Modifier Avec Succes");
                    updateALl();
                    Nom.Text = "";
                    Prenom.Text = "";
                }
                else { MessageBox.Show("Veuiller respecter les Champs d entreeee"); }

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tableRow1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = tableRow1.SelectedRows[0];
                string valeur = selectedRow.Cells[0].Value.ToString();
                int nnnnnnnnnnnnn;
                Int32.TryParse(valeur, out nnnnnnnnnnnnn);
                DB.SupprimerEleve(nnnnnnnnnnnnn);
                MessageBox.Show("Elements supprimer avec succes");
                updateALl();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            initialisationTableRow();
           foreach (Eleve eleve in DB.voirEleve($" WHERE serie = '{choixSerie.Text}' AND centre = '{choixProv.Text}' AND annee = {choixAnnee.Text}"))
            {
                tableRow2.Rows.Add(eleve.num, eleve.nom, eleve.prenom, eleve.age, eleve.moyenne, eleve.centre, eleve.annee, eleve.serie);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //{ "Antananarivo", "Fianarantsoa", "Toliara", "Toamasina", "Majunga", "Diego Suarez" };
            provName.Text = prov[xxxxxxx];
            nbrPT.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}'").Count.ToString();
            nbrPA.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}' and moyenne>9").Count.ToString();
            NbrPNA.Text = DB.voirEleve($" WHERE Centre = '{prov[xxxxxxx]}' and moyenne<10").Count.ToString();
            xxxxxxx++;
            if (xxxxxxx == 6)
            {
                xxxxxxx = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            updateALl();
        }
        // Provvvvvvvvvvv
    }
}
