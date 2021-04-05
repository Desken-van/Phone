using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Phone.Models;
using System.Linq;
using Phone.Action;
using Phone.Repository;
using Moq;
using System.Web.Mvc;
using Xunit.Sdk;
using FakeItEasy;
using static Phone.Tests.TestLibrary;

namespace Phone.Tests
{
    public class NumberTests
    {    
        [Fact]
        public void CheckNotNull_Text()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            string text = "dfdf3806666666sfsfsfweef+3806666664sdffsfwew+(380)6666664efefefefw(380)6666764";
            //act
            IEnumerable<PhoneNumber> result = moq.Take(text);
            //assert
            Assert.NotNull(result);
        }
        [Fact]
        public void CheckCount_Text()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            string text = "dfdf3806666666sfsfsfweef+3806666664sdffsfwew+(380)6666664efefefefw(380)6666764";
            //act
            IEnumerable<PhoneNumber> result = moq.Take(text);
            // Assert
            Assert.Equal(GetTestUsers().Count(), result.Count());
        }
        [Fact]
        public void AssingTakeClass_Text()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            string text = "dfdf3806666666sfsfsfweef+3806666664sdffsfwew+(380)6666664efefefefw(380)6666764";
            //act
            var result = moq.Take(text);
            // Assert
            Assert.IsAssignableFrom<IEnumerable<PhoneNumber>>(result);
        }
        [Fact]
        public void EqualExpectedEqual()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            string text = "dfdf3806666666sfsfsfweef+3806666664sdffsfwew+(380)6666664efefefefw(380)6666764";
            //act            
            IEnumerable<PhoneNumber> result = moq.Take(text);  
            //Assert.Equal(GetTestUsers(), viewResult);
            //Assert.True(GetTestUsers().SequenceEqual(result));
            //NUnit.Framework.CollectionAssert.AreEquivalent(GetTestUsers(), viewResult);
            IEnumerator<PhoneNumber> expected = GetTestUsers().GetEnumerator();
            IEnumerator<PhoneNumber> actual = result.GetEnumerator();            
            while (expected.MoveNext() && actual.MoveNext())
            {
                //assert
                Assert.Equal(expected.Current.Id, actual.Current.Id);
                Assert.Equal(expected.Current.Number, actual.Current.Number);
            }
        }      
    }
}
