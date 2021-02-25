using System;

namespace PasswordManager
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileConnector test = new FileConnector();
            test.WriteToFile();
            Console.WriteLine(test.ReadFromFile());
        }
    }
}
