namespace TimeTrackWebApp.Startup
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            return services.;
        }

        public void Configure(IApplicationBuilder app)
        {            
            WebApplication? webApp = app as WebApplication;            
            if (webApp == null) throw new ArgumentNullException("Builder is not WebApplication");

            // Configure the HTTP request pipeline.
            if (!webApp.Environment.IsDevelopment())
            {
                webApp.UseExceptionHandler("/Home/Error");
            }
            webApp.UseStaticFiles();
            webApp.UseRouting();
            webApp.UseAuthorization();
            webApp.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
