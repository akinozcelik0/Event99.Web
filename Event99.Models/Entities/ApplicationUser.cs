using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event99.Models.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
