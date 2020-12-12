
using FluentAssertions;
using Model;
using NUnit.Framework;

namespace WhenCheckingCharge {
    [TestFixture]
    public class GivenBatteryHasPercentageGreaterZero {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(69)]
        [TestCase(100)]
        public void ShouldHaveCharge(int batteryPercentage) {
            var battery = new Battery(batteryPercentage);
            var actual = battery.HasCharge();
            actual.Should().BeTrue();
        }
    }

    [TestFixture]
    public class GivenBatteryHasPercentageAtMostZero {
        [TestCase(0)]
        [TestCase(-1)]
        public void ShouldNotHaveCharge(int batteryCharge) {
            var battery = new Battery(batteryCharge);
            var actual = battery.HasCharge();
            actual.Should().BeFalse();
        }
    }
}
