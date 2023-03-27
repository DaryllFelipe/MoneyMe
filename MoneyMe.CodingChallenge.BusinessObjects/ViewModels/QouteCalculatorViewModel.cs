namespace MoneyMe.CodingChallenge.BusinessObjects.ViewModels;
public class QouteCalculatorViewModel
{
    public UserDataFormModel UserData { get; set; }
    public double MonthlyRepayment { get; set; }
    public double EstablismentFee { get; set; } = 50.00;
    public double WeeklyRepayment => Math.Round(MonthlyRepayment / 4, 2);
    public double TotalRepayment => Math.Round(UserData.Term * MonthlyRepayment, 2);
    public double Interest => Math.Round(TotalRepayment - (UserData.AmountRequired + EstablismentFee), 2);
}
