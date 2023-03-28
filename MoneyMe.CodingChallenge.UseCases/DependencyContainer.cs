namespace MoneyMe.CodingChallenge.UseCases;
public static class DependencyContainer
{
    public static IServiceCollection AddMoneyMeCodingChallengeUseCases(this IServiceCollection services)
    {
        services.AddScoped<ISaveUserInfoInputPort, SaveUserInfoHandler>();
        services.AddScoped<IGetUserDataInputPort, GetUserDataHandler>();
        services.AddScoped<IGetMonthlyPaymentInputPort, GetMonthlyPaymentHandler>();
        services.AddScoped<IEditUserDataInputPort, EditUserDataHandler>();
        return services;
    }
}