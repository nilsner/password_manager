using System;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;

namespace Code_off
{
    public class FileConnectServer : serverFile
    {
       

        public static void writeToServer(string inputPsw)
        {
            byte[] openIv;
            byte[] openEnc;
            using (Aes myAes = Aes.Create())
            {
                //Slut på RNG försök från Nils
                // Encrypt the string to an array of bytes.

                WriteToFile();
                byte[] secretKey = ReadFromFile();
                openIv = myAes.IV;
                openEnc = EncryptStringToBytes_Aes(inputPsw, secretKey, openIv);
                
            }
            //kör aes och spara ner dess IV här.
            serverFile serverObj = new serverFile()
            {
                vault = openEnc, //encrypt metoden som returnerar byte[] av lösenordet.
                IV = openIv //skapa en IV genom aes?
            };

            string jsonString1 = JsonSerializer.Serialize(serverObj);
            File.WriteAllText(@"serverInfo.json", jsonString1);
        }

        public static byte[] readFromServerIv()
        {
            string jsonString = File.ReadAllText(@"serverInfo.json");
            serverFile readResult = JsonSerializer.Deserialize<serverFile>(jsonString);

            return readResult.IV;
        }

        public static byte[] readFromServerVault()
        {
            string jsonString = File.ReadAllText(@"serverInfo.json");
            serverFile readResult = JsonSerializer.Deserialize<serverFile>(jsonString);

            return readResult.vault;
        }
    }
}
