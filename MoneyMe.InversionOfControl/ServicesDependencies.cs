namespace MoneyMe.InversionOfControl;
public static class ServicesDependencies
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMoneyMeCodingChallengeRepositories();
        services.AddMoneyMeCodingChallengeControllers();
        services.AddMoneyMeCodingChallengeUseCases();
        services.AddMoneyMeCodingChallengePresenters();
        services.AddMoneyMeDomainPresenters();
        return services;
    }
}
