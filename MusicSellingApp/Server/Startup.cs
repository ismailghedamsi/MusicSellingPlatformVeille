using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json;
using MusicSellingApp.Server.Services;
using Newtonsoft.Json.Serialization;
using Syncfusion.Blazor;
using Stripe;
using Blazored.LocalStorage;

namespace MusicSellingApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            /*if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
            {
                services.AddSingleton<HttpClient>();
            }*/

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //options.SerializerSettings.Converters.Add(new UserJsonConverter());
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddScoped<MusicSellingApp.Shared.CustomHttpClient>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IFanService, FanService>();
            services.AddControllersWithViews();
            services.AddSyncfusionBlazor();
            services.AddRazorPages();
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["pk_test_51HakXCLFPzNgSBSANeSzkeuB3Auq48VYiEnswBQRz957pA8rhSnfFnrqVAPQMqI1P8nIh0vkz2KgWHSLuL2Vx2Kn00S38a7TJd"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
