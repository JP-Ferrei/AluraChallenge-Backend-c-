using AluraChallenge.AluraDomain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge.AluraService.Interfaces
{
    public interface ICategoriaService 
    {
        Task Delete(int id);

        Task Post(Categoria categoria);

        Task Patch(int id, JsonPatchDocument<Categoria> categoria);

        Task<Categoria> GetById(int id);

        Task<List<Categoria>> GetAll();


    }
}
