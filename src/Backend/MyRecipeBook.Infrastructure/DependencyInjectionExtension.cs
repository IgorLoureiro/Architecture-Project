using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAcess;
using MyRecipeBook.Infrastructure.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepositories(services);
            AddDbContext(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {

            var connectionString = "Server=localhost;Database=meulivrodereceitas;User=root;Password=Belphegor@2002;";

            services.AddDbContext<MyRecipeBookDbContext>(DbContextOptions =>
            {
                DbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
    }
}
