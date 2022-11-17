using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechAX;

namespace TechAXTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestCalculator()
        {
            var cal = new Calculator();

            Assert.AreEqual(2.0, cal.Calculate("1 + 1"));
            Assert.AreEqual(4.0, cal.Calculate("2 * 2"));
            Assert.AreEqual(6.0, cal.Calculate("1 + 2 + 3"));
            Assert.AreEqual(3.0, cal.Calculate("6 / 2"));
            Assert.AreEqual(34.0, cal.Calculate("11 + 23"));
            Assert.AreEqual(34.1, cal.Calculate("11.1 + 23"));
            Assert.AreEqual(4.0, cal.Calculate("1 + 1 * 3"));

            Assert.AreEqual(37.0, cal.Calculate("( 11.5 + 15.4 ) + 10.1"));
            Assert.AreEqual(6.2, cal.Calculate("23 - ( 29.3 - 12.5 )"));
            Assert.AreEqual(0.5, cal.Calculate("( 1 / 2 ) - 1 + 1"));

            Assert.AreEqual(2, cal.Calculate("10 - ( 2 + 3 * ( 7 - 5 ) )"));
        }
    }
}
