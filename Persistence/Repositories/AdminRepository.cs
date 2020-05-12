using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SharedKernel.Exceptions;

namespace Persistence.Repositories
{
    class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task GuardForDuplicateEmailAddress(string email, int? currentItemId = null)
        {
            var isAny = currentItemId is null
                ? await DbSet.AnyAsync(d => d.Email == email)
                : await DbSet.AnyAsync(d => d.Email == email && d.Id != currentItemId);
            if (isAny) throw new BadRequestException("Email", "ایمیل تکراریست");
        }

        public Task<AdminProfileDto> GetUserProfile(int id)
        {
            return DbSet.Where(a => a.Id == id).Select(a => new AdminProfileDto
            {
                Admin = new AdminDto
                {
                    About = a.About,
                    Email = a.Email,
                    Id = a.Id,
                    Lastname = a.PersonName.Lastname,
                    Name = a.PersonName.Firstname,
                    Number = a.Telephone,
                    AdminType = a.AdminType,
                    OrganizationId = a.OrganizationId,
                    PhoneNumber = a.PhoneNumber
                },
                MissionsCount = a.Missions.Count
            }).FirstOrDefaultAsync();
        }
    }
}