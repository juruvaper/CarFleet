using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Models
{
    internal class LocalizationReadModel
    {
        public Guid LocalizationId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
