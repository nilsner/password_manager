using System;
using System.Collections.Generic;

namespace Code_off
{
    public class ServerFile : UserInfo
    {
        public byte[] vault { get; set; }
        public byte[] IV { get; set; }
    }
}
