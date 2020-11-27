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



        public static List<string> EinbuchenMethode(string _Username, string _Passwort, int WareID)
        {
            List<string> result = new List<string>();
            SqlConnection NewConnection = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username +"; Password = " + _Passwort);
            try
            {

                NewConnection.Open();
                SqlCommand NewCommand = new SqlCommand("select * from f_einbuchen("+WareID+")", NewConnection);
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
                NewConnection.Close();
            }

            return null;
        }
        public static void EinbuchenProzedur(string _Username, string _Passwort, int WareID)
        {
            SqlConnection NewConnection = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            try
            {

                NewConnection.Open();
                SqlCommand NewCommand = new SqlCommand("exec p_insert_lagerprozess("+WareID+");", NewConnection);
                NewConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                NewConnection.Close();
            }
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

    }
}
