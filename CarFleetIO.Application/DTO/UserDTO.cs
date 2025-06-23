using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public long? SecurityNumber { get; set; }
        public Guid? Office { get; set; }
        public string? Gender { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateOnly? HireDate { get; set; }
        public bool? IsActive { get; set; }
        public IEnumerable<CarDTO>? Cars { get; set; }
    }
}
