using NUnit.Framework;
using Model;
using FluentAssertions;
using Telerik.JustMock;

namespace WhenTogglingPower {
    public class WhenTogglingPower {
        public Robot robot;

        public void Act() {
            robot.TogglePower();
        }
    }

    [TestFixture]
    public class GivenRobotIsTurnedOff : WhenTogglingPower {
        [SetUp]
        public virtual void Setup() {
            robot = new Robot();
            robot.State = RobotState.Off;
        }

        public class BatteryHasCharge : GivenRobotIsTurnedOff {
            [SetUp]
            public override void Setup() {
                base.Setup();
                var powerSource = Mock.Create<PowerSource>();
                Mock.Arrange(() => powerSource.HasCharge()).Returns(true);
                robot.PowerSource = powerSource;
            }

            [Test]
            public void ShouldTurnOn() {
                Act();
                robot.State.Should().Be(RobotState.On);
            }
        }

        public class BatteryHasNoCharge : GivenRobotIsTurnedOff {
            [SetUp]
            public override void Setup() {
                base.Setup();
                var powerSource = Mock.Create<PowerSource>();
                Mock.Arrange(() => powerSource.HasCharge()).Returns(false);
                robot.PowerSource = powerSource;
            }

            [Test]
            public void ShouldRemainOff() {
                Act();
                robot.State.Should().Be(RobotState.Off);
            }
        }
    }

    [TestFixture]
    public class GivenRobotIsTurnedOn : WhenTogglingPower {
        [SetUp]
        public void Setup() {
            robot = new Robot();
            robot.State = RobotState.On;
        }

        [Test]
        public void ShouldTurnOff() {
            Act();
            robot.State.Should().Be(RobotState.Off);
        }
    }
}