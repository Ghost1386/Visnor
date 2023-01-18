using Microsoft.Extensions.DependencyInjection;
using Visnor.BusinessLogic.Interfaces;
using Visnor.BusinessLogic.Services;

namespace Visnor.Extensions;

public static class Dependencies
{
    public static void AddIService(this IServiceCollection services)
    {
        services.AddTransient<IHashService, HashService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IFilmService, FilmService>();
        services.AddTransient<IPhotoService, PhotoService>();
        services.AddTransient<IRatingService, RatingService>();
        services.AddTransient<ISortService, SortService>();
    }
}