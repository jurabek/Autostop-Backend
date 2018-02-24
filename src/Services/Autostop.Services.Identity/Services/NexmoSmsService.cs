using Autostop.Services.Identity.Abstraction.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace Autostop.Services.Identity.Services
{
	public class NexmoSmsService : ISmsService
	{
		private readonly HttpClient _client;
		private static string BaseUri => "https://rest.nexmo.com/sms/json";

		public NexmoSmsService()
		{
			_client = new HttpClient();
		}

		public async Task<bool> SendAsync(string phoneNumber, string body)
		{
			var uri = QueryHelpers.AddQueryString(BaseUri, new Dictionary<string, string>
			{
				{ "api_key", "a94e4d3a" },
				{ "api_secret", "lwsFRLieCQ5QkJJx" }
			});

			var requestBody = new Dictionary<string, string>
			{
				{ "to", phoneNumber },
				{ "from", "Autostop" },
				{ "text", body }
			};

			var req = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new FormUrlEncodedContent(requestBody) };
			var result = await _client.SendAsync(req);
			return result.IsSuccessStatusCode;
		}
	}
}
