using Moq;
using Phone.Action;
using Phone.Models;
using Phone.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Phone.Tests
{
    public class TestLibrary
    {
        public static IEnumerable<PhoneNumber> GetTestUsers()
        {
            PhoneNumber[] phones = new PhoneNumber[]
            {
                new PhoneNumber  { Id=1,Number = "3806666666" },
                new PhoneNumber  { Id=2,Number = "+3806666664" },
                new PhoneNumber  { Id=3,Number = "+(380)6666664"},
                new PhoneNumber  { Id=4,Number = "(380)6666764"}
            };
            IEnumerable<PhoneNumber> data = from p in phones
                                            orderby p.Id
                                            select p;
            return data;
        }
        public static TakeNumber CreateMock_AllUsers()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var moq = new TakeNumber(mock.Object);
            return moq;
        }
    }
}
