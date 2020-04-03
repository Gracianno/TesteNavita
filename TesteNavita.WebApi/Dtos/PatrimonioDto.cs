using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNavita.WebApi.Dtos
{
    public class PatrimonioDto
    {
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String NumeroTombo { get; set; }
        [Required(ErrorMessage = "Marca é obrigatório.")]
        public int MarcaId { get; set; }


    }
}
