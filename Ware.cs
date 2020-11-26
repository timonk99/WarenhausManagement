using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenhausManagement
{
    class Ware
    {
        private int _WareID;
        private string _WareBezeichnung;
        private double _Preis;
        private int _Speicherbedarf;

        public int GetWareID()
        {
            return _WareID;
        }
        public void SetWareID(int WareID)
        {
            _WareID = WareID;
        }
        public string GetWareBezeichnung()
        {
            return _WareBezeichnung;
        }
        public void SetWareBezeichnung(string Warebezeichnung)
        {
            _WareBezeichnung = Warebezeichnung;
        }
        public double GetPreis()
        {
            return _Preis;
        }
        public void SetPreis(double Preis)
        {
            _Preis = Preis;
        }
        public int GetSpeicherbedarf()
        {
            return _Speicherbedarf;
        }
        public void SetSpeicherbedarf(int Speicherbedarf)
        {
            _Speicherbedarf = Speicherbedarf;
        }
    }
}
