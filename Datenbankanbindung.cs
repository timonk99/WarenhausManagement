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


        private static string convertDate(DateTime date)
        {
            return date.Year.ToString() + date.Month.ToString() + date.Day.ToString();
        }

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

        public static int Get_Regale(string _Username, string _Passwort)
        {
            int value = 0;

            SqlConnection connect = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            SqlCommand com = new SqlCommand("select max(Regal) from Lagerplatz;", connect);

            com.Connection.Open();
            SqlDataReader reader = com.ExecuteReader();

            reader.Read();
            value = reader.GetInt32(0);
            return value;
        }

        public static int Get_Auslastung(string _Username, string _Passwort, DateTime startDate, DateTime endDate, string regal)
        {
            int auslastung = 0;
            SqlConnection connect = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            SqlCommand com = new SqlCommand();
            com.Connection = connect;
            com.Connection.Open();
            if (regal == "Alle")
            {
                int regalAnzahl = Get_Regale(_Username, _Passwort);
                for(int i = 1; i < regalAnzahl; i++)
                {
                    com.CommandText = ("select dbo.f_get_auslastung( '" + convertDate(startDate) + "', '" + convertDate(endDate) + "', " + i + " );");
                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();
                    auslastung += reader.GetInt32(0);
                }
            }
            else
            {
                com.CommandText = ("select dbo.f_get_auslastung( '" + convertDate(startDate) + "', '" + convertDate(endDate) + "', " + regal + " );");
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                auslastung = reader.GetInt32(0);
            }
            com.Connection.Close();
            return auslastung;
        }

        public static List<List<string>> Get_Warenmenge(string _Username, string _Passwort, DateTime startDate, DateTime endDate)
        {
            List<string> waren = new List<string>();
            List<string> mengen = new List<string>();
            List<List<string>> rn_values = new List<List<string>>();

            SqlConnection connect = new SqlConnection("Server = 172.16.112.25; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            SqlCommand com = new SqlCommand("select * from dbo.f_get_menge_ware('" + convertDate(startDate) + "', '" + convertDate(endDate) + "' );");
            SqlDataReader reader = com.ExecuteReader();

            while(reader.HasRows)
            {
                reader.Read();
                mengen.Add(reader.GetValue(0).ToString());
                waren.Add(reader.GetValue(1).ToString());
            }

            rn_values.Add(waren);
            rn_values.Add(mengen);
            return rn_values;



        }
    }
}
