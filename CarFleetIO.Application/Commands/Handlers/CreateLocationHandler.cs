using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Commands.Handlers
{

    public class CreateLocationHandler: ICommandHandler<CreateLocation>
    {
        private readonly ILocalizationRepository _localizationRepository;

        public CreateLocationHandler(ILocalizationRepository localizationRepository)
        {
            _localizationRepository = localizationRepository;
        }

        public async Task HandleAsync(CreateLocation command)
        {
            var newLocation = Localization.Create(command.City, command.Country);

            await _localizationRepository.AddAsync(newLocation);

        }
    }
}
