using System;

namespace Code_off
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Do you want to create a new account (press A) or login to existing (press B).");
            string MasterPassword = "";
            do
            {
                string answer = Console.ReadLine(); 
                if (answer == "A" || answer == "a")
                {
                    Console.WriteLine("Create a new password");
                    MasterPassword = Console.ReadLine();
                    ServerFileConnect.CreateAccount(MasterPassword);
                }
                else if (answer == "B" || answer == "b")
                {
                    Console.WriteLine("Type your password");
                    MasterPassword = Console.ReadLine();
                    if (ServerFileConnect.ControllPass(MasterPassword) == false)
                    {
                        Main();
                    }
                    else
                    {
                        Console.WriteLine("WELCOME");
                    }
                }
                else
                {
                    Console.WriteLine("Please use either A, to create a account, or B, to login to an axisting one.");
                }
            }
            while (MasterPassword == "");

            Console.WriteLine("Available commands: \nget \nset \ndrop \nsecret \ncreate");
            Console.WriteLine();

            Console.WriteLine("Type a command");
            string FirstInput = Console.ReadLine();

            while (FirstInput != "exit")
            {
                switch (FirstInput)
                {

                    case "get":
                        ServerFileConnect.DisplayVault(MasterPassword);
                        break;

                    case "set":
                        Console.WriteLine("Type the service you want to change password on");
                        string Key = Console.ReadLine();
                        Console.WriteLine("Type the new password");
                        string NewPas = Console.ReadLine();
                        Vault.ChangeServicePsw(Key, NewPas, MasterPassword);
                        break;

                    case "drop":
                        Console.WriteLine("Type the name of the service you wish to delete");
                        string RemoveKey = Console.ReadLine();
                        Vault.RemoveFromVault(RemoveKey, MasterPassword);
                        break;

                    case "secret":
                        Console.WriteLine("Your secret key is:");
                        foreach (var secretKey in ClientFileConnect.ReadFromFile())
                        {
                            Console.Write("[" + secretKey + "] ");
                        }   
                        Console.WriteLine("");
                        break;

                    case "create":
                        Console.WriteLine("Type your new service:");
                        string NewService = Console.ReadLine();
                        Console.WriteLine("Type your password for " + NewService + ":");
                        string NewPassword = Console.ReadLine();
                        ServerFileConnect.WriteToServer(MasterPassword, NewService, NewPassword);
                        break;

                    default:
                        Console.WriteLine("Given command does not exist");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Type a new command or type exit to finish your session");
                FirstInput = Console.ReadLine();
            }
            
            //ServerFileConnect.CreateAccount(); //DEN HÄR ÄR REDAN KÖRD EN GÅNG OCH SPARAD, BEHÖVER ALDRIG GÖRAS OM IGEN. OM DETTA SKER KOMMER DECRYPTEN FACKAS

            //string MasterPassword = "Nisse"; //Rätta koden är Nisse

            //if (ServerFileConnect.ControllPass(MasterPassword) == false)
            //{
            //    //Lösenordet är fel
            //}
            //else
            //{
            //    string input2 = Console.ReadLine();
            //    string input3 = Console.ReadLine();
            //    //ServerFileConnect.DisplayVault("Nisse"); //Display

            //    ServerFileConnect.WriteToServer(MasterPassword, input2, input3); //tar emot två saker, lösenord och text som ska sparas, det sista av de två är de som sparas i filen. Dvs Nisse är löseordet och det enda som finns sparat i vault atm är King
            //                                                                     //string svar = AES.DecryptStringFromBytes_Aes(ServerFileConnect.ReadFromServerVault(), ConnectionKey.ConnectsKeyAndPsw("Nisse"), ServerFileConnect.ReadFromServerIv()); //hej ska vara samma console.readline som rad 17 representerar
            //                                                                     //Console.WriteLine(svar);
            //    ServerFileConnect.DisplayVault(MasterPassword); //Funkar
            //    string RemoveKey = Console.ReadLine(); //FUNKAR INTE, MÅSTE SPARA NER PÅ JSON EFTER ATT HA UPPDATERAT DIC
            //    Vault.RemoveFromVault(RemoveKey, MasterPassword);
            //    ServerFileConnect.DisplayVault(MasterPassword);
            //}
            
        }
    }
}