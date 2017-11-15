using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Data.identity;

namespace StoreOfBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
             services.AddDbContext<ApplicationDbContext>(options =>  options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole> (config => {
                   
                    config.Password.RequireDigit = false; // padrão de senha não precisa ter digito                    
                    config.Password.RequiredLength = 3;   // tamnho minimo de 3
                    config.Password.RequireLowercase = false; // nao precisa de letra maiuscula
                    config.Password.RequireNonAlphanumeric = false; //nao precisa de caracter especiais
                    config.Password.RequireUppercase = false; // nao precisa caracter maiusculo                    
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); 

            services.ConfigureApplicationCookie( options => {
                options.LoginPath = "/Account/Login";
            }); //         
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(CategoryStores),  typeof(CategoryStores));
            services.AddTransient(typeof(IUnityOfWork), typeof(UnityOfWork));
            services.AddScoped(typeof(IAuthentication), typeof(Authentication));          
        }
    }
}
