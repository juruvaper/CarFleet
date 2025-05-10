using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.DTO
{
    public class LocalizationDTO
    {
        public Guid LocalizationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
