using ApiRestProducto.DataAccess;
using ApiRestProducto.Models;
using ApiRestProducto.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiRestProducto
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiRestProducto", Version = "v1" });
            });

            services.AddDbContext<BBDDContext>(opt => opt.UseInMemoryDatabase("Local"));

            services.AddTransient<IBBDDContext, BBDDContext>();
            services.AddTransient<IDataRepository<Marca>, MarcaRepository>();
            services.AddTransient<IDataRepository<Categoria>, CategoriaRepository>();
            services.AddTransient<IDataRepository<Subcategoria>, SubcategoriaRepository>();
            //services.AddTransient<IDataRepository<SubcategoriaDTO>, SubcategoriaRepository>();
            services.AddTransient<IDataRepository<Producto>, ProductoRepository>();
            //services.AddTransient<IModelService, ModelService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiRestProducto v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
