using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraChallenge.AluraRepository.Repositories.Shared
{
    class BaseRepository<TContext> where TContext : DbContext
    {
        protected TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }
    }
}
