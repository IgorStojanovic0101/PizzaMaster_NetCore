using System;
using System.Collections.Generic;

namespace PizzaMaster.Domain.Entities
{
    public partial class UserLog
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? LogDate { get; set; }
    }
}
