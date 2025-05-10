using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Application.DTO
{
    public class UserDTO
    {
        public string UserId;
        public long SecurityNumber;
        public Guid OfficeId;
        public string Gender;
        public string Name;
        public string LastName;
        public DateOnly BirthDate;
        public DateOnly HireDate;
        public bool IsActive;
        public IEnumerable<CarDTO> Cars;
    }
}
