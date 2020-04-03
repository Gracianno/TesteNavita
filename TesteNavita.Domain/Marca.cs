using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNavita.Domain
{
    public class Marca
    {
        public int Id { get; set; }
        public String Nome { get; set; }      
        public List<Patrimonio> Patrimonios { get; set; }
    }
}
