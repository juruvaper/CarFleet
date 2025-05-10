using CarFleetIO.Domain.Consts;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Entities
{
    public class User : GeneralUser
    {
        private User(): base()
        {

        }

        private User(Username userID,
                    SecurityNumber securityNumber,
                    Guid office,
                    Gender gender,
                    string name,
                    string lastName,
                    DateOnly birthDate,
                    DateOnly hireDate,
                    bool isActive = true) :
            base(userID, securityNumber, office, gender, name, lastName, birthDate, hireDate, isActive)
        {
        }


        public static User Create (Username userID,
                    SecurityNumber securityNumber,
                    Guid office,
                    Gender gender,
                    string name,
                    string lastName,
                    DateOnly birthDate,
                    DateOnly hireDate,
                    bool isActive = true)
        {
            return new User(userID, securityNumber, office, gender, name, lastName, birthDate, hireDate, isActive);
        }

    }
}
