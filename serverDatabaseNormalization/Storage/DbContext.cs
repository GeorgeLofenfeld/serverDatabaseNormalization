using Microsoft.EntityFrameworkCore;
using serverDatabaseNormalization.Models;

namespace serverDatabaseNormalization.Storage;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<UserModel> Users { get; set; }

}
