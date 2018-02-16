using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Autostop.Services.Rides.Models
{
    public class Location
    {
		[JsonProperty("lat")]
	    public float Lat { get; set; }

		[JsonProperty("lng")]
	    public float Lng { get; set; }

		[JsonProperty("address")]
	    public string Address { get; set; }
    }
}
