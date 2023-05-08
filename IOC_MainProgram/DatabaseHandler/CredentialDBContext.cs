namespace DatabaseHandler;

using DatabaseHandler.Configutarions;
using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;

public class CredentialDBContext : DbContext
{

    public CredentialDBContext(DbContextOptions<CredentialDBContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfigurtation());
    }
}