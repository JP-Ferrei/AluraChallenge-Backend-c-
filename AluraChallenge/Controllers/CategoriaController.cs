using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriaController :ControllerBase
    {
        private readonly ICategoriaService _categoria;
        private AluraContext _context;

        public CategoriaController(ICategoriaService categoria, AluraContext context)
        {
            _categoria = categoria;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cateforias = _context.Categorias;
            
            return Ok(cateforias);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoria = _context.Categorias.Find(id);
            
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Categoria model)
        {
            var categorias = _context.Categorias;
            var modelTitulo = model.Titulo.ToUpper();

            var resultado = categorias.FirstOrDefault(c => c.Titulo.ToUpper() == model.Titulo);

            if( resultado != null ) return BadRequest();

            categorias.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }
    }
}
