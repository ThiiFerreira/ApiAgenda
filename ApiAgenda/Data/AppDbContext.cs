using ApiAgenda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgenda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contato>()
                .HasOne(contato => contato.Agenda)
                .WithMany(agenda => agenda.Contatos)
                .HasForeignKey(contato => contato.AgendaId);   
        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
    }
}
