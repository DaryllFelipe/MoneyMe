namespace MoneyMe.CodingChallenge.BusinessObjects.ViewModels;
public class QouteCalculatorViewModel
{
    public UserDataFormModel UserData { get; set; }
    public double MonthlyRepayment { get; set; }
    public double EstablismentFee => Math.Round(UserData.AmountRequired * 0.05, 2);
    public double WeeklyRepayment => Math.Round(MonthlyRepayment / 4, 2);
    public double TotalRepayment => GetTotalRepayment();
    public double Interest => GetInterest();

    private double GetInterest()
    {
        double interest;
        if (UserData.SelectedProduct == Products.A) interest = 0.00;
        else interest = Math.Round(TotalRepayment - (UserData.AmountRequired + EstablismentFee), 2);
        return interest;
    }

    private double GetTotalRepayment()
    {
        double total;
        if (UserData.SelectedProduct == Products.A) total = Math.Round(UserData.AmountRequired + EstablismentFee, 2);
        else total = Math.Round((UserData.Term * MonthlyRepayment) + EstablismentFee, 2);
        return total;
    }
}
