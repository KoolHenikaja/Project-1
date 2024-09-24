using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Kamo be de nataoko public abyyyy

namespace javato
{
    internal class Eleve
    {
        public int num;
        public string nom;
        public string prenom;
        public int moyenne;
        public string centre;
        public int age;
        public int annee;
        public string serie;
        public Eleve(int num, string nom, string prenom, int moyenne, string centre, int age, int annee, string serie)
        {
            this.num = num;
            this.nom = nom;
            this.prenom = prenom;
            this.moyenne = moyenne;
            this.age = age;
            this.centre = centre;
            this.annee = annee;
            this.serie = serie;
        }
    }
}
