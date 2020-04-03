using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteNavita.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles{get; set;}
    }
}
