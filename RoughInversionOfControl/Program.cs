// See https://aka.ms/new-console-template for more information
using RoughInversionOfControl;
using System.Text.Json;

Console.WriteLine("Hello, World!");

IUserDataAccess userDataAccess = DataAccessFactory.GetUserDataAccess();
User u1 = userDataAccess.GetUser(15);
Console.WriteLine(JsonSerializer.Serialize(u1));

Container container = new Container();
//container.Register<IUserDataAccess>(delegate { return new UserWsDataAccess(); });
container.Register<IUserDataAccess>((c) => new UserWsDataAccess());

container.Configuration["IoCActive"] = true;

if (container.GetConfiguration<bool>("IoCActive"))
{
    User u2 = container.Create<IUserDataAccess>().GetUser(18);
    Console.WriteLine(JsonSerializer.Serialize(u2));
}

Console.ReadLine();