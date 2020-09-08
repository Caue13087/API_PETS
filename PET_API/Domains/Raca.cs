using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PET_API.Domains
{
    public class Raca
    {
        public int IdRaca { get; set; }
        public string Descricao { get; set; }
        public int IdTipoDePet { get; set; }
        public int IdTipoPet { get; internal set; }
    }
}
