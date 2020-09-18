using System.Collections.Generic;

namespace RP.DataAccess.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        // One To Many Relationships
        //public ICollection<Car> Cars { get; set; }

        // Many To Many Relationships
        public ICollection<UserCar> Cars { get; set; }
    }
}
