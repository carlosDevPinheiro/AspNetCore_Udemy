using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using module5.Data;
using module5.Models;
using module5.Services;

namespace module5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(

                // customizando as regras de password do identity
                options => {
                    options.Password.RequireDigit = false; // não precisa te numeros
                    options.Password.RequiredLength = 3; // tamnho até 3 caracter
                    options.Password.RequireLowercase = false; // não requer letras minusculas
                    options.Password.RequireUppercase = false; // não precisa ter letras Maiusculas
                    options.Password.RequireNonAlphanumeric = false; // não requer caracteres especiais
                }
            )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // CRIANDO AS ROLES/PAPEIS usados nas aplicação

                // Buscsno o servico de roleManger
            var roleManger = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            if (!roleManger.RoleExistsAsync("ADMIN").Result)
            {
                roleManger.CreateAsync(new IdentityRole("ADMIN"));
            }
            if (!roleManger.RoleExistsAsync("MANAGER").Result)
            {
                roleManger.CreateAsync(new IdentityRole("MANAGER"));                
            }
        }
    }
}
