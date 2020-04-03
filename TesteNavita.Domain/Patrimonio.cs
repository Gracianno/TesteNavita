using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNavita.Domain
{
    public class Patrimonio
    {
        public int Id { get; set; }        
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String NumeroTombo { get; set; }        
        public int MarcaId { get; set; }
        public Marca Marca { get; }
    }
}
