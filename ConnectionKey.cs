using System;
using System.Security.Cryptography;


namespace Code_off
{
    public class ConnectionKey : SecretKey
    {   
        public static byte[] k1;
        public static byte[] ConnectsKeyAndPsw(string psw1, string clientPath, string secretKey)
        {
            byte[] salt1;

            if(secretKey == "")
            {
                salt1 = ClientFileConnect.ReadFromFile(clientPath);
            }
            else
            {
                string tempsalt = secretKey;
                salt1 = Convert.FromBase64String(tempsalt);
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