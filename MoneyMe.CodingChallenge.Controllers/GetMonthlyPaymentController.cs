namespace MoneyMe.CodingChallenge.Controllers;
public class GetMonthlyPaymentController : IGetMonthlyPaymentController
{
    private readonly IGetMonthlyPaymentInputPort InputPort;

    public GetMonthlyPaymentController(IGetMonthlyPaymentInputPort inputPort) => InputPort = inputPort;

    public ValueTask<double> GetMonthlyPaymentAsync(UserDataFormModel model)
        => InputPort.Handle(model);
}
