using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenhausManagement
{
    public class User
    {
        private string _Username;
        private string _Password;
        private string _Role;

        public string GetUsername()
        {
            return _Username;
        }
        public void SetUsername(string Username)
        {
            _Username = Username;
        }
        public string GetPassword()
        {
            return _Password;
        }
        public void SetPassword( string Password)
        {
            _Password = Password;
        }
        public string GetRolle()
        {
            return _Role;
        }
        public void SetRolle(string Rolle)
        {
            _Role = Rolle;
        }
    }
}
