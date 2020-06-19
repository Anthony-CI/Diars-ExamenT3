using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthonyCoronadoIpanaqué.Models
{
    public class Captura
    {
        public int IdCaptura { get; set; }
        public int IdPokemon { get; set; }
        public int IdUsuario { get; set; }

        public Pokemon Pokemon { get; set; }
        public Usuario Usuario { get; set; }
    }
}
