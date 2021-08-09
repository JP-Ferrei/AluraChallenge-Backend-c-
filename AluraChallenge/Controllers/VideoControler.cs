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
    public class VideoController:ControllerBase
    {
        private AluraContext _context;
        private IVideoService _service;

        public VideoController(AluraContext context, IVideoService videoService)
        {
            _context = context;
            _service = videoService;

        }

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] Video video)
        {
            try
            {
                _service.post(video);
                return CreatedAtAction(nameof(RecupeVideoPorId), new { Id = video.Id }, video);

            } catch( Exception e )
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public IActionResult RecuperaVideos(string search)
        {
            try
            {
                var videos = _service.getAll(search);
                return Ok(videos);

            }catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult RecupeVideoPorId(int id)
        {
            try
            {
                var video = _service.GetById(id);
                return Ok(video);
            } catch( NullReferenceException e )
            {
                return NotFound(e.Message);
            } catch( Exception e )
            {
                return StatusCode(500, e.Message);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();

            } catch( NullReferenceException e )
            {

                return NotFound(e.Message);
            } catch( Exception e )
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Video> novoVideo)
        {
            try
            {
                _service.patch(id, novoVideo);
                return Ok();
            } catch( NullReferenceException e )
            {
                return NotFound(e.Message);
            } catch( Exception e )
            {
                return StatusCode(500, e.Message);
            }


        }
/*
        [HttpGet("{search}")]
        public IActionResult VideosPorParametro([FromQuery] string search)
        {
            try
            {
                
                return Ok(videos);

            }catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }
        } 
*/
    }
}