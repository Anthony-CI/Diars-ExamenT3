using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnthonyCoronadoIpanaqué.Models
{
    public class Pokemon
    {
        public int IdPokemon { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tipo { get; set; }
        
        public string Imagen { get; set; }

        public List<Captura> Capturas { get; set; }
    }
}
