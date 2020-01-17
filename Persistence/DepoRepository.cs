using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    class DepoRepository : Repository<Depo>, IDepoRepository
    {
        public DepoRepository(DbContext context) : base(context)
        {
        }
    }
}