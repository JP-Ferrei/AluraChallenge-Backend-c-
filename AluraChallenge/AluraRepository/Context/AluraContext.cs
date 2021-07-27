using System.Diagnostics.CodeAnalysis;
using AluraChallenge.AluraDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.AluraRepository.Context
{
    public class AluraContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public AluraContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}