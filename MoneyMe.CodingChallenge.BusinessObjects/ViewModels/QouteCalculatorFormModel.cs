namespace MoneyMe.CodingChallenge.BusinessObjects.ViewModels;
public class QouteCalculatorFormModel
{
    public Products SelectedProduct { get; set; } = Products.A;
    public int AmountToLoan { get; set; }
    public int TermsOfMonth { get; set; }
}
