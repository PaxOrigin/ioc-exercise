namespace DatabaseHandler.Configutarions;

using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfigurtation : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(x => x.Id)
            .HasName("PK_User");
        entity.ToTable("Users");
    }
}
