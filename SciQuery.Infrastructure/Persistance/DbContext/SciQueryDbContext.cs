using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SciQuery.Domain.Entities;
using SciQuery.Domain.User;

namespace SciQuery.Infrastructure.Persistance.DbContext;

public class SciQueryDbContext(DbContextOptions<SciQueryDbContext> options,
    IConfiguration configuration) : IdentityDbContext<User>(options)
{
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Comment> Comment { get; set; }
    public virtual DbSet<Question> Question { get; set; }
    public virtual DbSet<Answer> Answer { get; set; }
    public virtual DbSet<Tag> Tag { get; set; }
    public virtual DbSet<Vote> Vote { get; set; }
    public virtual DbSet<ReputationChange> ReputationChange { get; set; }
    public virtual DbSet<QuestionTag> QuestionTag { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
    }
}
