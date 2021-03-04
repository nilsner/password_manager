using System;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Code_off
{
    public class FileConnectServer : FileConnector
    {
        

        public static void writeToServer(string inputPsw, string txt, string value) 
        {
            byte[] openIv;
            //byte[] openEnc;
            byte[] svar4;
           
            using (Aes myAes = Aes.Create())
            {
               
                WriteToFile();
                byte[] secretKey = ConnectsKeyAndPsw(inputPsw);
                openIv = myAes.IV;
                //openEnc = EncryptStringToBytes_Aes(txt, secretKey, openIv);
                //gogo.Add(txt, value);
                //serialisera och sen kryptera gogo
                string jsonString3 = JsonSerializer.Serialize(Vault.AddToVault(txt, value));
                svar4 = EncryptStringToBytes_Aes(jsonString3, secretKey, openIv);

            }

            serverFile serverObj = new serverFile()
            {
                vault = svar4, 
                IV = openIv //skapa en IV genom aes
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
