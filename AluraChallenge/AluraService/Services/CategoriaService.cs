using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge.AluraService.Services
{
    public class CategoriaService:ICategoriaService
    {
        private readonly AluraContext _context;

        public CategoriaService(AluraContext context)
        {
            _context = context;
        }

        public Categoria GetById(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if( categoria == null )
                throw new NullReferenceException();

            
            return categoria;
        }

        public void Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id);

            if( categoria == null )
                throw new NullReferenceException();

            _context.Categorias.Remove(categoria);

            _context.SaveChanges();

        }

        public ICollection<Categoria> GetAll()
        {
            var categorias = _context.Categorias.ToList();

            if( categorias == null )
                throw new NullReferenceException();

            return categorias;

        }

        public void patch(int id, JsonPatchDocument<Categoria> model)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if( categoria == null ) throw new NullReferenceException();

            model.ApplyTo(categoria);
            _context.SaveChanges();
        }

        public void post(Categoria model)
        {
            var categorias = _context.Categorias;
            var modelTitulo = model.Titulo.ToUpper();

            var resultado = categorias.FirstOrDefault(c => c.Titulo.ToUpper() == model.Titulo);

            if( resultado != null ) throw new ArgumentException();

            categorias.Add(model);
            _context.SaveChanges();
        }

        
    }
}
