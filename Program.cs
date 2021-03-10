using System;
using System.IO;

namespace PasswordManager3._0
{
    class Program
    {
        public static void Main(string[] args)
        {
            // bandy "client.json", "server.json"
            // fotboll "cl.json", "se.json"

            args = new string[] { "get", "cl.json", "se.json" };
           
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
                    //FEL FÅR INTE FORSÄTTA EFTER
                    count++;
                }
            }
            else
            {
                //FEL FÅR INTE FORSÄTTA EFTER
                count++;
            }

            if (count > 0)
            {
                Console.WriteLine("Input was given in wrong format");
            }
            else
            {
                switch (args[0]) //ALLA METODER MÅSTE TA EMOT OCH ANVÄNDA args[1] och args[2]. Innan det här körs ska man kontrollera att det ens finns tillräckligt med inputs och i korrekt form
                {

                    case "login": // HELT KLAR vad vi kan förstå
                        Console.WriteLine("Type your master password");
                        string masterPasswordLogin = Console.ReadLine();
                        Console.WriteLine("Type your secret key");
                        string secretKeyLogin = Console.ReadLine();
                        if (ServerFileConnect.ControllPass(masterPasswordLogin, args[1], args[2], secretKeyLogin) == true)
                        {
                            //RÄTT INLOGG, commands är nu tillgängliga

                            Console.WriteLine("You're now logged in"); //KOPIERAR JAG IN HEMLIGA NYCKELN MED COPY + PASTE FUNKAR DET MEN INTE OM JAG SKRIVER IN SkEY MANUELLT

                        }
                        else
                        {
                            Console.WriteLine("Something went wrong");
                        }
                        break;

                    case "init": //HELT KLAR obs Lösenordet kan vara vad som helst, dvs ett enkelt mellanslag
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

                    case "get": //HELT KLAR
                        Console.WriteLine("Type your master password");
                        string masterPassword = Console.ReadLine();
                        string prop = "";
                        string secretKeyGet = "";
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
                        break;

                    case "set": // Helt klar
                        if (args.Length > 4)
                        {
                            Console.WriteLine("Something went wrong, try again");
                        }
                        else
                        {
                            Console.WriteLine("Type your master password");
                            string masterPasswordSet = Console.ReadLine();
                            
                            Console.WriteLine("Type the new password");
                            string NewPas = Console.ReadLine();
                            string secretKeySet = "";

                            Vault.ChangeServicePsw(args[3], NewPas, masterPasswordSet, args[2], args[1], secretKeySet);
                        }
                        break;

                    case "drop": // Helt klar
                        if (args.Length > 4)
                        {
                            Console.WriteLine("Something went wrong, try again");
                        }
                        else
                        {
                            Console.WriteLine("Type your master password");
                            string masterPasswordDrop = Console.ReadLine();
                            //Console.WriteLine("Type the name of the service you wish to delete");
                            //string RemoveKey = Console.ReadLine();
                            string secretKeyDrop = "";
                            Vault.RemoveFromVault(args[3], masterPasswordDrop, args[2], args[1], secretKeyDrop);
                        }
                        break;

                    case "secret": //HELT KLAR
                        Console.WriteLine("Your secret key is: \n" + SecretKey.DisplaySecretKey(args[1]));
                        break;

                    case "create": // Helt klar, användaren skapar en ny service och ett lösenord till den
                        if(args.Length != 3)
                        {
                            Console.WriteLine("Something went wrong, try again");
                        }
                        else
                        {
                            Console.WriteLine("Type your master password");
                            string masterPasswordCreate = Console.ReadLine();
                            Console.WriteLine("Type your new service:");
                            string NewService = Console.ReadLine();
                            Console.WriteLine("Type your password for " + NewService + ":");
                            string NewPassword = Console.ReadLine();
                            string secretKeyCreate = "";
                            ServerFileConnect.WriteToServer(masterPasswordCreate, NewService, NewPassword, args[2], args[1], secretKeyCreate);
                            Console.WriteLine("New service is created.");
                        }
                        break;

                    default:
                        Console.WriteLine("Given command does not exist");
                        break;
                }
            }
            //Console.WriteLine();
            //Console.WriteLine("Type a new command or type exit to finish your session");
            //FirstInput = Console.ReadLine();
            //}

            //args = new string[] { "get", "ClientInfo3.json", "ServerInfo3.json" }; //RÄTT FORMAT OCH FILNAMN FÖR NILS

            //Console.WriteLine("Do you want to create a new account (press A) or login to existing (press B).");

            //string MasterPassword = "";
            //do
            //{
            //    string answer = Console.ReadLine(); 
            //    if (answer == "A" || answer == "a")
            //    {
            //        Console.WriteLine("Create a new password");
            //        MasterPassword = Console.ReadLine();
            //        ServerFileConnect.CreateAccount(MasterPassword, args[2], args[1]);
            //    }
            //    else if (answer == "B" || answer == "b")
            //    {
            //        Console.WriteLine("Type your password");
            //        MasterPassword = Console.ReadLine();
            //        if (ServerFileConnect.ControllPass(MasterPassword, args[1], args[2]) == false)
            //        {
            //            Main(args);
            //        }
            //        else
            //        {
            //            Console.WriteLine("WELCOME");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Please use either A, to create a account, or B, to login to an axisting one.");
            //    }
            //}
            //while (MasterPassword == "");

            //Console.WriteLine("Available commands: \nget \nset \ndrop \nsecret \ncreate");
            //Console.WriteLine();

            //Console.WriteLine("Type a command");
            //string FirstInput = Console.ReadLine();

            //while (FirstInput != "exit")
            //{
        }
    }
}
