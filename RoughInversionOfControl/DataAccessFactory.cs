namespace RoughInversionOfControl
{
    internal class DataAccessFactory
    {
        public static IUserDataAccess GetUserDataAccess()
        {
            return new UserWsDataAccess();
        }
    }
}
