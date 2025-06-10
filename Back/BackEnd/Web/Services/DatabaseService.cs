
//using Entity.Context;
//using Microsoft.EntityFrameworkCore;

//namespace Web.Services
//{
//    public static class DatabaseService
//    {
//        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
//        {

//            // Registrar AuditDbContext si es necesario, con proveedor fijo o dinámico
//            services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

//            return services;
//        }
//    }
//}
