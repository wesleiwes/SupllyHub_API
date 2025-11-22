using Microsoft.EntityFrameworkCore;

namespace SupllyHub.API.Model;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}