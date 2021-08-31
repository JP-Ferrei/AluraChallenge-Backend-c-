using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Categoria> GetById(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if( categoria == null )
                throw new NullReferenceException();


            return categoria;
        }

        public async Task Delete(int id)
        {
            var categorias = await GetAll();
            var categoria = categorias.FirstOrDefault(x => x.Id == id);

            if( categoria == null )
                throw new NullReferenceException();

            categorias.Remove(categoria);

            await _context.SaveChangesAsync();

        }

        public async Task<List<Categoria>> GetAll()
        {
            var categorias = await _context.Categorias.ToListAsync();

            if( categorias == null )
                throw new NullReferenceException();

            return categorias;

        }

        public async Task Patch(int id, JsonPatchDocument<Categoria> model)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            if( categoria == null ) throw new NullReferenceException();

            model.ApplyTo(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Post(Categoria model)
        {
            var categorias =  await GetAll();
            var modelTitulo = model.Titulo.ToUpper();

            var resultado = categorias.FirstOrDefault(c => c.Titulo.ToUpper() == model.Titulo);

            if( resultado != null ) throw new ArgumentException("Categoria já existe");

            categorias.Add(model);
            await _context.SaveChangesAsync();
        }


    }
}
