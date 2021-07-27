using System;
using System.ComponentModel.DataAnnotations;
using AluraChallenge.AluraDomain.Interfaces;

namespace AluraChallenge.AluraDomain.Entities
{
    public class Video : IEntity
    {
        public int Id { get; set; } 
        
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
        public DateTime DataDeEnvio { get; set; }

        public Video()
        {
            DataDeEnvio = DateTime.Now;
        }
    }
}