using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNavita.WebApi.Dtos
{
    public class UserDto
    {
        [Required]
        public String UserName { get; set; }
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String FullNome { get; set; }
    }
}
