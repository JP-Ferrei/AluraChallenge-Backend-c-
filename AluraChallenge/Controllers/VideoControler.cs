using System;
using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AluraChallenge.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> AdicionaVideo([FromBody] Video video)
        {
            try
            {
                await _service.Post(video);
                return CreatedAtAction(nameof(RecupeVideoPorId), new { Id = video.Id }, video);

            } catch( Exception e )
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> RecuperaVideos(string search)
        {
            try
            {
                var videos = await _service.getAll(search);
                return Ok(videos);

            }catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> RecupeVideoPorId(int id)
        {
            try
            {
                var video = await _service.GetById(id);
                return Ok(video);
            } catch( NullReferenceException e )
            {
                return NotFound(e.Message);
            } catch( Exception e )
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("/busca")]
        public IEnumerable<Video> GetAllWithQuery([FromQuery] int n)
        {
            var videos =  _context.Videos.Where(v => v.Titulo.Length < n).ToList();

            
            return videos;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaVideo(int id)
        {
            try
            {
                await _service.Delete(id);
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
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Video> novoVideo)
        {
            try
            {
                await _service.Patch(id, novoVideo);
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