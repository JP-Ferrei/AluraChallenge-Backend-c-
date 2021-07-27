using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if(video != null)
            {
                _context.Videos.Remove(video);
                _context.SaveChanges();

            }else{
                throw new NullReferenceException();
            }

        }

        public void post(Video video)
        { 
            
            if(video == null) throw new NullReferenceException();

            if (video.CategoriaId == 0) video.CategoriaId = 1;

             _context.Videos.Add(video);
            _context.SaveChanges();       
        }

        public void patch(int id, JsonPatchDocument<Video> novoVideo)
        {
            var video = _context.Videos.FirstOrDefault(v => v.Id == id);

            if(video == null) throw new NullReferenceException();

            novoVideo.ApplyTo(video);

            _context.SaveChanges();
            
        }

       
        public ICollection<Video> getAll()
        {
           return _context.Videos.ToList();
        }

     
    }
}