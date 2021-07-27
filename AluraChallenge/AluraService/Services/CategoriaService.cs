using AluraChallenge.AluraDomain.Entities;
using AluraChallenge.AluraService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge.AluraService.Services
{
    public class CategoriaService:ICategoriaService
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Categoria> getAll()
        {
            throw new NotImplementedException();
        }

        public void patch(int id, JsonPatchDocument<Categoria> categoria)
        {
            throw new NotImplementedException();
        }

        public void post(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
