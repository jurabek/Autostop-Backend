using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autostop.Services.Identity.ViewModels
{
    public class LoginViewModel
    {
		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
