﻿using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SharedKernel.Exceptions;

namespace Persistence.Repositories
{
    class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext context,ILogger logger) : base(context,logger)
        {
        }

        public async Task GuardForDuplicateEmailAddress(string email, int? currentItemId = null)
        {
            var isAny = currentItemId is null
                ? await DbSet.AnyAsync(d => d.Email == email)
                : await DbSet.AnyAsync(d => d.Email == email && d.Id != currentItemId);
            if (isAny) throw new BadRequestException("Email", "ایمیل تکراریست");
        }
    }
}