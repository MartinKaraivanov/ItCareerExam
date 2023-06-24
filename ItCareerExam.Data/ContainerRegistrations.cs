using ItCareerExam.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ItCareerExam.Data;

public static class ContainerRegistrations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
    }
}
