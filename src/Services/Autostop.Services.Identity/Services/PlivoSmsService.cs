using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autostop.Services.Identity.Abstraction.Services;

namespace Autostop.Services.Identity.Services
{
    public class PlivoSmsService : ISmsService
    {
	    public Task<bool> SendAsync(string phoneNumber, string body)
	    {
		    throw new NotImplementedException();
	    }
    }
}
