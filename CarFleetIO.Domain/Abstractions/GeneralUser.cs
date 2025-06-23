using CarFleetIO.Domain.Consts;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Exceptions;
using CarFleetIO.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarFleetIO.Shared.Abstractions.Domain
{
    public abstract class GeneralUser: AggregateRoot<Username>
    {
        public Username Id { get; private set; }
        public SecurityNumber? SecurityNumber;
        public string IdentityId { get; set; }
        public Guid? Office;
        private Gender? _gender;
        private string? _name;
        public string? _lastName;
        private DateOnly? _birthDate;
        private DateOnly? _hireDate;
        public bool? IsActive;

        public GeneralUser(Username userID, SecurityNumber securityNumber, Guid office, Gender gender,
            string name, string lastName, DateOnly birthDate, DateOnly hireDate, bool isActive = true)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new EmptyFirstNameException();
            }

            if (string.IsNullOrWhiteSpace(lastName)){
                throw new EmptyLastNameException();
            }

            if (hireDate < new DateOnly(1950, 1, 1) || hireDate > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                throw new IncorrectHireDateException();
            }

            if(birthDate < new DateOnly(1920, 1, 1) || birthDate > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                throw new IncorrectBirthDateException();
            }

            Id = userID;
            SecurityNumber = securityNumber;
            Office = office;
            _gender = gender;
            _name = name;
            _lastName = lastName;
            _birthDate = birthDate;
            _hireDate = hireDate;
            IsActive = isActive;
        }

        public GeneralUser()
        {

        }

        public GeneralUser(Username userID, string identityId)
        {
            Id = userID;
            IdentityId = identityId;
            IsActive = true;
        }

        public void Deactivate()
        {
            if(IsActive == false)
            {
                throw new UserAlreadyDeactivatedException();
            }

            this.IsActive = false;
        }

        public void Activate()
        {
            if(IsActive == true)
            {
                throw new UserAlreadyActiveException();
            }

            this.IsActive = true;
        }

        public void ChangeOffice(Guid newOffice)
        {
            if(newOffice == Office)
            {
                throw new NewOfficeSameAsOldException();
            }

            this.Office = newOffice;
        }

        public void ChangeLastName(string newLastName)
        {
            if (String.IsNullOrWhiteSpace(newLastName))
            {
                throw new ArgumentException("Empty last name");
            }

            this._lastName = newLastName;
        }


        }

 }

