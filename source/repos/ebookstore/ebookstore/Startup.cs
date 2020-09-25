using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ebookstore.Data;
using ebookstore.Implementations;
using ebookstore.Migrations.Models;
using ebookstore.Models;
using ebookstore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ebookstore
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
        { //regjistron Context-in si service te IServiceCollection
            services.AddDbContext<ebookDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("ebookDbContextConnection")));

            //metoda AddIdentity duhet te kete te perfshira me patjeter dhe options
            services.AddIdentity<ebookstoreUser, IdentityRole>
                (options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 2;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
        .AddEntityFrameworkStores<ebookDbContext>()
        .AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IBookRepository, BookRepository>();
          
            services.AddTransient<ICategoryRepository,CategoryRepository>();
          //  services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IBookService,BookService>();
            services.AddTransient<ICategoryService, CategoryService>();
           // services.AddTransient<IShoppingCartService, ShoppingCartService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();//per userId
            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //therret extension metoden krijon rolet
            app.UseDatabaseMigrations();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
