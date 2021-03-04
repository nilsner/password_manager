using System;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace PasswordManager
{
    public class FileConnectServer : FileConnector
    {

        public static string DisplayVault(string inputPsw)
        {
            string svar = AES.DecryptStringFromBytes_Aes(FileConnectServer.readFromServerVault(), ConnectionKey.ConnectsKeyAndPsw(inputPsw), FileConnectServer.readFromServerIv()); //hej ska vara samma console.readline som rad 17 representerar
            return svar;
        }

        public static void CreateAccount(string mpwd)
        {
            
            byte[] openIv;
            WriteToFile(); //skapar en secret key

            using (Aes myAes = Aes.Create())
            {
                openIv = myAes.IV;
            }

            Dictionary<string, string> Emptydick = new Dictionary<string, string>();
            string jsonString3 = JsonSerializer.Serialize(Emptydick);
            byte[] y = EncryptStringToBytes_Aes(jsonString3, ConnectsKeyAndPsw(mpwd), openIv);
            

            serverFile serverObj1 = new serverFile()
            {
                vault = y,
                IV = openIv //skapa en IV genom aes
            };

            string jsonString1 = JsonSerializer.Serialize(serverObj1);
            File.WriteAllText(@"IV.json", jsonString1);
        }

        public static void writeToServer(string inputPsw, string txt, string value)
        {
            byte[] openIv;
            //byte[] openEnc;
            byte[] svar4;

            using (Aes myAes = Aes.Create())
            {

                byte[] secretKey = ConnectsKeyAndPsw(inputPsw);
                openIv = readFromServerIv();
                //openEnc = EncryptStringToBytes_Aes(txt, secretKey, openIv);
                //gogo.Add(txt, value);
                //serialisera och sen kryptera gogo

                string svar = DecryptStringFromBytes_Aes(readFromServerVault(), ConnectsKeyAndPsw(inputPsw), readFromServerIv());
                Dictionary<string, string> readResult = JsonSerializer.Deserialize<Dictionary<string, string>>(svar);
                string jsonString3 = JsonSerializer.Serialize(Vault.AddToVault(txt, value, readResult));
                svar4 = EncryptStringToBytes_Aes(jsonString3, secretKey, openIv);

            }

            serverFile serverObj = new serverFile()
            {
                vault = svar4,
                IV = openIv //skapa en IV genom aes
            };

            string jsonString1 = JsonSerializer.Serialize(serverObj);
            File.WriteAllText(@"IV.json", jsonString1);
        }

        public static byte[] readFromServerIv()
        {
            string jsonString = File.ReadAllText(@"IV.json");
            serverFile readResult = JsonSerializer.Deserialize<serverFile>(jsonString);

            return readResult.IV;
        }

        public static byte[] readFromServerVault()
        {
            string jsonString = File.ReadAllText(@"IV.json");
            serverFile readResult = JsonSerializer.Deserialize<serverFile>(jsonString);

            return readResult.vault;
        }
    }
}
