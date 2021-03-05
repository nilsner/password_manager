using System;

namespace Code_off
{
    class Program
    {
        public static void Main()
        {
            //ServerFileConnect.CreateAccount(); //DEN HÄR ÄR REDAN KÖRD EN GÅNG OCH SPARAD, BEHÖVER ALDRIG GÖRAS OM IGEN. OM DETTA SKER KOMMER DECRYPTEN FACKAS
            
            string MasterPassword = "Nisse"; //Rätta koden är Nisse

            if (ServerFileConnect.ControllPass(MasterPassword) == false)
            {
                //Lösenordet är fel
            }
            else
            {
                string input2 = Console.ReadLine();
                string input3 = Console.ReadLine();
                //ServerFileConnect.DisplayVault("Nisse"); //Display

                ServerFileConnect.WriteToServer(MasterPassword, input2, input3); //tar emot två saker, lösenord och text som ska sparas, det sista av de två är de som sparas i filen. Dvs Nisse är löseordet och det enda som finns sparat i vault atm är King
                                                                                 //string svar = AES.DecryptStringFromBytes_Aes(ServerFileConnect.ReadFromServerVault(), ConnectionKey.ConnectsKeyAndPsw("Nisse"), ServerFileConnect.ReadFromServerIv()); //hej ska vara samma console.readline som rad 17 representerar
                                                                                 //Console.WriteLine(svar);
                ServerFileConnect.DisplayVault(MasterPassword); //Funkar
                string RemoveKey = Console.ReadLine(); //FUNKAR INTE, MÅSTE SPARA NER PÅ JSON EFTER ATT HA UPPDATERAT DIC
                Vault.RemoveFromVault(RemoveKey, MasterPassword);
                ServerFileConnect.DisplayVault(MasterPassword);
            }
            
        }
    }
}
