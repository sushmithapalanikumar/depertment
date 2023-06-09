using System;
using System.Collections.Generic;

namespace depertment.Entities
{
    public partial class UserRegister
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? MobileNumber { get; set; }
    }
}
