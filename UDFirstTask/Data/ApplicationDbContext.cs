using Microsoft.EntityFrameworkCore;
using UDFirstTask.Models;

namespace UDFirstTask.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        #region DbSets
        // DbSets
        public DbSet<Information> Informations { get; set; }
        #endregion
    }
}
