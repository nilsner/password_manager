using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using System.IO;

namespace PasswordManager3._0
{
    public class ServerFileConnect : ClientFileConnect
    {
        public static void SerilizeJson(Server input, string serverPath)
        {
            string jsonString1 = JsonSerializer.Serialize(input);
            File.WriteAllText(@serverPath, jsonString1);
        }

        public static bool ControllPass(string inputPsw, string clientPath, string serverPath, string secretKey) //Metod som kollar om användaren har skrivit rätt lösenord. Om så är fallet returneras true.
        {
            Dictionary<string, string> Dic = ConvertByteToDic(inputPsw, clientPath, serverPath, secretKey);
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

        public static void DisplayVault(string inputPsw, string clientPath, string serverPath, string prop, string secretKey)
        {
            Dictionary<string, string> Dic = ConvertByteToDic(inputPsw, clientPath, serverPath, secretKey);
            if (prop.Length > 0)
            {
                int count = 0;
                foreach (KeyValuePair<string, string> kvp in Dic)
                {
                    if (kvp.Key == prop)
                    {
                        Console.WriteLine("Service = {0}, Password = {1}", kvp.Key, kvp.Value);
                        count++;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Your service was not found");
                }
            }
            else
            {
                foreach (KeyValuePair<string, string> kvp in Dic)
                {
                    Console.WriteLine("Service = {0}, Password = {1}", kvp.Key, kvp.Value);
                }
            }
        }


        public static void CreateAccount(string mpwd, string serverPath, string clientPath, string secretKey)
        {
            byte[] openIv;
            WriteToFile(clientPath);

            using (Aes myAes = Aes.Create())
            {
                openIv = myAes.IV;
            }

            Dictionary<string, string> Emptydick = new Dictionary<string, string>();
            string jsonString3 = JsonSerializer.Serialize(Emptydick);
            byte[] y = EncryptStringToBytes_Aes(jsonString3, ConnectsKeyAndPsw(mpwd, clientPath, secretKey), openIv);

            Server serverObj1 = new Server()
            {
                vault = y,
                IV = openIv
            };

            SerilizeJson(serverObj1, serverPath);
        }

        public static void WriteToServer(string inputPsw, string txt, string value, string serverPath, string clientPath, string secretKey1)
        {
            byte[] openIv;
            byte[] svar4;

            using (Aes myAes = Aes.Create())
            {

                byte[] secretKey = ConnectsKeyAndPsw(inputPsw, clientPath, secretKey1);
                openIv = ReadFromServerIv(serverPath);
                string jsonString3 = JsonSerializer.Serialize(Vault.AddToVault(txt, value, ConvertByteToDic(inputPsw, clientPath, serverPath, secretKey1)));
                svar4 = EncryptStringToBytes_Aes(jsonString3, secretKey, openIv);

            }

            Server serverObj = new Server()
            {
                vault = svar4,
                IV = openIv
            };
            SerilizeJson(serverObj, serverPath);
        }

        public static byte[] ReadFromServerIv(string serverPath)
        {
            string jsonString = File.ReadAllText(@serverPath);
            Server readResult = JsonSerializer.Deserialize<Server>(jsonString);
            return readResult.IV;
        }

        public static byte[] ReadFromServerVault(string serverPath)
        {
            string jsonString = File.ReadAllText(@serverPath);
            Server readResult = JsonSerializer.Deserialize<Server>(jsonString);
            return readResult.vault;
        }

        public static Dictionary<string, string> ConvertByteToDic(string inputPsw, string clientPath, string serverPath, string secretKey)
        {
            string svar = AES.DecryptStringFromBytes_Aes(ReadFromServerVault(serverPath), ConnectsKeyAndPsw(inputPsw, clientPath, secretKey), ReadFromServerIv(serverPath)); //hej ska vara samma console.readline som rad 17 representerar
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

        public static void UpdateVault(string inputPsw, Dictionary<string, string> x, string serverPath, string clientPath, string secretKey1)
        {
            byte[] openIv = ReadFromServerIv(serverPath);
            byte[] encryptedDic;
            using (Aes myAes = Aes.Create())
            {
                byte[] secretKey = ConnectsKeyAndPsw(inputPsw, clientPath, secretKey1);
                string jsonString3 = JsonSerializer.Serialize(x);
                encryptedDic = EncryptStringToBytes_Aes(jsonString3, secretKey, openIv);
            }

            Server serverObj = new Server()
            {
                vault = encryptedDic,
                IV = openIv
            };
            SerilizeJson(serverObj, serverPath);
        }
    }
}
