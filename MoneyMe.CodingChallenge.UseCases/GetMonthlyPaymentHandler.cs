namespace MoneyMe.CodingChallenge.UseCases;
internal class GetMonthlyPaymentHandler : IGetMonthlyPaymentInputPort
{
    public ValueTask<double> Handle(UserDataFormModel model)
    {
        double loanAmount = model.AmountRequired;
        double interestRate = 00.00;
        int numPayments = model.Term;
        switch (model.SelectedProduct)
        {
            case Products.B:
                numPayments -= 2;
                break;
            case Products.C:
                interestRate = 0.05 / 12; // 5% annual rate divided by 12 months
                break;
        }

        double monthlyPayment;
        if (model.SelectedProduct == Products.A) monthlyPayment = loanAmount / model.Term;
        else
        {
            monthlyPayment = (loanAmount * interestRate) /
            (1 - Math.Pow(1 + interestRate, -numPayments));
        }

        return ValueTask.FromResult(Math.Round((double)0.00, 2));
    }
}
