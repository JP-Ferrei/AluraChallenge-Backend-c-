using AluraChallenge.AluraDomain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraChallenge.AluraService.Interfaces
{
    public interface IVideoService
    {
        Task Delete(int id);
        
        Task Post(Video video); 

        Task Patch(int id, JsonPatchDocument<Video> novoVideo);

        Task<ICollection<Video>> getAll(string search);

        Task<Video> GetById(int id);
    }
}