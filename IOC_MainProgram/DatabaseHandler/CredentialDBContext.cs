namespace DatabaseHandler;

using DatabaseHandler.Configutarions;
using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;

public class CredentialDBContext : DbContext
{
    private readonly string _connectionString = null!;

    public CredentialDBContext(DbContextOptions<CredentialDBContext> options) : base(options)
    {
        //_connectionString = connectionString;
    }

    public virtual DbSet<User> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfigurtation());
    }
}