using System;
using Xunit;
using Runblade.Negotiator.Simulations;
using static Runblade.Negotiator.Simulations.SimulatedDevice;

namespace Runblade.Negotiator.Simulations.Tests
{
    public class UnitTestGeneric
    {
        //Test cryptography
        [Theory]
        [InlineData("AA-BB-CC-DD-EE","FF-GG-HH-II-JJ")]
        public void TestCryptography(string a, string b)
        {
            //This should hash correctly
            Assert.Equal(SimulateCryptography(a),"CkRhoslq/LX6V9//PHoAKNXi2JfJ/QNPfrXOFMXTEjk=");
            //This should fail miserably
            Assert.Equal(SimulateCryptography(b),"NOT_THE_CORRECT_HASH!");
        }

        //Test instantiation
        [Fact]
        public void TestInstantiation()
        {
            Assert.NotNull(new SimulatedDevice());
        }

        //Test DEVICE simulation
        [Fact]
        public void TestDevice()
        {
            Assert.NotNull(SendDevicesToCloudNonAsync(0));
        }

        //Test PLACEMENT simulation
        [Fact]
        public void TestPlacement()
        {
            //Test the instantiation...
            Assert.NotNull(SendPlacementsToCloudNonAsync(0));
        }

        //Test CREATIVE simulation
        [Fact]
        public void TestCreative()
        {
            Assert.NotNull(SendCreativesToCloudNonAsync(0));
        }
    }
}