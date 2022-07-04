using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;  //these import built-in .NET namespaces for creating a web app

namespace FriendLetter
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env) //create an iteration of the Startup class that contains specific settings and variables to run our project successfully. It's required for configuring a basic ASP.NET Core MVC project.
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }
    public IConfigurationRoot Configuration { get; } //part of adding custom configurations

    public void ConfigureServices(IServiceCollection services) //required built-in method used to set up an application's server
    {
      services.AddMvc(); //adds the MVC service to the project
    }

    public void Configure(IApplicationBuilder app) //ASP.NET calls Configure() when the app launches. It's responsible for telling our app how to handle requests to the server.
    {
      app.UseRouting();

      app.UseEndpoints(routes =>
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      }); //tells our app to use the MVC framework to respond to HTTP requests-- use the Index action of the Home Controller as the default route

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
      }); //not actually required to successfully launch our project. However, it will allow us to test that our Configure() method is working properly

    }
  }
}