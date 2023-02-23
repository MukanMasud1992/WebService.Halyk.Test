using Microsoft.EntityFrameworkCore;
using WebService.Halyk.Test.Model;

namespace WebService.Halyk.Test.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }
    }
}
