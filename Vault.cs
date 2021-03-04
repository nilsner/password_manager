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
    }
}
