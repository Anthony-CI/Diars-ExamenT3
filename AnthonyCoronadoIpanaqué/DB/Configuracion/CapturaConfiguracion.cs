using AnthonyCoronadoIpanaqué.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthonyCoronadoIpanaqué.DB.Configuracion
{
    public class CapturaConfiguracion : IEntityTypeConfiguration<Captura>
    {
        public void Configure(EntityTypeBuilder<Captura> builder)
        {
            builder.ToTable("Captura");
            builder.HasKey(o => o.IdCaptura);


            builder.HasOne(o => o.Pokemon)
                .WithMany(o => o.Capturas)
                .HasForeignKey(o => o.IdPokemon);

            builder.HasOne(o => o.Usuario)
                .WithMany(o => o.Capturas)
                .HasForeignKey(o => o.IdUsuario);
        }
    }
}
