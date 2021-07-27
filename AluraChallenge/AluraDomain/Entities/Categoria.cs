using AluraChallenge.AluraDomain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AluraChallenge.AluraDomain.Entities
{
    public class Categoria : IEntity
    {
        public int Id { get ; set ; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Cor { get; set; }
        public ICollection<Video> Videos { get; set; }

        public Categoria()
        {
            Videos = new List<Video>();
        }
    }
}