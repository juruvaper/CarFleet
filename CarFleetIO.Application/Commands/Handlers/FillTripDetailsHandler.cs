using CarFleetIO.Domain.Repositories;
using CarFleetIO.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.Commands.Handlers
{
    public class FillTripDetailsHandler : ICommandHandler<FillTripDetails>
    {
        private readonly ITripReportRepository _tripReportRepository;

        public FillTripDetailsHandler(ITripReportRepository tripReportRepository)
        {
            _tripReportRepository = tripReportRepository;
        }

        public async Task HandleAsync(FillTripDetails command)
        {

            var foundTripReport = await _tripReportRepository.GetAsync(command.TripID);

            if (foundTripReport == null)
            {
                throw new Exception("TripID not found");
            }

            foundTripReport.FillTripInfo(command._distance, command._fuelConsumed);

            await _tripReportRepository.UpdateAsync(foundTripReport);
        }
    }
}
