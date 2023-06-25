using Microsoft.Extensions.DependencyInjection;

namespace ItCareerExam.Service;

public static class ContainerRegistrations
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IRestaurantsService, RestaurantsService>();
        services.AddTransient<IUsersService, UsersService>();
    }
}
