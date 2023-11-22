using Microsoft.EntityFrameworkCore;
using NagyiReceptjei.API.Models;

namespace NagyiReceptjei.API.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .Property(recipe => recipe.PrepTime)
            .HasColumnName("prep_time");
        modelBuilder.Entity<Comment>()
            .Property(comment => comment.RecipeId)
            .HasColumnName("recipe_id");
        modelBuilder.Entity<Comment>()
            .Property(comment => comment.UserId)
            .HasColumnName("user_id");
    }
}
