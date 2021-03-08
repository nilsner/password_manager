using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PasswordManager
{
    

    public class Vault : Dictionary
    {
        public static Dictionary<string, string> pswVault = new Dictionary<string, string>();

        public static Dictionary<string, string> AddToVault(string key, string value)
        {
            
            try
            {
                pswVault.Add(key, value);
                return pswVault;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with key = " + key + " already exists.");
                return pswVault;
            }
            
        }

        public static void RemoveFromVault(string key)
        {
            if (!pswVault.ContainsKey(key))
            {
                Console.WriteLine("An element with key " + key + " is not found. Please delete an existing key.");
            }
            else
            {
                pswVault.Remove(key);
            }
        }



    }
}
