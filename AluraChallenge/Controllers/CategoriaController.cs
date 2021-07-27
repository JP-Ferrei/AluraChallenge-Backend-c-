using System;
using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

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
            var categorias = _context.Categorias.OrderBy(c => c.Id).Include(c => c.Videos).ToList();
            
            return Ok(categorias);
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

            if( resultado != null ) return BadRequest("Campos Obrigatórios");

            categorias.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpPost("{id}/video")]
        public IActionResult AddVideoInCategoria(int id, [FromBody] Video video)
        {
            try {
                var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

                if(categoria == null)
                {
                    return NotFound();
                }

                categoria.Videos.Add(video);
                _context.SaveChanges();

                return Ok();
            
            
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCategoria(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria == null) return NotFound();

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult atualizaCategoria(int id,[FromBody] JsonPatchDocument<Categoria> model)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null) return NotFound();

            model.ApplyTo(categoria, ModelState);
            _context.SaveChanges();

            return Ok(categoria);

        }
    }
}
