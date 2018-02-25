using System.Threading.Tasks;
using Autostop.Services.Identity.Abstraction.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Autostop.Services.Identity.Services
{
    public class TwilioSmsService : ISmsService
    {
	    public TwilioSmsService()
	    {
		    var accountSid = "AC519193fa0b9995e19080d78512427093";
		    var authToken = "fda03fb58da19c5660a240197b808b2c";
		    TwilioClient.Init(accountSid, authToken);
		}

	    public async Task<bool> SendAsync(string phoneNumber, string body)
	    {
		    var message = await MessageResource.CreateAsync(
			    to: phoneNumber,
			    body: body);

		    return message.Status != MessageResource.StatusEnum.Failed;
	    }
    }
}
