using System;
using AluraApi.AluraDomain.Entities;
using AluraApi.AluraRepository.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace AluraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private AluraContext _context ;

        public VideoController(AluraContext context)
        {
            _context = context;
            
        }

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] Video video)
        {
            if(video == null)
                return BadRequest();

            _context.Videos.Add(video);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecupeVideoPorId), new {Id = video.Id}, video);
        }

        [HttpGet("/videos")]
        public ICollection<Video> RecuperaVideos()
        {
            return _context.Videos.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult RecupeVideoPorId(int id)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id );

            return video != null ? Ok(video) : NotFound(); 

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if(video != null)
            {
                _context.Videos.Remove(video);
                _context.SaveChanges();

                return Ok($"{video.Titulo} deletado ");
            }
            
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaVideo(int id , [FromBody] Video novoVideo)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == novoVideo.Id);

            if(video == null)
                return NotFound();
            

            //_context.Videos.
            
            return Ok();
        }

    }
}