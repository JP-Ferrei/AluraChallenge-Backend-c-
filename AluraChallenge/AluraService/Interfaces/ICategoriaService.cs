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
        void Delete(int id);

        void post(Categoria categoria);

        void patch(int id, JsonPatchDocument<Categoria> categoria);

        Categoria GetById(int id);

        ICollection<Categoria> GetAll();


    }
}
