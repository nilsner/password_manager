using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Code_off
{
    public class ConnectionKey : SecretKey
    {
        // pssibly unnecessary
        private const string usageText = "Usage: RFC2898 <password>\nYou must specify the password. \n";
        public static byte[] k1;


        public static byte[] ConnectsKeyAndPsw(string psw1)
        {

            byte[] salt1 = FileConnector.ReadFromFile();
            //FileConnector.OverwriteClientPass(salt1); //SALT SPARAS NU I CLIENT FILEN
            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(psw1, salt1); //VART FRÖSVINNER SALT1

                k1 = key.GetBytes(16); //nytt
                
                return k1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
            return k1;


        }

        public byte[] RecreateRFC(string psw1)
        {
            byte[] salt1 = FileConnector.ReadFromFile();
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
