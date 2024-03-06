using System;
using Xunit;


namespace TestUnit
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, 2 + 2);
        }


       
    }
}
