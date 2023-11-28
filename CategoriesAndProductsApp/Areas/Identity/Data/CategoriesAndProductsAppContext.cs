using CategoriesAndProductsApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CategoriesAndProductsApp.Data;

public class CategoriesAndProductsAppContext : IdentityDbContext<CategoriesAndProductsAppUser>
{
    public CategoriesAndProductsAppContext(DbContextOptions<CategoriesAndProductsAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }


}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<CategoriesAndProductsAppUser>
{
    public void Configure(EntityTypeBuilder<CategoriesAndProductsAppUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}

