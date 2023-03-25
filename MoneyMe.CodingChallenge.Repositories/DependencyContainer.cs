namespace MoneyMe.CodingChallenge.Repositories;
public static class DependencyContainer
{
    public static IServiceCollection AddMoneyMeCodingChallengeRepositories(this IServiceCollection services)
    {
        services.AddScoped<IManageUserRepository, ManageUserRepository>();
        return services;
    }
}