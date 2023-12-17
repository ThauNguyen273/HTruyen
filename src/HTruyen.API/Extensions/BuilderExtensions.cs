using Core;
using Core.Interfaces.Repositories;
using Core.Repositories;
using Core.Services;
using HTruyen.API.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HTruyen.API.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddSingleton(services =>
            {
                var options = services.GetRequiredService<IOptions<MongoDBConnectionOptions>>();
                return new MongoClient(options.Value.ConnectionString).GetDatabase(options.Value.DatabaseName);
            });
            services.AddSingleton<Database>();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRankRepository, RankRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<INovelRepository, NovelRepository>();
            services.AddScoped<IChapterRepository, ChapterRepository>();

            return services;
        }

        public static IServiceCollection AddEntityServices(this IServiceCollection services)
        {
            services.AddScoped<CategoryService>();
            services.AddScoped<RankService>();
            services.AddScoped<WalletService>();
            services.AddScoped<UserService>();
            services.AddScoped<AuthorService>();
            services.AddScoped<NovelService>();
            services.AddScoped<ChapterService>();

            return services;
        }
    }
}
