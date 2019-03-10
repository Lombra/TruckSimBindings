using System;
using System.Text;
using Funbit.Ets.Telemetry.Server.Data.Reader;

namespace Funbit.Ets.Telemetry.Server.Data {
	class Ets2TelemetryData : IEts2TelemetryData {
		Box<Ets2TelemetryStructure> _rawData;

		public void Update(Ets2TelemetryStructure rawData) {
			_rawData = new Box<Ets2TelemetryStructure>(rawData);
		}

		internal static DateTime SecondsToDate(int seconds) {
			if (seconds < 0) seconds = 0;
			return new DateTime((long)seconds * 10000000, DateTimeKind.Utc);
		}

		internal static DateTime MinutesToDate(int minutes) {
			return SecondsToDate(minutes * 60);
		}

		internal static string BytesToString(byte[] bytes) {
			if (bytes == null)
				return string.Empty;
			return Encoding.UTF8.GetString(bytes, 0, Array.FindIndex(bytes, b => b == 0));
		}

		public IEts2Game Game => new Ets2Game(_rawData);
		public IEts2Truck Truck => new Ets2Truck(_rawData);
		public IEts2Trailer Trailer => new Ets2Trailer(_rawData);
	}

	class Ets2Game : IEts2Game {
		readonly Box<Ets2TelemetryStructure> _rawData;

		public Ets2Game(Box<Ets2TelemetryStructure> rawData) {
			_rawData = rawData;
		}

		public bool Connected => _rawData.Struct.ets2_telemetry_plugin_revision != 0 &&
								 _rawData.Struct.timeAbsolute != 0;

		public bool Paused => _rawData.Struct.paused != 0;
		public DateTime Time => Ets2TelemetryData.MinutesToDate(_rawData.Struct.timeAbsolute);
	}

	class Ets2Truck : IEts2Truck {
		readonly Box<Ets2TelemetryStructure> _rawData;

		public Ets2Truck(Box<Ets2TelemetryStructure> rawData) {
			_rawData = rawData;
		}

		public bool CruiseControlOn => _rawData.Struct.cruiseControl != 0;

		public bool EngineOn => _rawData.Struct.engineEnabled != 0;
		public bool ElectricOn => _rawData.Struct.electricEnabled != 0;
		public bool WipersOn => _rawData.Struct.wipers != 0;
		public int RetarderBrake => _rawData.Struct.retarderBrake;
		public int RetarderStepCount => (int)_rawData.Struct.retarderStepCount;
		public bool ParkBrakeOn => _rawData.Struct.parkBrake != 0;
		public bool MotorBrakeOn => _rawData.Struct.motorBrake != 0;
		public float LightsDashboardValue => _rawData.Struct.lightsDashboard;
		public bool LightsDashboardOn => _rawData.Struct.lightsDashboard > 0;
		public bool BlinkerLeftOn => _rawData.Struct.blinkerLeftOn != 0;
		public bool BlinkerRightOn => _rawData.Struct.blinkerRightOn != 0;
		public bool LightsParkingOn => _rawData.Struct.lightsParking != 0;
		public bool LightsBeamLowOn => _rawData.Struct.lightsBeamLow != 0;
		public bool LightsBeamHighOn => _rawData.Struct.lightsBeamHigh != 0;
		public bool LightsAuxFrontOn => _rawData.Struct.lightsAuxFront != 0;
		public bool LightsAuxRoofOn => _rawData.Struct.lightsAuxRoof != 0;
		public bool LightsBeaconOn => _rawData.Struct.lightsBeacon != 0;
		public bool LightsBrakeOn => _rawData.Struct.lightsBrake != 0;
		public bool LightsReverseOn => _rawData.Struct.lightsReverse != 0;
	}

	class Ets2Trailer : IEts2Trailer {
		readonly Box<Ets2TelemetryStructure> _rawData;

		public Ets2Trailer(Box<Ets2TelemetryStructure> rawData) {
			_rawData = rawData;
		}

		public bool Attached => _rawData.Struct.trailer_attached != 0;
		public string Id => Ets2TelemetryData.BytesToString(_rawData.Struct.trailerId);
		public string Name => Ets2TelemetryData.BytesToString(_rawData.Struct.trailerName);

		/// <summary>
		/// Trailer mass in kilograms.
		/// </summary>
		public float Mass => _rawData.Struct.trailerMass;

		public float Wear => _rawData.Struct.wearTrailer;
	}

	class Box<T> where T : struct {
		public T Struct { get; set; }

		public Box(T @struct) {
			Struct = @struct;
		}
	}
}