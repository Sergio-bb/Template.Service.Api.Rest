using Microsoft.EntityFrameworkCore;
using Template.Service.Api.Rest.Domain.Model;

namespace Template.Service.Api.Rest.DrivenAdapter.SqlServer;

public class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<User> User { get; set; }
}