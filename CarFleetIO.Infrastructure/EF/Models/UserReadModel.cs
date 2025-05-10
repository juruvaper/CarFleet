using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Infrastructure.EF.Models
{
    internal class UserReadModel
    {
        public string UserId { get; set; }
        public long SecurityNumber { get; set; }
        public Guid OfficeId { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly HireDate { get; set; }
        public bool IsActive { get; set; }


        //navigation props

        public virtual ICollection<CarReadModel> Cars { get; set; }

    }
    
}
