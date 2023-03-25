namespace MoneyMe.CodingChallenge.BusinessObjects.ViewModels;
public class UserDataFormModel
{
    [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than or equal to 0.")]
    public int AmountRequired { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than or equal to 0.")]
    public int Term { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Mobile is required")]
    public string Mobile { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
}
