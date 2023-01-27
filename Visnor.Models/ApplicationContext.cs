using Microsoft.EntityFrameworkCore;
using Visnor.Models.Models;

namespace Visnor.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Auth> Auths { get; set; }
    public DbSet<Ban> Bans { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Premium> Premiums { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<StripeCustomer> StripeCustomers { get; set; }
    public DbSet<StripePayment> StripePayments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Viewing> Viewings { get; set; }
}