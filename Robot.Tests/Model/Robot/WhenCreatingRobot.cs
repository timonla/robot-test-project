using FluentAssertions;
using Model;
using NUnit.Framework;

namespace WhenCreatingRobot {
    [TestFixture]
    public class Always {
        public Robot robot;

        [SetUp]
        public void Setup() {
            robot = new Robot();
        }

        [Test]
        public void ShouldBeTurnedOff() {
            robot.State.Should().Be(RobotState.Off);
        }
    }
}
