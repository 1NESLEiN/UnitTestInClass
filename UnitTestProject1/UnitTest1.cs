using System;
//using ClassLibrary1;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    

    [TestClass]
    public class UnitTest1
    {
        private ClassLibrary1.Person _p;

        [TestInitialize]
        public void BeginTest()
        {
            _p = new Person("Peter", 21, "xxxxxx-xxxx");
        }

        [TestMethod]
        public void TestAdult()
        {
            // Under 18 should return false
            _p.Age = 17.99;
            bool result = _p.isAdult();
            Assert.IsFalse(result);

            // Equal to 18 should return true
            _p.Age = 18.00;
            result = _p.isAdult();
            Assert.IsTrue(result);

            // Over 18 should return true
            _p.Age = 18.01;
            result = _p.isAdult();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEquality()
        {
            // Person 1 is initialized
            Person p = new Person("Peter", 21, "xxxxxx-xxxx");

            // Person 2 is initialized
            Person otherPerson = new Person("Peter", 21, "xxxxxx-xxxx");

            //p.Equals(otherPerson);

            // Test if these two persons are identical
            Assert.AreEqual(p, otherPerson);
        }

        [TestMethod]
        public void TestInequality()
        {
            // Person 1 is initialized
            Person p = new Person("Peter", 21, "xxxxxx-xxxx");

            // Person 2 is initialized
            Person otherPerson = new Person("Martin", 21, "xxxxxx-xxxx");

            //p.Equals(otherPerson);

            // Test if these two persons are identical
            Assert.AreNotEqual(p, otherPerson);
        }

        [TestMethod]
        public void AgeException()
        {
            Person p = new Person("Peter", 21, "xxxxxx-xxxx");

            try
            {
                p.Age = -21;
                Assert.Fail();
            }
            catch (AgeException ageException)
            {
                Assert.AreEqual("Alder for lav!", ageException.Message);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}