using ItCareerExam.Data.Repositories;
using ItCareerExam.Data.Seed;
using Microsoft.Extensions.DependencyInjection;

namespace ItCareerExam.Data;

public static class ContainerRegistrations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IDatabaseSeeder, DatabaseSeeder>();
    }
}
