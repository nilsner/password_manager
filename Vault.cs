using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager3._0
{
    public class Vault : ServerFileConnect
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
                Console.WriteLine(key + " aldready exist");
                return pswVault;
            }
        }

        public static void RemoveFromVault(string key, string psw)
        {
            Dictionary<string, string> x = ConvertByteToDic(psw);
            int count = 0;
            foreach (var dic in x)
            {
                if (dic.Key == key)
                {
                    count++;
                }
            }
            if (count >= 1)
            {
                foreach (KeyValuePair<string, string> kvp in x)
                {
                    if (kvp.Key == key)
                    {
                        x.Remove(kvp.Key);
                        Console.WriteLine("Succesfully removed password");
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            else
            {
                Console.WriteLine("The service you tried to delete does not exist");
            }
            UpdateVault(psw, x);
        }

        public static void ChangeServicePsw(string key, string newPsw)
        {
            Dictionary<string, string> dic = ConvertByteToDic(newPsw);

            bool found = false; // create a bool that is false to later determine if the key is found or not.

            foreach(KeyValuePair<string, string> kvp in dic)
            {
                
                if (kvp.Key == key)
                {
                    dic[key] = newPsw;
                    found = true; // the key was found therefore "found" is set to true.
                    Console.WriteLine("Your new password for {key}, is {newPsw}", kvp.Key, kvp.Value);
                    break;
                }
                else
                {
                    continue; 
                    
                }
            }

            if (!found) // if found is false no key matched and therefore the service does not exist in the dictionary
            {
                Console.WriteLine("The service doesn't exist.");
            }

            UpdateVault(newPsw, dic);
        }
    }
}
