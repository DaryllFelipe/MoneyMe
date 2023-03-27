namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Controllers;
public interface IGetMonthlyPaymentController
{
    ValueTask<double> GetMonthlyPaymentAsync(UserDataFormModel model);
}
