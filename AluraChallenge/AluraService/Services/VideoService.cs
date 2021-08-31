using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraRepository.Context;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenge.AluraService.Services
{
    public class VideoService : IVideoService
    {
        private AluraContext _context ;

        public VideoService(AluraContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(video => video.Id == id);

            if(video != null)
            {
                var videos = await _context.Videos.ToListAsync();
                videos.Remove(video);
                await _context.SaveChangesAsync();

            } else{
                throw new NullReferenceException("Não possuimos um video com esse id");
            }

        }

        public async Task Post(Video video)
        { 
            
            if(video == null) throw new NullReferenceException();

            if (video.CategoriaId == 0) video.CategoriaId = 1;

            var videos = await _context.Videos.ToListAsync();
            videos.Add(video);

            await _context.SaveChangesAsync();
        }

        public async Task Patch(int id, JsonPatchDocument<Video> novoVideo)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(v => v.Id == id);

            if(video == null) throw new NullReferenceException();

            novoVideo.ApplyTo(video);

            await _context.SaveChangesAsync();
            
        }

       
        public async Task<ICollection<Video>> getAll(string search)
        {
            var videos =  search != null ? await _context.Videos.Where(x => x.Titulo.Contains(search)).ToListAsync() : await _context.Videos.ToListAsync();

            if( videos == null )
                throw new NullReferenceException();

            return videos;
        }

        public async Task<Video> GetById(int id)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(video => video.Id == id);

            if( video == null )
                throw new NullReferenceException();

            return video;
        }
     
    }
}