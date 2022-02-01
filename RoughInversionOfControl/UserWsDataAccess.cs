namespace RoughInversionOfControl
{
    internal class UserWsDataAccess : IUserDataAccess
    {
        public User GetUser(long id)
        {
            // sarebbe da prendere da un WS, ma lo metto hard-coded

            return new User
            {
                Id = id,
                Name = "user from API",
                Surname = "surname",
                Bithdate = DateTime.Now.AddYears(-30),
            };
        }
    }
}
