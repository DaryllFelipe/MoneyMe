namespace MoneyMe.CodingChallenge.UseCases;
public static class DependencyContainer
{
    public static IServiceCollection AddMoneyMeCodingChallengeUseCases(this IServiceCollection services)
    {
        services.AddScoped<ISaveUserInfoInputPort, SaveUserInfoHandler>();
        services.AddScoped<IGetUserDataInputPort, GetUserDataHandler>();
        return services;
    }
}