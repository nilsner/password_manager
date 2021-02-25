using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace LösenordsHanterare
{
    public class RNGCSP
    {
        private static RNGCrypto rngC = new RNGCrypto();

        public static void Main()
        {
            const int TotalRolls = 20000;
            int[] results = new int[6];

            for (int y = 0; y < TotalRolls; y++)
            {
                byte roll = RollDice((byte)results.Length);
                results[roll - 1]++;
            }
            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine("{0}: {1} ({2:p1})", i + 1, results[1], (double)results[i] / (double)TotalRolls);
            }
            rngC.Dispose();
        }

        public static byte RollDice(byte numberOfSides)
        {
            if (numberOfSides <= 0)
                throw new ArgumentOutOfRangeException("numberOfSides");

            byte[] randomNumber = new byte[1];
            do
            {
                rngC.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0], numberOfSides));
            return (byte)((randomNumber[0] % numberOfSides) + 1);
        }

        private static bool IsFairRoll(byte roll, byte numberSides)
        {
            int FullSetsOfValues = byte.MaxValue / numberSides;
            return roll < numberSides * FullSetsOfValues;
        }




    }
}
