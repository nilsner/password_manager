﻿using System;
using System.IO;
using System.Text.Json;

namespace Code_off
{
    public class ClientFileConnect : AES 
    {

        public byte[] secretKey { get; set; }

        // Function to write data to a file using JSON.
        public static void WriteToFile(string clientPath) // Fetching the secretKey and adding it to a JSON file. 
        {
            byte[] saltClient = SKeyGenerator();

            ClientFileConnect con1 = new ClientFileConnect()
            {
                secretKey = saltClient 
            };
            string jsonString1 = JsonSerializer.Serialize(con1);
            File.WriteAllText(@clientPath, jsonString1); //@"ClientInfo3.json"

        }

        // Function to get data from file using JSON.
        public static byte[] ReadFromFile(string clientPath)
        {
            string jsonString2 = File.ReadAllText(@clientPath);
            ClientFileConnect readResult = JsonSerializer.Deserialize<ClientFileConnect>(jsonString2);
            //string svar = Convert.ToBase64String()
            return readResult.secretKey;
        }
    }
}