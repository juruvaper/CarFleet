using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetIO.Domain.Entities
{
    public class Localization
    {
        public Guid LocalizationID { get; private set; }
        private string _city;
        private string _country;

        private Localization()
        {

        }
        private Localization( string city, string country)
        {
           
            if(String.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentNullException(nameof(city));
            }

            if (string.IsNullOrWhiteSpace(country))
            {
               throw new ArgumentNullException(nameof(country));
            }

           
            _city = city;
            _country = country;

        }

        private Localization(Guid id, string city, string country): this(city, country)
        {
            LocalizationID = id;
        }

       
        public static Localization Create( string city, string country)
        {
            return new Localization(city, country);
        }

        public static Localization Seed (Guid id, string city, string country)
        {
            return new Localization(id, city, country);
        }



    }
}
