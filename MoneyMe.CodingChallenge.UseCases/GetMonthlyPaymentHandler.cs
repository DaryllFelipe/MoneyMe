namespace MoneyMe.CodingChallenge.UseCases;
internal class GetMonthlyPaymentHandler : IGetMonthlyPaymentInputPort
{
    public ValueTask<double> Handle(UserDataFormModel model)
    {
        double loanAmount = model.AmountRequired;
        double interestRate = 0.05 / 12; // 5% annual rate divided by 12 months
        int numPayments = model.Term;

        double monthlyPayment = (loanAmount * interestRate) /
            (1 - Math.Pow(1 + interestRate, -numPayments));
        return ValueTask.FromResult(Math.Round(monthlyPayment, 2));
    }
}
