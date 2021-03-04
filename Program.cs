using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Code_off
{
    class Program
    {
        public static void Main()
        {

            //FileConnectServer.CreateAccount(); //DEN HÄR ÄR REDAN KÖRD EN GÅNG OCH SPARAD, BEHÖVER ALDRIG GÖRAS OM IGEN. OM DETTA SKER KOMMER DECRYPTEN FACKAS
            string input2 = Console.ReadLine();
            string input3 = Console.ReadLine();
            //Console.WriteLine(FileConnectServer.DisplayVault("Nisse")); //Funkar
            //FileConnectServer test = new FileConnectServer();
            //ConnectionKey go = new ConnectionKey();
            
            FileConnectServer.writeToServer("Nisse", input2, input3); //tar emot två saker, lösenord och text som ska sparas, det sista av de två är de som sparas i filen. Dvs Nisse är löseordet och det enda som finns sparat i vault atm är King
            //string svar = AES.DecryptStringFromBytes_Aes(FileConnectServer.readFromServerVault(), ConnectionKey.ConnectsKeyAndPsw("Nisse"), FileConnectServer.readFromServerIv()); //hej ska vara samma console.readline som rad 17 representerar
            //Console.WriteLine(svar);
            Console.WriteLine(FileConnectServer.DisplayVault("Nisse")); //Funkar
        }
    }
}
