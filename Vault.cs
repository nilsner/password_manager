using System;
using System.Collections.Generic;
using System.Text;

namespace Code_off
{
    public class Vault : FileConnectServer
    {
        public static Dictionary<string, string> pswVault = new Dictionary<string, string>();

        public static Dictionary<string, string> AddToVault(string key, string value, Dictionary<string,string> x)
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
                foreach(KeyValuePair<string, string> kvp in x)
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
            UpdateVault(psw, x);
        }
    }
}
