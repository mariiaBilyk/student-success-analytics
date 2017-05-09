using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StudentSuccessAnalytics.UI
{
        public class Startup {
            public void ConfigureServices ( IServiceCollection services ) {
                services.AddMvc();
                var corsBuilder = new CorsPolicyBuilder();
                corsBuilder.AllowAnyHeader();
                corsBuilder.AllowAnyMethod();
                corsBuilder.AllowAnyOrigin();
                corsBuilder.AllowCredentials();

                services.AddCors(options => {
                    options.AddPolicy("AllowAll", corsBuilder.Build());
                });
            }

            public void Configure ( IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory ) {
                DefaultFilesOptions options = new DefaultFilesOptions();
                options.DefaultFileNames.Clear();
                options.DefaultFileNames.Add("src/index.html");

                app.Use(async ( context, next ) => {
                    await next();

                    if ( context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) ) {
                        context.Request.Path = "/src/index.html";
                        await next();
                    }
                })
                .UseCors("AllowAll")
                .UseMvc()
                .UseDefaultFiles(options)
                .UseStaticFiles();
            }
        }
}
