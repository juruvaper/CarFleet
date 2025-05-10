using CarFleetIO.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.ValueObjects
{
    public record Defect
    {
        public string Description { get;private set; }
        public Severity _severity { get; private set; }
        public bool _carStop { get;private set; }

        public Defect(string description, Severity severity, bool carStop = false)
        {
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null");
            }

            Description = description;
            _severity = severity;
            _carStop = carStop;

        }
    }
}
