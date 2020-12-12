using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class Battery : PowerSource {
        public int BatteryPercentage { get; set; }

        public Battery(int batteryPercentage) {
            BatteryPercentage = batteryPercentage;
        }

        public Boolean HasCharge() {
            return BatteryPercentage > 0;
        }
    }
}
