using System;

namespace Funbit.Ets.Telemetry.Server.Data {
	public interface IEts2TelemetryData {
		/// <summary>
		/// Game information.
		/// </summary>
		IEts2Game Game { get; }

		/// <summary>
		/// Truck information.
		/// </summary>
		IEts2Truck Truck { get; }

		/// <summary>
		/// Trailer information.
		/// </summary>
		IEts2Trailer Trailer { get; }
	}

	public interface IEts2Game {
		/// <summary>
		/// Indicates whether the telemetry server is connected
		/// to the simulator (ETS) or not.
		/// </summary>
		bool Connected { get; }

		/// <summary>
		/// Current game time. 
		/// Serializes to ISO 8601 string in JSON.
		/// Example: "0001-01-05T05:11:00Z"
		/// </summary>
		DateTime Time { get; }
		/// <summary>
		/// True if game is currently paused, false otherwise.
		/// </summary>
		bool Paused { get; }
	}

	public interface IEts2Truck {
		/// <summary>
		/// Current level of the retarder brake.
		/// Ranges from 0 to RetarderStepCount.
		/// Example: 0
		/// </summary>
		int RetarderBrake { get; }
		/// <summary>
		/// Number of steps in the retarder.
		/// Set to zero if retarder is not mounted to the truck.
		/// Example: 3
		/// </summary>
		int RetarderStepCount { get; }

		/// <summary>
		/// Indicates whether cruise control is turned on or off. 
		/// </summary>
		bool CruiseControlOn { get; }
		/// <summary>
		/// Indicates whether wipers are currently turned on or off.
		/// </summary>
		bool WipersOn { get; }

		/// <summary>
		/// Is the parking brake enabled or not.
		/// </summary>
		bool ParkBrakeOn { get; }
		/// <summary>
		/// Is the motor brake enabled or not.
		/// </summary>
		bool MotorBrakeOn { get; }

		/// <summary>
		/// Is the engine enabled or not.
		/// </summary>
		bool EngineOn { get; }
		/// <summary>
		/// Is the electric enabled or not.
		/// </summary>
		bool ElectricOn { get; }

		/// <summary>
		/// Is left blinker currently turned on or off.
		/// </summary>
		bool BlinkerLeftOn { get; }
		/// <summary>
		/// Is right blinker currently turned on or off.
		/// </summary>
		bool BlinkerRightOn { get; }

		/// <summary>
		/// Are the parking lights enabled or not.
		/// </summary>
		bool LightsParkingOn { get; }
		/// <summary>
		/// Are the low beam lights enabled or not.
		/// </summary>
		bool LightsBeamLowOn { get; }
		/// <summary>
		/// Are the high beam lights enabled or not.
		/// </summary>
		bool LightsBeamHighOn { get; }
		/// <summary>
		/// Are the auxiliary front lights active or not.
		/// </summary>
		bool LightsAuxFrontOn { get; }
		/// <summary>
		/// Are the auxiliary roof lights active or not.
		/// </summary>
		bool LightsAuxRoofOn { get; }
		/// <summary>
		/// Are the beacon lights enabled or not.
		/// </summary>
		bool LightsBeaconOn { get; }
		/// <summary>
		/// Is the brake light active or not.
		/// </summary>
		bool LightsBrakeOn { get; }
		/// <summary>
		/// Is the reverse light active or not.
		/// </summary>
		bool LightsReverseOn { get; }

		/// <summary>
		/// Intensity of the dashboard backlight between 0 (off) and 1 (max).
		/// </summary>
		float LightsDashboardValue { get; }
		/// <summary>
		/// Is the dashboard backlight currently turned on or off.
		/// </summary>
		bool LightsDashboardOn { get; }
	}

	public interface IEts2Trailer {
		/// <summary>
		/// Id of the cargo for internal use by code.
		/// Example: "derrick"
		/// </summary>
		string Id { get; }
		/// <summary>
		/// Localized name of the current trailer for display purposes.
		/// Example: "Derrick"
		/// </summary>
		string Name { get; }
		/// <summary>
		/// Is the trailer attached to the truck or not.
		/// </summary>
		bool Attached { get; }
		/// <summary>
		/// Mass of the cargo in kilograms.
		/// Example: 22000
		/// </summary>
		float Mass { get; }
		/// <summary>
		/// Current level of trailer wear/damage between 0 (min) and 1 (max).
		/// Example: 0.0314717
		/// </summary>
		float Wear { get; }
	}
}