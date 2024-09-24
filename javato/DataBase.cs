using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace javato
{
    internal class DataBase
    {
        //Antananarivo Fianarantsoa Toliara Toamasina Majunga Diego Suarez
        private SQLiteConnection connection;
        public DataBase()
        {
            string connectionString = "Data Source=db.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            string createTableQuery = "CREATE TABLE IF NOT EXISTS e (num INTEGER  PRIMARY KEY AUTOINCREMENT, Nom char(120), prenom char(120),Centre TEXT, Age INTEGER, Annee INTEGER, moyenne INTEGER, serie char(5))";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
            createTableCommand.ExecuteNonQuery();
        }

        public List<Eleve> voirEleve(string condition)
        {
            string commandText = "SELECT * from e" + condition;
            List<Eleve> listE = new List<Eleve>();
            using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int num = reader.GetInt32(0);
                        string nom = reader.GetString(1);
                        string prenom = reader.GetString(2);
                        string centre = reader.GetString(3);
                        int age = reader.GetInt32(4);
                        int annee = reader.GetInt32(5);
                        int moyenne = reader.GetInt32(6);
                        string serie = reader.GetString(7);
                        Eleve ee = new Eleve(num, nom, prenom, moyenne, centre, age, annee, serie);
                        listE.Add(ee);
                    }
                }
                return listE;
            }
            ///// CRUDDD

        }

        public void AjouterEleve(string nom, string prenom, int age, int moyenne, int annee, string centre, string serie)
        {
            string insertQuery = $"INSERT INTO e (Nom, prenom, Centre, Age, Annee, moyenne, serie) VALUES ('{nom}', '{prenom}', '{centre}', {age}, {annee}, {moyenne}, '{serie}')";
            using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifierEleve(int num, string nom, string prenom, int age, int moyenne, int annee, string centre, string serie)
        {
            string updateQuery = $"UPDATE e SET Nom = '{nom}', prenom = '{prenom}', Centre = '{centre}', Age ={age}, Annee = {annee}, moyenne = {moyenne}, serie = '{serie}' WHERE num ={num}";
            using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void SupprimerEleve(int num)
        {
            string deleteQuery = $"DELETE FROM e WHERE num = {num}";
            using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public List<int> daty()
        {
            string commandText = "SELECT DISTINCT Annee from e";
            List<int> listE = new List<int>();
            using (SQLiteCommand cmd = new SQLiteCommand(commandText, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int num = reader.GetInt32(0);

                        listE.Add(num);
                    }
                }
                
            }
            return listE;
        }
    }
}
