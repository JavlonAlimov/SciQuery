using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SciQuery.Domain.User;

namespace SciQuery.Infrastructure.Persistance.DbContext;

public class SciQueryDbContext(DbContextOptions<SciQueryDbContext> options,
    IConfiguration configuration) : IdentityDbContext<User>(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
    }
}
