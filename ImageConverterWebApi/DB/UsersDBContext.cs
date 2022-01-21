using ImageConverterWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageConverterWebApi.Services.DB;

public class UsersDBContext : DbContext
{
    private readonly string _connectionString;

    public UsersDBContext(DbContextOptions<UsersDBContext> options)
            : base(options)
    {
        Database.Migrate();
    }
    public DbSet<UserModel> Users { get; set; }
}
