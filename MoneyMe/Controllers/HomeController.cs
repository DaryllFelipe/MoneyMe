namespace MoneyMe.Controllers;
public class HomeController : Controller
{
    private readonly ISaveUserInfoController SaveUserInfoController;

    public HomeController(ISaveUserInfoController saveUserInfoController)
    {
        SaveUserInfoController = saveUserInfoController;
    }

    public IActionResult Index()
    {
        return View(new UserDataFormModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserDataFormModel Model)
    {
        if (ModelState.IsValid)
        {
            await SaveUserInfoController.SaveUserInfoAsync(Model);
            return RedirectToAction("QouteCalculator", "Home", new { firstName = Model.FirstName, lastName = Model.LastName, birthDate = Model.DateOfBirth.ToString() });
        }
        else return View(new UserDataFormModel());

    }

    [HttpGet]
    [Route("qouteCalculator/{firstName}/{lastName}/{birthDate}")]
    public IActionResult QouteCalculator(string firstName, string lastName, string birthDate)
    {
        return View(new UserDataFormModel());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}