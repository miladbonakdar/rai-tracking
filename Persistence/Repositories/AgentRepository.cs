using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Exceptions;

namespace Persistence.Repositories
{
    class AgentRepository : Repository<Agent>, IAgentRepository
    {
        public AgentRepository(DbContext context) : base(context)
        {
        }

        public Task<Agent> GetWithDepoAsync(Expression<Func<Agent, bool>> predicate)
        {
            return BaseQuery.Include(a => a.Depo).FirstOrDefaultAsync(predicate);
        }

        public async Task GuardForDuplicateEmailAddress(string email, int? currentItemId = null)
        {
            var isAny = currentItemId is null
                ? await DbSet.AnyAsync(d => d.Email == email)
                : await DbSet.AnyAsync(d => d.Email == email && d.Id != currentItemId);
            if (isAny) throw new BadRequestException("Email", "ایمیل تکراریست");
        }

        public async Task GuardForDuplicatePhoneNumber(string number, int? currentItemId = null)
        {
            var isAny = currentItemId is null
                ? await DbSet.AnyAsync(d => d.PhoneNumber == number)
                : await DbSet.AnyAsync(d => d.PhoneNumber == number && d.Id != currentItemId);
            if (isAny) throw new BadRequestException("PhoneNumber", "شماره تلفن همراه تکراریست");
        }
    }
}