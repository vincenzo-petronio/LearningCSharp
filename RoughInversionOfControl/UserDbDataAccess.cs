namespace RoughInversionOfControl
{
    internal class UserDbDataAccess : IUserDataAccess
    {
        public User GetUser(long id)
        {
            // sarebbe da prendere su DB, ma lo metto hard-coded

            return new User
            {
                Id = id,
                Name = "user from db",
                Surname = "surname",
                Bithdate = DateTime.Now.AddYears(-20),
            };
        }
    }
}
