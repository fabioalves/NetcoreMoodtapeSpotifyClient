using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentSpotifyApi.AuthorizationFlows.AspNetCore.AuthorizationCode.Extensions;
using FluentSpotifyApi.AuthorizationFlows.AspNetCore.AuthorizationCode.Handler;
using FluentSpotifyApi.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NetMoodtapeSpotifyClient.Service;

namespace NetMoodtapeSpotifyClient
{
    public class Startup
    {
        private readonly string SpotifyAuthenticationScheme = SpotifyDefaults.AuthenticationScheme;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services
                .AddFluentSpotifyClient(clientBuilder => clientBuilder
                    .ConfigurePipeline(pipeline => pipeline
                        .AddAspNetCoreAuthorizationCodeFlow(
                            spotifyAuthenticationScheme: SpotifyAuthenticationScheme)));

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(
                        o =>
                        {
                            o.LoginPath = new PathString("/login");
                            o.LogoutPath = new PathString("/logout");
                        })
                    .AddSpotify(
                        SpotifyAuthenticationScheme,
                        o =>
                        {
                            o.ClientId = Configuration["Spotify:ClientId"];
                            o.ClientSecret = Configuration["Spotify:ClientSecret"];
                            o.Scope.Add("playlist-read-private");
                            o.Scope.Add("playlist-read-collaborative");
                            o.Scope.Add("user-top-read");
                            o.Scope.Add("user-follow-read");                            
                            o.SaveTokens = true;
                            o.CallbackPath = "/callback/";
                        });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
              if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSpotifyInvalidRefreshTokenExceptionHandler("/login");

            app.UseStaticFiles();

            app.UseAuthentication();

            app.Map(
                "/login",
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            // Return a challenge to invoke the Spotify authentication scheme
                            await context.ChallengeAsync(SpotifyAuthenticationScheme, properties: new AuthenticationProperties() { RedirectUri = "/", IsPersistent = true });
                        });
                });

            // Listen for requests on the /logout path, and sign the user out
            app.Map(
                "/logout",
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            // Sign the user out of the authentication middleware (i.e. it will clear the Auth cookie)
                            await context.SignOutAsync();

                            // Redirect the user to the home page after signing out
                            context.Response.Redirect("/");
                        });
                });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
