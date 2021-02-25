using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace PasswordManager
{
    public class ConnectionKey : SecretKey
    {
        // pssibly unnecessary
        private const string usageText = "Usage: RFC2898 <password>\nYou must specify the password. \n";

        public void ConnectsKeyAndPsw()
        {
            // get the password using JSON from file.
            string psw1 = "";
            byte[] salt1 = sKeyGenerator();
            string data1 = "test data"; 

            int myIterations = 1000;

            try
            {
                Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(psw1, salt1, myIterations);
                Rfc2898DeriveBytes k2 = new Rfc2898DeriveBytes(psw1, salt1);

                // Possibly add the AES result
            }

            catch 
            {
                Console.WriteLine("Could not connect secret key and the masterpassword.");
            }
        }
    }
}
