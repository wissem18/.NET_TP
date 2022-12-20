using System.Collections.Generic;
using System.Data.SQLite;

namespace TP2.Models
{
    public class Personal_info
    {
       private SQLiteConnection sqlite = new SQLiteConnection("Data Source=BD\\2022 GL3 .NET Framework TP3 - SQLite database.db");
       public List<Person> getAllPersons()
        {
            List<Person> persons = new List<Person>();
            try
            {
                sqlite.Open();
            }
            catch (Exception ex)
            {
                sqlite.Close();
            }

            using (sqlite)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", sqlite);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        persons.Add(new Person(id, first_name, last_name, email, image, country));
                    }
                }
            }
            return persons;
        }
        public Person getPerson(int id)
        {
            try
            {
                sqlite.Open();
            }
            catch (Exception ex)
            {
                sqlite.Close();
            }
            Person p = null;

            using (sqlite)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info WHERE id="+id+"", sqlite);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    
                    while (reader.Read())
                    {
                        int i= (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                       p=new Person(id, first_name, last_name, email, image, country);
                    }
                }
            }
            return p;
        }
    }
}
