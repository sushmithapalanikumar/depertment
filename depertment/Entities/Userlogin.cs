using System;
using System.Collections.Generic;

namespace depertment.Entities
{
    public partial class Userlogin
    {
        public int UserId { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
    }
}
