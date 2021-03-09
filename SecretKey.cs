using System.Security.Cryptography;
using System.IO;
using System.Text.Json;
using System;

namespace Code_off
{
    public class SecretKey 
    {
        public SecretKey()
        {

        }
        public static byte[] SKeyGenerator()
        {
            byte[] sKey = new byte[16];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(sKey);

                return sKey;
            }
        }

        public static string DisplaySecretKey(string clientPath)
        {
            //string jsonString2 = File.ReadAllText(@clientPath);
            ////Convert.ToBase64String används nämligen i 
            //return jsonString2;

            string jsonString2 = File.ReadAllText(@clientPath);
            ClientFileConnect readResult = JsonSerializer.Deserialize<ClientFileConnect>(jsonString2);
            string svar = Convert.ToBase64String(readResult.secretKey);
            return svar;
        }
    }
}