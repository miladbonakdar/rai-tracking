using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext context) : base(context)
        {
        }
    }
}