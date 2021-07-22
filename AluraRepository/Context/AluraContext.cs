using System.Diagnostics.CodeAnalysis;
using AluraApi.AluraDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AluraApi.AluraRepository.Context
{
    public class AluraContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public AluraContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}