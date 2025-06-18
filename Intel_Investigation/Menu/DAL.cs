using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Intel_Investigation.Menu
{
    internal class DAL
    {
        // the connection string to the DB
        public string connectionSTR;


        public DAL(string db_name)
        {
            this.connectionSTR = "server=localhost;" +
                                 "user=root;" +
                                 $"database={db_name};" +
                                 "port=3306;";
        }



        // create the columns in the database (initialize)
        public bool CreateColumns()
        {
            string query = "CREATE TABLE `sensors_investigation`.`users_and_ranks` " +
                "(`user_name` VARCHAR(50) NOT NULL DEFAULT 'User' , `highest_level` INT NOT NULL ," +
                " `total_turns` INT NOT NULL , `total_rank` FLOAT NOT NULL , PRIMARY KEY (`user_name`)) ENGINE = InnoDB;";

            using (MySqlConnection conn = new MySqlConnection(this.connectionSTR))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
        }

        // add the user to the database in the end of the game
        public bool AddUser(string username, int highestlevel, int total_turns, float total_rank)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionSTR))
            {
                string query = "INSERT INTO `users_and_ranks` (user_name, highest_level, total_turns, total_rank)" +
                                                    $" VALUES ('{username}', {highestlevel}, {total_turns}, {total_turns});";

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        // check if an username exist already in the database
        public bool IfNameExist(string name)
        {
            using (MySqlConnection conn = new MySqlConnection(this.connectionSTR))
            {
                string query = $"SELECT user_name FROM users_and_ranks WHERE user_name = '{name}';";

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    conn.Close();
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return true;
                }
            }
        }
    }
}
