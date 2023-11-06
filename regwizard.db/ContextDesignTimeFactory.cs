using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Regwizard.Db
{
    public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseNpgsql(File.ReadAllText("ConnectionString.txt"))
                .Options;
            return new Context(contextOptions);
        }
    }
}
