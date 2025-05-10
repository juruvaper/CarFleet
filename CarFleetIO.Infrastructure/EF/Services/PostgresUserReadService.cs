using CarFleetIO.Application.Services;
using CarFleetIO.Infrastructure.EF.Contexts;
using CarFleetIO.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Services
{
    internal class PostgresUserReadService : IUserReadService
    {

        private readonly DbSet<UserReadModel> _users;


        public PostgresUserReadService(ReadDbContext readDbContext)
        {
            _users = readDbContext.Users;
        }


        public Task<bool> ExistsBySecurityNumber(long securityNumber)
        {
            return _users.AnyAsync(u => u.SecurityNumber == securityNumber);
        }

        public Task<bool> ExistsByUsername(string username)
        {
            return _users.AnyAsync(u => u.UserId == username);
        }
    }
}
