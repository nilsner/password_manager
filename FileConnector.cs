using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Code_off
{
    public class FileConnector : AES 
    {

        public byte[] secretKey { get; set; }

        // Function to write data to a file using JSON.
        public static void WriteToFile() // Fetching the secretKey and adding it to a JSON file. 
        {
            byte[] saltClient = sKeyGenerator();

            FileConnector con1 = new FileConnector()
            {
                secretKey = saltClient 
            };

            string jsonString1 = JsonSerializer.Serialize(con1);
            File.WriteAllText(@"loginInfo.json", jsonString1);

        }

        public static void OverwriteClientPass(byte[] input)
        {
            FileConnector con1 = new FileConnector()
            {
                secretKey = input
            };

            string jsonString1 = JsonSerializer.Serialize(con1);
            File.WriteAllText(@"loginInfo.json", jsonString1);
        }
      

        // Function to get data from file using JSON.
        public static byte[] ReadFromFile()
        {
            string jsonString2 = File.ReadAllText(@"loginInfo.json");
            FileConnector readResult = JsonSerializer.Deserialize<FileConnector>(jsonString2);

            return readResult.secretKey;
        }
    }
}
