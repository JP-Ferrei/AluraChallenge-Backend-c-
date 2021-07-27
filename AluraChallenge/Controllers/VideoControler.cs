using System;
using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AluraChallenge.Controllers
{
    [ApiController]
    [Route("videos")]
    public class VideoController : ControllerBase
    {
        private AluraContext _context ;
        private  IVideoService _videoService;

        public VideoController(AluraContext context, IVideoService videoService)
        {
            _context = context;
            _videoService = videoService;
            
        }

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] Video video)
        {
            try
            {
                _videoService.post(video);
                return CreatedAtAction(nameof(RecupeVideoPorId), new {Id = video.Id}, video);

            }catch
            {

                return BadRequest();
            }
        }


        [HttpGet]
        public ICollection<Video> RecuperaVideos()
        {
            return _videoService.getAll();
        }


        [HttpGet("{id}")]
        public IActionResult RecupeVideoPorId(int id)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id );

            return video != null ? Ok(video) : NotFound(); 

        }

        [HttpGet("/busca")]
        public IEnumerable<Video> GetAllWithQuery([FromQuery] int n)
        {
            var videos = _context.Videos.Where(v => v.Titulo.Length < n).ToList();

            
            return videos;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            try{
                _videoService.Delete(id);
                return NoContent();

            }catch{

                return NotFound();
            }
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Video> novoVideo)
        {
            try
            {
                _videoService.patch(id, novoVideo);
                return Ok();
            } catch( NullReferenceException e ) 
            {
                return NotFound(e.Message);
            }catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }

            
        }

    }
}