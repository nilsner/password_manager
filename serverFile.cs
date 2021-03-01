using System;
namespace Code_off
{
    public class serverFile : AES
    {
        public byte[] vault { get; set; }
        public byte[] IV { get; set; }
    }
}
