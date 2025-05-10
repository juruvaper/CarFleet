using CarFleetIO.Domain.Repositories;
using CarFleetIO.Shared.Abstractions.Commands;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Commands.Handlers
{
    public sealed class ChangeLastNameHandler: ICommandHandler<ChangeLastName>
    {
        private readonly IUserRepository _userRepository;

        public ChangeLastNameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(ChangeLastName command)
        {
            var foundUser = await _userRepository.GetAsync(command.username);

            if (foundUser != null)
            {
                foundUser.ChangeLastName(command.newLastName);
            }

            await _userRepository.UpdateAsync(foundUser);
        }
    }
}
