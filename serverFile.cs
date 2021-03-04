using System;
using System.Collections.Generic;

namespace Code_off
{
    public class serverFile : userInfo
    {
        public byte[] vault { get; set; }
        public byte[] IV { get; set; }
    }
}
