using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlScriptDevice;
using Funbit.Ets.Telemetry.Server.Data;
using GhostKeyboard;

namespace TruckSimBindings {
	class Binding {
		public string Flag;
		public string Device;
		public string Button;
		public string Key;
	}

	class Program {
		static void Main(string[] args) {
			var keyboard = new Keyboard();

			var bindings = new List<Binding> {
				new Binding {
					Flag = "ParkBrakeOn",
					Device = "DSD Race King",
					Button = "Buttons4",
					Key = "Space",
				},
				new Binding {
					Flag = "LightsBeaconOn",
					Device = "DSD Race King",
					Button = "Buttons5",
					Key = "O",
				},
			};

			var device = new Input("DSD Race King");
			device.ButtonChanged += (e2, a) => {
				var binding = bindings.Find(e => e.Button == a.Button);
				if (binding != null) {
					var telemetry = Ets2TelemetryDataReader.Instance.Read();
					var isPressed = a.Value != 0;
					var isFlagged = (bool)telemetry.Truck.GetType().GetProperty(binding.Flag).GetValue(telemetry.Truck);
					if (isPressed != isFlagged) {
						keyboard.PressKey(binding.Key);
						keyboard.ReleaseKey(binding.Key);
					}
				}
			};

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new TruckSimBindingsContext());
		}
	}
}
