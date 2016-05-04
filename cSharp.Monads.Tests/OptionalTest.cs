using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cSharp.Monads;

namespace cSharp.Monads.Tests
{
    /// <summary>
    /// Summary description for OptionalTest
    /// </summary>
    [TestClass]
    public class OptionalTest
    {
        public OptionalTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void shouldReturnTrueForSomeValuePassed()
        {
            String s = "Priyanka";
            Optional<String> optionalString = s;

            Assert.AreEqual(true, optionalString.HasValue);
        }

        [TestMethod]
        public void shouldReturnFalseForNullValuePassed()
        {
            String s = null;
            Optional<String> optionalString = s;

            Assert.AreEqual(false, optionalString.HasValue);
        }

       
        [TestMethod]
        public void shouldReturnDefaultValueForNullPassedOnString()
        {
            String input = null;
            Optional<String> optionalString = input;
            String defaultValue = "IamDefault";
            Assert.AreEqual(defaultValue,optionalString.GetOrElse(defaultValue));
        }

        [TestMethod]
        public void shouldReturnDefaultValueForNullPassedOnClass()
        {
            TestInput input = null;
            Optional<TestInput> optionalString = input;
            TestInput defaultValue = new TestInput(0,"IamDefault");
            Assert.AreEqual(defaultValue, optionalString.GetOrElse(defaultValue));
        }

        [TestMethod]
        public void shouldReturnActualValueForValuePassedOnClass()
        {
            TestInput input = new TestInput(1,"HiIamThere");
            Optional<TestInput> optionalString = input;
            TestInput defaultValue = new TestInput(0, "IamDefault");
            Assert.AreEqual(input, optionalString.GetOrElse(defaultValue));
        }

        [TestMethod]
        public void shouldCallFunctionIfValueIsPresent()
        {
            int input = 2;
            Optional<int> optionalValue = input;
            optionalValue.IfPresent(CallMe<int>);
        }

        private void CallMe<T>(T value)
        {
            Assert.AreEqual(2, value);
        }

        public class TestInput
        {
            string name;
            int id;
            public TestInput(int id, string name)
            {
                this.name = name;
                this.id = id;
            }

            public override bool Equals(object obj)
            {
                if(obj == null)
                    return false;
                TestInput secondObject = (TestInput)obj;
                if (this.id == secondObject.id && this.name == secondObject.name)
                    return true;
                return false;
            }

        }
    }
}
