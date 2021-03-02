using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace PasswordManager
{
    public class ConnectionKey : SecretKey
    {
        // possibly unnecessary
        private const string usageText = "Usage: RFC2898 <password>\nYou must specify the password. \n";
        Rfc2898DeriveBytes k1;

        public Rfc2898DeriveBytes ConnectsKeyAndPsw(string psw1)
        {
            // get the password using JSON from file.
            byte[] salt1 = SKeyGenerator();
          
            try
            {
                Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(psw1, salt1);   
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
            return k1;
        }

      
    }
}
