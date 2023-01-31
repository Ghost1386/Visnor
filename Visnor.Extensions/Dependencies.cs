using Microsoft.Extensions.DependencyInjection;
using Stripe;
using Visnor.BusinessLogic.Interfaces;
using Visnor.BusinessLogic.Services;
using CustomerService = Stripe.TestHelpers.CustomerService;

namespace Visnor.Extensions;

public static class Dependencies
{
    public static void AddIService(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IFilmService, FilmService>();
        services.AddTransient<IHashService, HashService>();
        services.AddTransient<IPhotoService, PhotoService>();
        services.AddTransient<IPremiumService, PremiumService>();
        services.AddTransient<IRatingService, RatingService>();
        services.AddTransient<ISortService, SortService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IViewedService, ViewedService>();


        //services.AddScoped<CustomerService>().AddScoped<ChargeService>().AddScoped<TokenService>()
        //    .AddScoped<IPaymentsService, PaymentsService>();
    }
}