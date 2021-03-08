using System;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Code_off
{
    public class ServerFileConnect : ClientFileConnect
    {
        public static bool ControllPass(string inputPsw) //Metod som kollar om användaren har skrivit rätt lösenord. Om så är fallet returneras true.
        {
            Dictionary<string, string> Dic = ConvertByteToDic(inputPsw);
            if (Dic == null)
            {
                Console.WriteLine("Wrong password");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void DisplayVault(string inputPsw)
        {
            Dictionary<string, string> Dic = ConvertByteToDic(inputPsw);
            
            foreach (KeyValuePair<string, string> kvp in Dic)
            {
                Console.WriteLine("Service = {0}, Password = {1}", kvp.Key, kvp.Value);
            }
        }

        public static void CreateAccount(string mpwd)
        {
            byte[] openIv;
            WriteToFile();

            using (Aes myAes = Aes.Create())
            {
                openIv = myAes.IV;
            }

            Dictionary<string, string> Emptydick = new Dictionary<string, string>();
            string jsonString3 = JsonSerializer.Serialize(Emptydick);
            byte[] y = EncryptStringToBytes_Aes(jsonString3, ConnectsKeyAndPsw(mpwd), openIv);

            Server serverObj1 = new Server()
            {
                vault = y,
                IV = openIv 
            };

            string jsonString1 = JsonSerializer.Serialize(serverObj1);
            File.WriteAllText(@"ServerInfo3.json", jsonString1);
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

            Server serverObj = new Server()
            {
                vault = svar4,
                IV = openIv
            };

            string jsonString1 = JsonSerializer.Serialize(serverObj);
            File.WriteAllText(@"ServerInfo3.json", jsonString1);
        }

        public static byte[] ReadFromServerIv()
        {
            string jsonString = File.ReadAllText(@"ServerInfo3.json");
            Server readResult = JsonSerializer.Deserialize<Server>(jsonString);
            return readResult.IV;
        }

        public static byte[] ReadFromServerVault()
        {
            string jsonString = File.ReadAllText(@"ServerInfo3.json");
            Server readResult = JsonSerializer.Deserialize<Server>(jsonString);
            return readResult.vault;
        }

        public static Dictionary<string,string> ConvertByteToDic(string inputPsw)
        {
            string svar = AES.DecryptStringFromBytes_Aes(ReadFromServerVault(), ConnectsKeyAndPsw(inputPsw), ReadFromServerIv()); //hej ska vara samma console.readline som rad 17 representerar
            if (svar == null)
            {
                return null;
            }
            else
            {
                Dictionary<string, string> readResult = JsonSerializer.Deserialize<Dictionary<string, string>>(svar);
                return readResult;
            }
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

            Server serverObj = new Server()
            {
                vault = encryptedDic,
                IV = openIv
            };
            string jsonString1 = JsonSerializer.Serialize(serverObj);
            File.WriteAllText(@"ServerInfo3.json", jsonString1); 
        }
    }
}
