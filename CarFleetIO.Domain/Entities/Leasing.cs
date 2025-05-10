using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Entities
{
    public class Leasing: AggregateRoot<Guid>
    {
        public Guid LeaseId { get; private set; }
        public Username PersonResponsibleId { get; private set; }
        private DateOnly _startDate;
        private DateOnly _endDate;


        private Leasing()
        {

        }

        private Leasing(Guid leaseId, Username personResponsible, DateOnly startDate, DateOnly endDate)
        {
            LeaseId = leaseId;
            PersonResponsibleId = personResponsible;
            _startDate = startDate;
            _endDate = endDate;
        }

        public static Leasing Create(Guid leaseId, Username personResponsible, DateOnly startDate, DateOnly endDate)
        {
            return new Leasing(leaseId, personResponsible, startDate, endDate);
        }

        public override string ToString()
        {
            return $"{LeaseId} | {PersonResponsibleId}";
        }
    }
}
