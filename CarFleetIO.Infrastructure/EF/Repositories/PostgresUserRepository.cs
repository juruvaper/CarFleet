using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Repositories
{
    internal class PostgresUserRepository : IUserRepository
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly DbSet<User> _users;

        public PostgresUserRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _users = _writeDbContext.Users;
        }


        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _writeDbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Username id)
        {
            return await _users.FirstOrDefaultAsync(u => u.Id == id.Value);
        }

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
