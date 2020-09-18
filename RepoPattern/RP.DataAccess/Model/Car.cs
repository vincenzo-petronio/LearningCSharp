using System.Collections.Generic;

namespace RP.DataAccess.Model
{
    public class Car
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Plate { get; set; }

        // One To Many Relationships
        //public User User { get; set; }

        // Many To Many Relationships
        public ICollection<UserCar> Users { get; set; }
    }
}
