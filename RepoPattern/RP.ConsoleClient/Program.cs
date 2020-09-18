using RP.DataAccess.Model;
using RP.DataAccess.Persistence;
using RP.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RP.ConsoleClient
{
    class Program
    {
        private const bool SEEDREQUESTED = false;
        private const string CONNECTIONSTRING = @"Server=localhost\SQLEXPRESS;Database=RP;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            if (SEEDREQUESTED)
            {
                // Seed data

                var cars = new List<Car>
                {
                    new Car { Id = 1, Model = "FIAT BRANDA", Plate = "AA1111"},
                    new Car { Id = 2, Model = "OPEL CORTA", Plate = "AA2222" },
                    new Car { Id = 3, Model = "FORD FESTA", Plate = "AA3333" },
                    new Car { Id = 4, Model = "FIAT VIRGOLA", Plate = "AA4444" },
                    new Car { Id = 5, Model = "MASERATI MC30", Plate = "AA5555" },
                };

                var users = new List<User>
                {
                    new User { Id = 1, Name = "MARIO", Surname = "ROSSI",},
                    new User { Id = 2, Name = "LUCA", Surname = "BIANCHI",},
                    new User { Id = 3, Name = "ANDREA", Surname = "VERDI",},
                };

                var usersCars = new List<UserCar>
                {
                    new UserCar{ UserId = 1, CarId = 1 },
                    new UserCar{ UserId = 2, CarId = 4 },
                    new UserCar{ UserId = 1, CarId = 2 },
                    new UserCar{ UserId = 1, CarId = 3 },
                    new UserCar{ UserId = 3, CarId = 5 },
                    new UserCar{ UserId = 1, CarId = 4 },
                    new UserCar{ UserId = 1, CarId = 5 },
                    new UserCar{ UserId = 3, CarId = 2 },
                };

                using (UnitOfWork unitOfWork = new UnitOfWork(new RPContext(CONNECTIONSTRING)))
                {
                    foreach (User u in users)
                    {
                        unitOfWork.UserRepository.InsertAsync(u);
                    }
                    foreach (Car c in cars)
                    {
                        unitOfWork.CarRepository.InsertAsync(c);
                    }
                    foreach (UserCar us in usersCars)
                    {
                        unitOfWork.UserCarRepository.InsertAsync(us);
                    }

                    try
                    {
                        unitOfWork.Save();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            using (UnitOfWork unitOfWork = new UnitOfWork(new RPContext(CONNECTIONSTRING)))
            {
                var users = unitOfWork.UserRepository.SelectAllAsync().GetAwaiter().GetResult().ToList();
                var cars = unitOfWork.CarRepository.SelectAllAsync().GetAwaiter().GetResult().ToList();

                Console.WriteLine("**USERS**");
                users.ForEach(x => Console.WriteLine($"{x.Id}: {x.Name} {x.Surname}"));

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("**CARS**");
                cars.ForEach(x => Console.WriteLine($"{x.Id}: {x.Model}, {x.Plate}"));

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("**MOST CAR**");
                var top = unitOfWork.UserRepository.GetTopUserAsync().GetAwaiter().GetResult();
                Console.WriteLine($"{top.Id}: {top.Name} {top.Surname}");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("**CAR BY USER**");
                var allcars = unitOfWork.CarRepository.GetCarsByUserAsync(3).GetAwaiter().GetResult();
                foreach (Car c in allcars)
                {
                    Console.WriteLine($"{c.Id}: {c.Model} {c.Plate}");
                }
            }


            Console.WriteLine("Any key to close...");
            Console.ReadKey(true);
        }
    }
}
