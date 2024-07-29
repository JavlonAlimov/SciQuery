using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SciQuery.Domain.Answer;
using SciQuery.Domain.Question;
using SciQuery.Domain.User;

namespace SciQuery.Infrastructure.Persistance.DbContext;

public class SciQueryDbContext(DbContextOptions<SciQueryDbContext> options,
    IConfiguration configuration) : IdentityDbContext<User>(options)
{
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Question> Products { get; set; }
    public virtual DbSet<Answer> Answers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
}
