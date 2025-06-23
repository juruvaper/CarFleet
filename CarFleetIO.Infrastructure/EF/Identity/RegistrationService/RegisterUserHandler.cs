using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Application.Services;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Infrastructure.EF.Identity;
using CarFleetIO.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

namespace CarFleetIO.Infrastructure.EF.Identity
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        IUserReadService _userReadService;
        IUserRepository _userRepository;
        UserManager<UserIdentity> _userManager;

        public RegisterUserHandler(IUserReadService userReadService, IUserRepository userRepository, UserManager<UserIdentity> userManager)
        {
            _userReadService = userReadService;
            _userRepository = userRepository;
            _userManager = userManager;
            
        }

        public async Task HandleAsync(RegisterUser command)
        {
            if (await _userReadService.ExistsByUsername(command.username)){

                throw new Exception("This username already exists");

            }

            var identityUser = new UserIdentity
            {
                Id = Guid.NewGuid().ToString(),
                Email = command.email,
                UserName = command.username

            };

            var identityResult = await _userManager.CreateAsync(identityUser, command.password);
            if (!identityResult.Succeeded)
            {
                var errors = string.Join("; ", identityResult.Errors.Select(e => e.Description));
                throw new Exception($"User creation failed with errors: { errors }");
            }

            var domainUser = User.CreateMinimal(command.username, identityUser.Id);

            await _userRepository.AddAsync(domainUser);

        }
    }
}
