using API.Errors;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Exstensions
{
    public static class AplicationServicesExstensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
