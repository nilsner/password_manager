using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace LösenordsHanterare
{
    public class RNGCSP
    {
        public static byte[] GetSecureRandomNumber()
        {
            using (RNGCryptoServiceProvider rngC = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[16];
                rngC.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}

// I MAIN: byte[] test = GetSecureRandomNumber();
// Console.WriteLine(test);