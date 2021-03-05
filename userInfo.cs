using System;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Code_off
{
    public class UserInfo
    {
        public string Id {get; set;}
        public byte[] secretKey {get; set;}

    }
}
