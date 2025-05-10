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
    public class ReportDefectHandler: ICommandHandler<Failures>
    {
        private readonly ITripReportRepository _tripReportRepository;

        public ReportDefectHandler(ITripReportRepository tripReportRepository)
        {
            _tripReportRepository = tripReportRepository;
        }

        public async Task HandleAsync(Failures command)
        {
            var foundTripReport = await _tripReportRepository.GetAsync(command.tripIdOrigin);
            if(foundTripReport == null)
            {
                throw new Exception("Trip report not found");
            }

            foreach(var fail in command.failures)
            {
                var defect = new Defect(fail.description, fail.severity, fail.carStop);
                foundTripReport.AddFailures(defect);
            }

            await _tripReportRepository.UpdateAsync(foundTripReport);


        }

      
    }
}
