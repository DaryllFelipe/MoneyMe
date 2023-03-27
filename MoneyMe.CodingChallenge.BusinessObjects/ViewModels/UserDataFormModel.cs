namespace MoneyMe.CodingChallenge.BusinessObjects.ViewModels;
public class UserDataFormModel
{

    public int Id { get; set; }
    public Products SelectedProduct { get; set; } = Products.A;
    [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than or equal to 0.")]
    public int AmountRequired { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than or equal to 0.")]
    public int Term { get; set; }
    [Display(Name = "Title")]
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
    [Display(Name = "Date Of Birth")]
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    [Display(Name = "Mobile #")]
    [Required(ErrorMessage = "Mobile is required")]
    public string Mobile { get; set; }
    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
}
