using AluraChallenge.AluraDomain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace AluraChallenge.AluraService.Interfaces
{
    public interface IVideoService
    {
        void Delete(int id);
        
        void post(Video video); 

        void patch(int id, JsonPatchDocument<Video> novoVideo);

        ICollection<Video> getAll(string search);

        Video GetById(int id);
    }
}