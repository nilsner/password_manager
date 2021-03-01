using System;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            FileConnectServer.writeToServer(input); 
            string svar = AES.DecryptStringFromBytes_Aes(FileConnectServer.readFromServerVault(), FileConnector.ReadFromFile(), FileConnectServer.readFromServerIv());
            if (svar == input) 
            {
                Console.WriteLine("Välkommen");
            }
            else
            {
                Console.WriteLine("No bueno");
            } 
            
            //FileConnector test = new FileConnector();
            //test.WriteToFile();
            //Console.WriteLine(test.ReadFromFile());
        }
    }
}
