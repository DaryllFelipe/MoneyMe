namespace MoneyMe.CodingChallenge.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddMoneyMeCodingChallengeControllers(this IServiceCollection services)
    {
        services.AddScoped<ISaveUserInfoController, SaveUserInfoController>();
        services.AddScoped<IGetUserDataController, GetUserDataController>();
        services.AddScoped<IGetMonthlyPaymentController, GetMonthlyPaymentController>();
        return services;
    }
}