using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Code_off
{
    public class SecretKey 
    {

        public SecretKey()
        {

        }


        public static byte[] SKeyGenerator()
        {
            byte[] sKey = new byte[16];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(sKey);

                return sKey;
            }

        }



    }
}
