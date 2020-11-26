using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WarenhausManagement
{
    public class Datenbankanbindung
    {



        public static List<string> StatistikWare(string _Username, string _Passwort)
        {
            List<string> result = new List<string>();
            SqlConnection NewConnection = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username +"; Password = " + _Passwort);
            try
            {

                NewConnection.Open();
                SqlCommand NewCommand = new SqlCommand("SELECT * FROM dbo.Ware;", NewConnection);
                SqlDataReader Reader = NewCommand.ExecuteReader();

                while(Reader.HasRows)
                {
                    Reader.Read();
                    for ( int i = 0; i < Reader.FieldCount; i++)
                    {
                        result.Add(Reader.GetValue(i).ToString());
                    }
                }
                NewConnection.Close();
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                NewConnection.Close()
            }

            return null;
        }

        public static List<string> StatistikLagerplatz(string _Username, string _Passwort)
        {
            List<string> result = new List<string>();
            SqlConnection NewConnection = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            try
            {

                NewConnection.Open();
                SqlCommand NewCommand = new SqlCommand("SELECT * FROM dbo.Lagerplatz;", NewConnection);
                SqlDataReader Reader = NewCommand.ExecuteReader();

                while (Reader.HasRows)
                {
                    Reader.Read();
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        result.Add(Reader.GetValue(i).ToString());
                    }
                }
                NewConnection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                NewConnection.Close();
            }
            return null;

        }

        public static List<string> StatistikLagerprozess(string _Username, string _Passwort)
        {
            List<string> result = new List<string>();
            SqlConnection NewConnection = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            try
            {

                NewConnection.Open();
                SqlCommand NewCommand = new SqlCommand("SELECT * FROM dbo.Lagerprozess;", NewConnection);
                SqlDataReader Reader = NewCommand.ExecuteReader();

                while (Reader.HasRows)
                {
                    Reader.Read();
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        result.Add(Reader.GetValue(i).ToString());
                    }
                }
                NewConnection.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                NewConnection.Close();
                return null;
            }
        }
        public static bool Eingabe(string _Username, string _Passwort, string _Tabellenname, string _Spalte, string _Wert)
        {
            SqlConnection NewConnection = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            bool a = true;
            try
            {
                //INSERT INTO tabellen_name (spalte1, spalte2, spalte3, etc.) VALUES ('Wert1', 'Wert2', 'Wert3', etc.)
                NewConnection.Open();
                SqlCommand NewCommand = new SqlCommand("INSERT INTO " + _Tabellenname + " (" + _Spalte + ") VALUES (" + _Wert + ")", NewConnection);
                NewCommand.ExecuteNonQuery();
                NewConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                a = false;
                NewConnection.Close();
            }

            return a;
        }

    }
}
