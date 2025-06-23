using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Shared.Abstractions.Commands;

namespace CarFleetIO.Application.Commands.Handlers
{
    public sealed class ActivateUserHandler : ICommandHandler<ActivateUser>
    {
        private readonly IUserRepository _userRepository;

        public ActivateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(ActivateUser command)
        {
            User user = await _userRepository.GetAsync(command.username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Activate();

            await _userRepository.UpdateAsync(user);
        }
    }
}
