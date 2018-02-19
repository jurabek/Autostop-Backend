using Autostop.Services.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Autostop.Services.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
