using Newtonsoft.Json;

namespace Autostop.Services.Identity.ViewModels
{
    public class LoginViewModel
    {
		[JsonProperty("phone")]
		public string PhoneNumber { get; set; }
	}
}
