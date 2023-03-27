namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Ports;
public interface IGetMonthlyPaymentInputPort
{
    ValueTask<double> Handle(UserDataFormModel model);
}
