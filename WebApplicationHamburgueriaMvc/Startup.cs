﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using WebApplicationHamburgueriaMvc.Areas.Admin.AdminServices;
using WebApplicationHamburgueriaMvc.Context;
using WebApplicationHamburgueriaMvc.Models;
using WebApplicationHamburgueriaMvc.Repositories;
using WebApplicationHamburgueriaMvc.Repositories.Interfaces;
using WebApplicationHamburgueriaMvc.Services;

namespace WebApplicationHamburgueriaMvc
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));

            /*services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
            });*/

            services.AddTransient<ILancheRepository, LancheRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(isp => CarrinhoCompra.GetCarrinho(isp));
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<RelatoriosVendasService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", politica =>
                {
                    politica.RequireRole("Admin");
                });
            });

            services.AddControllersWithViews();

            services.AddPaging(options => // paginação  
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            seedUserRoleInitial.SeedRoles(); // criar os perfis
            seedUserRoleInitial.SeedUsers(); // criar usuarios e atribuir aos perfis

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "categoriaFiltro",
                    pattern: "Lanche/{action}/{categoria?}",
                    defaults: new { Controller = "Lanche", Action = "List" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }

}
