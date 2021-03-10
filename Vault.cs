using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager3._0
{
    public class Vault : ServerFileConnect
    {
        public static Dictionary<string, string> pswVault = new Dictionary<string, string>();

        public static Dictionary<string, string> AddToVault(string key, string value, Dictionary<string, string> x)
        {
            pswVault = x;
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

        public static void RemoveFromVault(string key, string psw, string serverPath, string clientPath, string secretKey)
        {
            Dictionary<string, string> x = ConvertByteToDic(psw, clientPath, serverPath, secretKey);
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
                Console.WriteLine("The serivce you tried to delete does not exist");
            }
            UpdateVault(psw, x, serverPath, clientPath, secretKey);
        }

        public static void ChangeServicePsw(string key, string newPsw, string oldPas, string serverPath, string clientPath, string secretKey)
        {
            Dictionary<string, string> dic = ConvertByteToDic(oldPas, clientPath, serverPath, secretKey);

            bool found = false; // create a bool that is false to later determine if the key is found or not.

            foreach (KeyValuePair<string, string> kvp in dic)
            {
                if (kvp.Key == key)
                {
                    dic[key] = newPsw;
                    found = true; // the key was found therefore "found" is set to true.
                    Console.WriteLine("Your new password for {0}, is {1}", key, newPsw);
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
            //testtest
            UpdateVault(oldPas, dic, serverPath, clientPath, secretKey);
        }
    }
}
