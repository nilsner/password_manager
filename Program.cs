using System;
using System.IO;

namespace PasswordManager3._0
{
    class Program
    {
        public static void Main(string[] args) //string[] args
        {
            //string test = "get nisseclient nisseserver"; 
            //var args = test.Split(' ');

            int count = 0;
            if (args[0] == "secret")
            {
                if (args.Length == 2)
                {

                }
                else
                {
                    count++;
                }
            }
            else if (args.Length >= 3)
            {
                if (args[1].Length < 1 || args[2].Length < 1 || args[1].Trim().Length == 0 || args[2].Trim().Length == 0)
                {
                    count++;
                }
            }
            else
            {
                count++;
            }

            if (count > 0)
            {
                Console.WriteLine("Input was given in wrong format");
            }
            else
            {
                switch (args[0])
                {

                    case "login": //OSÄKER HÄR
                        Console.WriteLine("Type your master password");
                        string masterPasswordLogin = Console.ReadLine();
                        Console.WriteLine("Type your secret key");
                        string secretKeyLogin = Console.ReadLine();
                        if (ServerFileConnect.ControllPass(masterPasswordLogin, args[1], args[2], secretKeyLogin) == true)
                        {
                            Console.WriteLine("You're now logged in");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong");
                        }
                        break;

                    case "init": //FUNKAR APRIL
                        if (args.Length > 3)
                        {
                            Console.WriteLine("Input was given in wrong format");
                        }
                        else
                        {
                            Console.WriteLine("Type your new password");
                            string newMsPassword = Console.ReadLine();
                            string secretKeyInit = "";
                            ServerFileConnect.CreateAccount(newMsPassword, args[2], args[1], secretKeyInit);
                        }
                        break;

                    case "get": //FUNKAR APRIL
                        Console.WriteLine("Type your master password");
                        string masterPassword = Console.ReadLine();
                        string sKey = SecretKey.DisplaySecretKey(args[1]);
                        string prop = "";
                        string secretKeyGet = "";

                        if (ServerFileConnect.ControllPass(masterPassword, args[1], args[2], sKey) == true)
                        {
                            if (args.Length == 4)
                            {
                                prop = args[3];
                                ServerFileConnect.DisplayVault(masterPassword, args[1], args[2], prop, secretKeyGet);
                            }
                            else if (args.Length == 3)
                            {
                                ServerFileConnect.DisplayVault(masterPassword, args[1], args[2], prop, secretKeyGet);
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong, try again");
                            }
                        }
                        break;



                    case "set": //FUNKAR APRIL
                        if (args.Length > 4)
                        {
                            Console.WriteLine("Something went wrong, try again");
                        }
                        else
                        {
                            Console.WriteLine("Type your master password");
                            string masterPasswordSet = Console.ReadLine();
                            string secretKey = SecretKey.DisplaySecretKey(args[1]);
                            if (ServerFileConnect.ControllPass(masterPasswordSet, args[1], args[2], secretKey) == true)
                            {
                                Console.WriteLine("Type the new password");
                                string NewPas = Console.ReadLine();
                                string secretKeySet = "";
                                Vault.ChangeServicePsw(args[3], NewPas, masterPasswordSet, args[2], args[1], secretKeySet);
                            }


                        }
                        break;

                    case "drop": //FUNKAR APRIL
                        if (args.Length > 4)
                        {
                            Console.WriteLine("Something went wrong, try again");
                        }
                        else
                        {
                            Console.WriteLine("Type your master password");
                            string masterPasswordDrop = Console.ReadLine();
                            string secretKey = SecretKey.DisplaySecretKey(args[1]);
                            if (ServerFileConnect.ControllPass(masterPasswordDrop, args[1], args[2], secretKey) == true)
                            {
                                string secretKeyDrop = "";
                                Vault.RemoveFromVault(args[3], masterPasswordDrop, args[2], args[1], secretKeyDrop);
                            }
                        }
                        break;

                    case "secret": //FUNKAR APRIL
                        Console.WriteLine("Your secret key is: \n" + SecretKey.DisplaySecretKey(args[1]));
                        break;

                    default:
                        Console.WriteLine("Given command does not exist");
                        break;
                }
            }
        }
    }
}
