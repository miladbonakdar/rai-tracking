using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class DepoRepository : Repository<Depo>, IDepoRepository
    {
        public DepoRepository(DbContext context) : base(context)
        {
        }
    }
}