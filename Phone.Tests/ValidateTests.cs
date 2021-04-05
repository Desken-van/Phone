using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static Phone.Tests.TestLibrary;
namespace Phone.Tests
{
    public class ValidateTests
    {
        [Fact]
        public void ValidateNumber_Number()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            string text = "+380683636369";
            //act
            bool result = moq.Validate(text);
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void ValidateNumber_String()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            string text = "dfdf3806666666sfsfsfweef+3806666664sdffsfwew+(380)6666664efefefefw(380)6666764";
            //act
            IEnumerator<PhoneNumber> actual = moq.Take(text).GetEnumerator();
            while (actual.MoveNext())
            {
                //assert
                bool result = moq.Validate(actual.Current.Number);
                Assert.True(result);
            }
        }
        [Fact]
        public void Validate_False()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            string text = "sccsfssvscs";
            //act
            bool result = moq.Validate(text);
            // Assert
            Assert.False(result);
        }
    }
}
