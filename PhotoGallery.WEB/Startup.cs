using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhotoGallery.BLL.intrerfaces;
using PhotoGallery.BLL.PhotoService;
using PhotoGallery.DAL.EFCore;
using PhotoGallery.DAL.interfaces;
using PhotoGallery.DAL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using PhotoGallery.BLL.ChatService;
using Microsoft.AspNetCore.Http.Connections;
using PhotoGallery.BLL.PathService;
using PhotoGalleryAuthentication.EFCore;
using PhotoGalleryAuthentication.Models;
using Microsoft.AspNetCore.Identity;

namespace PhotoGallery.WEB
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

            services.AddDbContext<GalleryDBContext>(options =>
                options.UseSqlServer(Configuration["Data:GalleryPhoto:ConnectionStrings"]));
                       
            services.AddDbContext<AdminDBContext>(options =>
              options.UseSqlServer(Configuration["Data:PhotoIdentity:ConnectionStrings"]));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AdminDBContext>();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");


            services.AddControllersWithViews();
            services.AddControllers()
               .AddNewtonsoftJson(options =>
               {
                   options.SerializerSettings.ContractResolver = new DefaultContractResolver();
               });
            services.AddSignalR();
          
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
            services.AddScoped<IPhotoCreation,PhotoCreation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=Home}/{action=Index}/{id?}");
               endpoints.MapHub<ChatHub>("/chatHub");
            });
            //IdentitySeedData.EnsurePopulated(app);
            //DBObjectPhotoGallery.Initial();
    }   }
}
