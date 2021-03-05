using System;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Code_off
{
    public class FileConnectServer : FileConnector
    {

        public static void DisplayVault(string inputPsw)
        {
            foreach (KeyValuePair<string, string> kvp in ConvertByteToDic(inputPsw))
            {
                Console.WriteLine("Service = {0}, Password = {1}", kvp.Key, kvp.Value);
            }
        }

        public static void CreateAccount()
        {
            byte[] openIv;
            WriteToFile();

            using (Aes myAes = Aes.Create())
            {
                openIv = myAes.IV;
            }

            ServerFile serverObj1 = new ServerFile()
            {
                vault = null,
                IV = openIv 
            };

            string jsonString1 = JsonSerializer.Serialize(serverObj1);
            File.WriteAllText(@"ServerInfo2.json", jsonString1);
        }

        public static void WriteToServer(string inputPsw, string txt, string value) 
        {
            byte[] openIv;
            byte[] svar4;
           
            using (Aes myAes = Aes.Create())
            {
                
                byte[] secretKey = ConnectsKeyAndPsw(inputPsw);
                openIv = ReadFromServerIv();
                string jsonString3 = JsonSerializer.Serialize(Vault.AddToVault(txt, value, ConvertByteToDic(inputPsw)));
                svar4 = EncryptStringToBytes_Aes(jsonString3, secretKey, openIv);
                
            }

            ServerFile serverObj = new ServerFile()
            {
                vault = svar4, 
                IV = openIv 
            };

            string jsonString1 = JsonSerializer.Serialize(serverObj);
            File.WriteAllText(@"ServerInfo2.json", jsonString1);
        }

        public static byte[] ReadFromServerIv()
        {
            string jsonString = File.ReadAllText(@"ServerInfo2.json");
            ServerFile readResult = JsonSerializer.Deserialize<ServerFile>(jsonString);

            return readResult.IV;
        }

        public static byte[] ReadFromServerVault()
        {
            string jsonString = File.ReadAllText(@"ServerInfo2.json");
            ServerFile readResult = JsonSerializer.Deserialize<ServerFile>(jsonString);

            return readResult.vault;
        }
        public static Dictionary<string,string> ConvertByteToDic(string inputPsw)
        {
            string svar = AES.DecryptStringFromBytes_Aes(ReadFromServerVault(), ConnectsKeyAndPsw(inputPsw), ReadFromServerIv()); //hej ska vara samma console.readline som rad 17 representerar
            Dictionary<string, string> readResult = JsonSerializer.Deserialize<Dictionary<string, string>>(svar);
            return readResult;
        }

        public static void UpdateVault(string inputPsw, Dictionary<string, string> x)
        {
            byte[] openIv = ReadFromServerIv();
            byte[] encryptedDic;
            using (Aes myAes = Aes.Create())
            {
                byte[] secretKey = ConnectsKeyAndPsw(inputPsw);
                string jsonString3 = JsonSerializer.Serialize(x);
                encryptedDic = EncryptStringToBytes_Aes(jsonString3, secretKey, openIv);
            }

            ServerFile serverObj = new ServerFile()
            {
                vault = encryptedDic,
                IV = openIv
            };
            string jsonString1 = JsonSerializer.Serialize(serverObj);
            File.WriteAllText(@"ServerInfo2.json", jsonString1);
        }
    }
}
