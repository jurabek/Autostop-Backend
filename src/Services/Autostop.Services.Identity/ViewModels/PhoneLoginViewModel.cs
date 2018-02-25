using Newtonsoft.Json;

namespace Autostop.Services.Identity.ViewModels
{
    public class PhoneLoginViewModel
    {
		[JsonProperty("phone")]
	    public string PhoneNumber { get; set; }
    }
}
