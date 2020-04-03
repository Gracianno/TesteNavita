using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteNavita.Domain.Identity
{
    public class User: IdentityUser<int>
    {
        [Column(TypeName ="nvarchar(150)")]
        public String FullNome { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
