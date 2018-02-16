using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Autostop.Services.Rides.Models
{
	public class RequestResponse
	{
		[JsonProperty("product_id")]
		public string ProductId { get; set; }

		[JsonProperty("request_id")]
		public string RequestId { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("surge_multiplier")]
		public long SurgeMultiplier { get; set; }

		[JsonProperty("shared")]
		public bool Shared { get; set; }

		[JsonProperty("driver")]
		public Driver Driver { get; set; }

		[JsonProperty("vehicle")]
		public Vehicle Vehicle { get; set; }

		[JsonProperty("location")]
		public DriverLocation Location { get; set; }

		[JsonProperty("pickup")]
		public Destination Pickup { get; set; }

		[JsonProperty("destination")]
		public Destination Destination { get; set; }

		[JsonProperty("waypoints")]
		public List<Waypoint> Waypoints { get; set; }

		[JsonProperty("riders")]
		public List<Rider> Riders { get; set; }
	}

	public class Destination
	{
		[JsonProperty("alias")]
		public string Alias { get; set; }

		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("eta")]
		public long Eta { get; set; }
	}

	public class Driver
	{
		[JsonProperty("phone_number")]
		public string PhoneNumber { get; set; }

		[JsonProperty("sms_number")]
		public string SmsNumber { get; set; }

		[JsonProperty("rating")]
		public long Rating { get; set; }

		[JsonProperty("picture_url")]
		public string PictureUrl { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class DriverLocation
	{
		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }

		[JsonProperty("bearing")]
		public long Bearing { get; set; }
	}

	public class Rider
	{
		[JsonProperty("rider_id")]
		public string RiderId { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("me")]
		public bool Me { get; set; }
	}

	public class Vehicle
	{
		[JsonProperty("make")]
		public string Make { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("license_plate")]
		public string LicensePlate { get; set; }

		[JsonProperty("picture_url")]
		public string PictureUrl { get; set; }
	}

	public class Waypoint
	{
		[JsonProperty("rider_id")]
		public string RiderId { get; set; }

		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("longitude")]
		public double Longitude { get; set; }
	}
}
