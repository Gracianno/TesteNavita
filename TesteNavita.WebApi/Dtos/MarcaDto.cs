using TesteNavita.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNavita.WebApi.Dtos
{
    public class MarcaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public String Nome { get; set; }
        public List<PatrimonioDto> Patrimonios { get; set; }

    }
}
