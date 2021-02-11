﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WarenhausManagement
{
    public static class Datenbankanbindung
    {
        private static string ServerIP = ConfigurationManager.AppSettings["db"];
        

        private static string convertDate(DateTime date)
        {
            return date.Year.ToString() + date.Month.ToString() + date.Day.ToString();
        }
        //MOIN
        public static List<List<string>> EinbuchenMethode(string _Username, string _Passwort, int WareID)
        {
            List<string> beschreibung = new List<string>();
            List<string> speicherbedarf = new List<string>();
            List<string> preis = new List<string>();

            List<List<string>> result = new List<List<string>>();
            SqlConnection NewConnection = new SqlConnection("Server =  " + ServerIP + "; Database = WHM; User id=sa; Password=Ers1234Ers1234;");
            try
            {

                NewConnection.Open();
                SqlCommand NewCommand = new SqlCommand("select * from f_einbuchen("+WareID+")", NewConnection);
                SqlDataReader Reader = NewCommand.ExecuteReader();

                while(Reader.Read())
                {
                    beschreibung.Add(Reader.GetValue(0).ToString());
                    speicherbedarf.Add(Reader.GetValue(1).ToString());
                    preis.Add(Reader.GetValue(2).ToString());
                }
                NewConnection.Close();

                result.Add(beschreibung);
                result.Add(speicherbedarf);
                result.Add(preis);

                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                NewConnection.Close();
            }

            return null;
        }


        public static bool EinbuchenProzedur(string _Username, string _Passwort, int WareID, int LagerplatzID)

        {
            SqlConnection NewConnection = new SqlConnection("Server = " + ServerIP + "; Database = WHM; User id=sa; Password=Ers1234Ers1234;");
            SqlCommand NewCommand = new SqlCommand("exec p_insert_lagerprozess " + WareID + ", " + LagerplatzID + ";", NewConnection);
            try
            {

                NewCommand.Connection.Open();
                NewCommand.ExecuteNonQuery();
                NewCommand.Connection.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                NewConnection.Close();


                NewCommand.Connection.Close();
                return false; 

            }
        }

        public static bool AusbuchenProzedur(string _Username, string _Passwort, int WareID, int LagerplatzID)

        {

            SqlConnection NewConnection = new SqlConnection("Server = " + ServerIP + "; Database = WHM; User Id = " + _Username + "; Password = " + _Passwort);
            SqlCommand NewCommand = new SqlCommand("exec dbo.Ausbuchen(" + WareID + ", " + LagerplatzID + ");", NewConnection);
            try
            {

                NewCommand.Connection.Open();
                NewCommand.ExecuteNonQuery();
                NewCommand.Connection.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                NewConnection.Close();


                NewCommand.Connection.Close();
                return false;

            }
        }
        public static bool NauerArtikel(string _Username, string _Passwort,string Warename, float Preis, int Warengröße)

        {
            string preisString = Preis.ToString();
            preisString = preisString.Replace(',', '.');
            
            
            SqlConnection NewConnection = new SqlConnection("Server = " + ServerIP + "; Database = WHM; User id=sa; Password=Ers1234Ers1234;");
            SqlCommand NewCommand = new SqlCommand("exec dbo.NeuerArtikel'" + Warename + "', '"+preisString+"', "+Warengröße+";", NewConnection);
            try
            {

                NewCommand.Connection.Open();
                NewCommand.ExecuteNonQuery();
                NewCommand.Connection.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                NewConnection.Close();


                NewCommand.Connection.Close();
                return false;

            }
        }
        public static int WareID(string _Username, string _Passwort, string Warename)

        {

            SqlConnection NewConnection = new SqlConnection("Server = " + ServerIP + "; Database = WHM; User id=sa; Password=Ers1234Ers1234;");
            SqlCommand NewCommand = new SqlCommand("select dbo.WareID ('" + Warename + "')", NewConnection);
            try
            {

                NewCommand.Connection.Open();
                SqlDataReader Reader = NewCommand.ExecuteReader();
                int WareID = 0;
                while (Reader.Read())
                {
                    WareID = Reader.GetInt32(0);
                }
                NewConnection.Close();

                return WareID;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);

                NewConnection.Close();


                NewCommand.Connection.Close();
                return -1;

            }
        }

        public static int Get_Regale(string _Username, string _Passwort)
        {
            int value = 0;

            SqlConnection connect = new SqlConnection("Server = " + ServerIP + "; Database = WHM; User id=sa; Password=Ers1234Ers1234;");
            SqlCommand com = new SqlCommand("select max(Regal) from Lagerplatz;", connect);

            com.Connection.Open();
            SqlDataReader reader = com.ExecuteReader();

            reader.Read();
            value = reader.GetInt32(0);
            reader.Close();
            return value;
        }

        public static int Get_Auslastung(string _Username, string _Passwort, DateTime startDate, DateTime endDate, string regal)
        {
            int auslastung = 0;
            SqlConnection connect = new SqlConnection("Server =  " + ServerIP + "; Database = WHM; User id=sa; Password=Ers1234Ers1234;");
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
                    reader.Close();
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

            SqlConnection connect = new SqlConnection("Server =  " + ServerIP + "; Database = WHM; User id=sa; Password=Ers1234Ers1234;");
            SqlCommand com = new SqlCommand("select * from dbo.f_get_menge_ware('" + convertDate(startDate) + "', '" + convertDate(endDate) + "' );", connect);
            com.Connection.Open();
            SqlDataReader reader = com.ExecuteReader();

            while(reader.Read())
            {
                mengen.Add(reader.GetValue(0).ToString());
                waren.Add(reader.GetValue(1).ToString());
            }

            rn_values.Add(waren);
            rn_values.Add(mengen);
            com.Connection.Close();
            return rn_values;



        }
    }
}
