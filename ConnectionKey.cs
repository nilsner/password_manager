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
        public byte[] k1; // nytt

        public byte[] ConnectsKeyAndPsw(string psw1)
        {
            
            byte[] salt1 = SKeyGenerator();
          
            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(psw1, salt1);

                k1 = key.GetBytes(16); //nytt
                return k1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
             return k1;
            
        }

        
    }
}
