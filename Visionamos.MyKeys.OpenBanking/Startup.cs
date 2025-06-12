using Visionamos.MyKeys.DataAccess.OpenBanking.Context;
using Visionamos.SDK.ApiDocumentation;
using Visionamos.SDK.EFDatabase;

namespace Visionamos.MyKeys.OpenBanking
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDatabaseContext<ManageKeysDbContext>("ManageKeysDbContext");
            services.AddApiDocumentation(false);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                app.UseDatabaseContext<ManageKeysDbContext>();
                app.UseApiDocumentation();
            }
            catch {
                throw;
            }

        }
    }
}
