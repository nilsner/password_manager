using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager3._0
{
    public class Server : Client
    {
        public byte[] vault { get; set; }
        public byte[] IV { get; set; }
    }
}
