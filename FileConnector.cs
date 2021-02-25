using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace PasswordManager
{
    public class FileConnector : SecretKey
    {

        public byte[] secretKey { get; set; }

        // Function to write data to a file using JSON.
        public void WriteToFile() // Fetching the secretKey and adding it to a JSON file. 
        {
            FileConnector con1 = new FileConnector()
            {
                secretKey = sKeyGenerator()
            };

            string jsonString1 = JsonSerializer.Serialize(con1);
            File.WriteAllText(@"loginInfo.json", jsonString1);

        }

        // Function to get data from file using JSON.
        public byte[] ReadFromFile()
        {
            string jsonString2 = File.ReadAllText(@"loginInfo.json");
            FileConnector readResult = JsonSerializer.Deserialize<FileConnector>(jsonString2);

            return readResult.secretKey;
        }
    }
}
