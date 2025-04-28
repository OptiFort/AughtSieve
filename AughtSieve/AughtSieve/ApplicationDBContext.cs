using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AughtSieve.Server;

public class ApplicationDbContext<TUser>(DbContextOptions<ApplicationDbContext<TUser>> options) : IdentityDbContext<TUser>(options)
    where TUser : IdentityUser
{

}
