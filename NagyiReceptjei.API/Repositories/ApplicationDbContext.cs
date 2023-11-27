using Microsoft.EntityFrameworkCore;
using NagyiReceptjei.API.Models;

namespace NagyiReceptjei.API.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Photo> Photos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
            .Property(comment => comment.RecipeId)
            .HasColumnName("recipe_id");
        modelBuilder.Entity<Comment>()
            .Property(comment => comment.UserId)
            .HasColumnName("user_id");
        modelBuilder.Entity<Comment>()
            .Property(comment => comment.CreatedDateTime)
            .HasColumnName("created_date_time");
        modelBuilder.Entity<Photo>()
            .Property(photo => photo.FileName)
            .HasColumnName("file_name");
        modelBuilder.Entity<Photo>()
            .Property(photo => photo.RecipeId)
            .HasColumnName("recipe_id");
        modelBuilder.Entity<Ingredient>()
            .Property(ingredient => ingredient.RecipeId)
            .HasColumnName("recipe_id");
        modelBuilder.Entity<Recipe>()
            .Property(recipe => recipe.PrepTime)
            .HasColumnName("prep_time");
    }
}
