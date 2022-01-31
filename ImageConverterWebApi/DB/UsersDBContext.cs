using ImageConverterWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageConverterWebApi.Services.DB;

public class UsersDBContext : DbContext
{

    public UsersDBContext(DbContextOptions<UsersDBContext> options)
            : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ImageModel> ImageModels { get; set; }
    public void AddImageToUserById(int userId, ImageModel imageModel)
    {
        UserModel? user = Users.FirstOrDefault(x => x.Id == userId);
        user?.ConvertedImages.Add(imageModel);
        SaveChanges();
    }
}
