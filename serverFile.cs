using System;
namespace PasswordManager
{
    public class serverFile : AES
    {
        public byte[] vault { get; set; }
        public byte[] IV { get; set; }
    }
}
