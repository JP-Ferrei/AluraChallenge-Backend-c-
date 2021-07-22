using System;
using System.ComponentModel.DataAnnotations;
using AluraApi.AluraDomain.Interfaces;

namespace AluraApi.AluraDomain.Entities
{
    public class Video : IEntity
    {
        public int Id { get; set; } 
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