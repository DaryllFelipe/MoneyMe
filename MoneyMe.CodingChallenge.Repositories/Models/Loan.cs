namespace MoneyMe.CodingChallenge.Repositories.Models;
internal class Loan
{
    public int Id { get; set; }
    public int AmountRequired { get; set; }
    public int Term { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
}
