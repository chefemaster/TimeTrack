namespace TimeTrackWebApp.Startup
{
    public static class StartupExtension
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webApplicationBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentNullException("startup");
            startup.ConfigureServices(webApplicationBuilder.Services);

            var app = webApplicationBuilder.Build();
            startup.Configure(app);
            app.Run();

            return webApplicationBuilder;
        }
    }
}
