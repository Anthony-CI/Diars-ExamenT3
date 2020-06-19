using AnthonyCoronadoIpanaqué.DB.Configuracion;
using AnthonyCoronadoIpanaqué.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthonyCoronadoIpanaqué.DB
{
    public class AppPruebaContex : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pokemon> Pokemones { get; set; }
        public DbSet<Captura> Capturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ExamenT3;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new PokemonConfiguracion());
            modelBuilder.ApplyConfiguration(new CapturaConfiguracion());
        }
    }
}
