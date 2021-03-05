using System;
using System.IO;
using System.Text.Json;

namespace Code_off
{
    public class ClientFileConnect : AES 
    {

        public byte[] secretKey { get; set; }

        // Function to write data to a file using JSON.
        public static void WriteToFile() // Fetching the secretKey and adding it to a JSON file. 
        {
            byte[] saltClient = SKeyGenerator();

            ClientFileConnect con1 = new ClientFileConnect()
            {
                secretKey = saltClient 
            };
            string jsonString1 = JsonSerializer.Serialize(con1);
            File.WriteAllText(@"ClientInfo.json", jsonString1);

        }

        public static void OverwriteClientPass(byte[] input)
        {
            ClientFileConnect con1 = new ClientFileConnect()
            {
                secretKey = input
            };

            string jsonString1 = JsonSerializer.Serialize(con1);
            File.WriteAllText(@"ClientInfo.json", jsonString1);
        }
      

        // Function to get data from file using JSON.
        public static byte[] ReadFromFile()
        {
            string jsonString2 = File.ReadAllText(@"ClientInfo.json");
            ClientFileConnect readResult = JsonSerializer.Deserialize<ClientFileConnect>(jsonString2);

            return readResult.secretKey;
        }
    }
}
