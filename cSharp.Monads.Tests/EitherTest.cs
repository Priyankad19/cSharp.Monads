using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monads.NET;

namespace Monads.Net.Tests
{
    [TestClass]
    public class EitherTest
    {
        [TestMethod]
        public void shouldApplyLeftMethodIfLeftValueIsPassed()
        {
            Either<String, String> either = Either<String, String>.Left("IamLeft");
            either.Apply(LeftFunction, RightFunction);               
        }

        [TestMethod]
        public void shouldApplyRightMethodIfRightValueIsPassed()
        {
            Either<String, String> either = Either<String, String>.Right("IamRight");
            either.Apply(LeftFunction, RightFunction);
        }

        private void LeftFunction(string leftValue)
        {
            String expectedLeftValue = "IamLeft";
            Assert.AreEqual(expectedLeftValue, leftValue);
        }

        private void RightFunction(string rightValue)
        {
            String expectedRightValue = "IamRight";
            Assert.AreEqual(expectedRightValue, rightValue);
        }
    }
}
