using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace PasswordManager
{
    class SecretKey
    {

        public SecretKey()
        {

        }

        

        public static byte[] sKeyGenerator()
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
