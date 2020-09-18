namespace RP.DataAccess.Model
{
    /// <summary>
    /// Rappresenta la join table per identificare la relazione N-M tra User e Car.
    /// </summary>
    public class UserCar
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
