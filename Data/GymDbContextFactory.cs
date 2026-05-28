using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GymSystemAPI.Data;

public class GymDbContextFactory : IDesignTimeDbContextFactory<GymDbContext>
{
    public GymDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<GymDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=GymDB;User Id=sa;Password=Admin@123;TrustServerCertificate=True;"
        );

        return new GymDbContext(optionsBuilder.Options);
    }
}