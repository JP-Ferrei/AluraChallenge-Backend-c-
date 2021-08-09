﻿using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly ICategoriaService _service;
        private AluraContext _context;

        public CategoriaController(ICategoriaService categoria, AluraContext context)
        {
            _service = categoria;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var categorias = _service.GetAll();
                return Ok(categorias);

            }
              catch( NullReferenceException e )
            {
                return NotFound(e.Message);
            } catch( Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var categoria = _service.GetById(id);

                return Ok(categoria);

            }
            catch(NullReferenceException e )
            {
                return NotFound(e.Message);
            }
            catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Categoria> model)
        {
            try
            {
                _service.patch(id, model);
                return Ok();
            } catch( NullReferenceException e )
            {
                return NotFound(e.Message);
            } catch( Exception e )
            {
                return StatusCode(500, e.Message);
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Categoria model)

        {
            try
            {
                _service.post(model);
                return Ok(model);
            }
            catch(ArgumentException e )
            {
                return BadRequest(e.Message);
            }
            catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);

                return NoContent();
            }
            catch(NullReferenceException e )
            {
                return NotFound(e.Message);
            }
            catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }
    }

}
