using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Reactivities.Domain;
using Reactivities.Infraestructure.Security;
using Reactivities.Persistence;
using System.Text;
using System.Threading.Tasks;

namespace Reactivities.API.Extensions
{
    public static class SerciceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000")
                        .AllowCredentials();
                });
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<DataContext>()
                .AddSignInManager<SignInManager<AppUser>>();

            //var builder = services.AddIdentityCore<AppUser>();
            //var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            //identityBuilder.AddEntityFrameworkStores<DataContext>();
            //identityBuilder.AddSignInManager<SignInManager<AppUser>>();
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsActivityHost", policy =>
                {
                    policy.Requirements.Add(new IsHostRequirement());
                });
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                    opt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["acces_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken)
                                && (path.StartsWithSegments("chat")))
                            {
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}
