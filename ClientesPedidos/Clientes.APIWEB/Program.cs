using Clientes.BLL;
using Clientes.DAL;
using Clientes.DAL.Dbcontext;
using Clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace Clientes.APIWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //AddSwagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AplicationDbContext>(option =>

                option.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"), p => p.MigrationsAssembly("Clientes.DAL"))

            );
            
            //Add Cors
            var MisReglasCors = "ReglasCors";
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(name: MisReglasCors, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            //Configuracion Automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


            //Inyeccion de Dependencias

            //Clientes
            builder.Services.AddScoped<IClienteServicio, ClienteServicio>();
            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            //Api
            builder.Services.AddScoped<IServicio_API, Servicio_API>();



            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //DbMigration

            using (var scope = app.Services.CreateScope())
            {
                var Context = scope.ServiceProvider.GetRequiredService<AplicationDbContext>();

                if (Context.Database.GetPendingMigrations().Count() > 0)
                {
                    Context.Database.Migrate();
                }                
            }


            app.UseCors(MisReglasCors);
            //add swagger
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
