using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AughtSieve.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
             builder.Services.AddDbContext<ApplicationDbContext<IdentityUser>>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDBContext")));
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext<IdentityUser>>();
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthorization();

            app.MapIdentityApi<IdentityUser>();

            app.MapControllers();
            app.Run();
        }
    }
}
