using CarFleetIO.Application.Exceptions;
using CarFleetIO.Application.Services;
using CarFleetIO.Domain.Consts;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Commands.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserRepository _userRepository;
        
        private readonly IUserReadService _userReadService;

        public CreateUserHandler(IUserRepository userRepository, IUserReadService userReadService)
        {
            _userRepository = userRepository;
            _userReadService = userReadService;
        }

        

        public async Task HandleAsync(CreateUser command)
        {
            var (firstName, lastName) = command.name;
            var (userID, securityNumber, office, gender, isActive) = command.details;
            var (birth, hire) = command.dates;

            //Dane w formie 3 logicznie pogrupowanych obiektów przychodzą po stronie klienta (np. poprzez http). Tutaj 
            //"rozwijamy" je na zmienne lokalne

            if (await _userReadService.ExistsByUsername(userID) || await _userReadService.ExistsBySecurityNumber(securityNumber))
            {
                throw new UserAlreadyExistsException();
            }

            var newUser = User.Create(userID, securityNumber, office, gender, firstName, lastName, birth, hire);

            await _userRepository.AddAsync(newUser);
        }
    }
}
