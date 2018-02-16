using Newtonsoft.Json;

namespace Autostop.Services.Rides.Models
{
    public class RequestBody
    {
		[JsonProperty("origin")]
	    public Location Origin { get; set; }

		[JsonProperty("destination")]
	    public Location Destination { get; set; }

		[JsonProperty("product_id")]
	    public string ProductId { get; set; }	
    }
}
