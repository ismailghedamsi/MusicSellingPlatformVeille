using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class Credential
    {
        public string username;
        public string password;

        public Credential()
        {
 
        }

        public Credential(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
