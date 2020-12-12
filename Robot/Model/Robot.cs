using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public enum RobotState {
        Off,
        On,
    }

    public class Robot {
        public RobotState State { get; set; }
        public PowerSource PowerSource { get; set; }

        public Robot() {
            State = RobotState.Off;
        }

        public void TogglePower() {
            if (PowerSource == null) {
                State = RobotState.Off;
                return;
            }

            if (!PowerSource.HasCharge()) {
                State = RobotState.Off;
                return;
            }

            State = State == RobotState.Off ? RobotState.On : RobotState.Off;
        }
    }
}
