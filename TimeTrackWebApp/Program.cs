using TimeTrackWebApp.Startup;

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();
