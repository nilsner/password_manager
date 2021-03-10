using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace PasswordManager3._0
{
    public class ConnectionKey : SecretKey
    {
        public static byte[] k1;
        public static byte[] ConnectsKeyAndPsw(string psw1, string clientPath, string secretKey)
        {
            byte[] salt1;

            if (secretKey == "")
            {
                salt1 = ClientFileConnect.ReadFromFile(clientPath);
            }
            else
            {
                string tempsalt = secretKey;
                salt1 = Convert.FromBase64String(tempsalt); //KOPIERAR JAG IN NYCKELN MED COPY + PASTE FUNKAR DET MEN INTE OM JAG SKRIVER IN SkEY MANUELLT
            }

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
    }
}
