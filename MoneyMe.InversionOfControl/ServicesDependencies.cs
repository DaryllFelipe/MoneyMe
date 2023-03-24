namespace MoneyMe.InversionOfControl;
public static class ServicesDependencies
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMoneyMeCodingChallengeUseCases();
        services.AddMoneyMeCodingChallengePresenters();
        services.AddMoneyMeCodingChallengeControllers();
        services.AddMoneyMeCodingChallengeRepositories();
        services.AddMoneyMeDomainPresenters();
        return services;
    }
}
