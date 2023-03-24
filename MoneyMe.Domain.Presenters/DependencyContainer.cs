namespace MoneyMe.Domain.Presenters;
public static class DependencyContainer
{
    public static IServiceCollection AddMoneyMeDomainPresenters(this IServiceCollection services)
    {
        services.AddScoped<IBooleanPresenter, BooleanPresenter>();
        return services;
    }
}