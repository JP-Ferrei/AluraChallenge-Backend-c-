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
            var v = _context.Videos.Add(video);
            
            if(v == null) throw new NullReferenceException();

            _context.SaveChanges();       
        }

        public void patch(int id, JsonPatchDocument<Video> novoVideo)
        {
            var video = _context.Videos.FirstOrDefault(v => v.Id == id);

            if(video == null) throw new NullReferenceException();

            novoVideo.ApplyTo(video);

            _context.SaveChanges();
            
        }

       
        public ICollection<Video> getAll(string search)
        {
            var videos = search != null ? _context.Videos.Where(x => x.Titulo.Contains(search)).ToList() : _context.Videos.ToList();

            if( videos == null )
                throw new NullReferenceException();

            return videos;
        }

        public Video GetById(int id)
        {
            var video = _context.Videos.FirstOrDefault(video => video.Id == id);

            if( video == null )
                throw new NullReferenceException();

            return video;
        }
     
    }
}