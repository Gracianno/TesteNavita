using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNavita.WebApi.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
