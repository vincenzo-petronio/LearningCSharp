using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grpc.Service.DataAccess
{
    public class UserRepo : IUserRepo
    {
        private const string UppercaseLetters = "ABCDEFGHILMNOPQRSTUVZWXJ";
        private const string Numbers = "0123456789";
        private static Random RndGenerator = new Random(DateTime.Now.Millisecond);

        public UserRepo()
        {
        }

        private static string AlphaRandom(int numChar)
        {
            string alphaRandom = null;
            for (int i = 0; i < numChar; i++)
            {
                alphaRandom += UppercaseLetters.Substring(RndGenerator.Next(UppercaseLetters.Length), 1);
            }

            return alphaRandom;
        }

        private static string NumericRandom(int numChar)
        {
            string numberRandom = null;
            for (int i = 0; i < numChar; i++)
            {
                numberRandom += Numbers.Substring(RndGenerator.Next(Numbers.Length), 1);
            }

            return numberRandom;
        }

        Task<List<UserModel>> IUserRepo.GetUsersAsync()
        {
            List<UserModel> listUsers = new List<UserModel>();
            UserModel userModel;

            for (int i = 1; i <= 50; i++)
            {
                userModel = new UserModel
                {
                    Id = i,
                    Name = AlphaRandom(8),
                    Surname = AlphaRandom(10),
                    BirthDay = DateTime.Now.AddYears(-i),
                    CurrentAddress = AlphaRandom(15),
                    CurrentCap = NumericRandom(5),
                    CurrentCity = AlphaRandom(6),
                    Email = $"{AlphaRandom(6)}@email.eu",
                    Pec = $"{AlphaRandom(6)}@email.pec.eu",
                    Telephone = NumericRandom(10),
                };
                listUsers.Add(userModel);
            }

            return Task.FromResult(listUsers);
        }
    }
}
