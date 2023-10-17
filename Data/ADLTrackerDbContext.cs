using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ADLTracker.Data;

public class ADLTrackerDbContext : IdentityDbContext<IdentityUser>
{

}