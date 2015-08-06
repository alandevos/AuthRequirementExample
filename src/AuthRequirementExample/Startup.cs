using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Authorization;
using System.Threading;
using System.Security.Claims;

namespace AuthRequirementExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .Configure<AuthorizationOptions>(options =>
                {
                    options.AddPolicy("99bottles", policy => policy.Requirements.Add(new BottleCountRequirement()));
                }
            );
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                context.User = new ClaimsPrincipal(new ClaimsIdentity("application", "given_name", "role"));

                return next.Invoke();
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
