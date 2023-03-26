namespace MoneyMe.Controllers;
public class HomeController : Controller
{
    private readonly ISaveUserInfoController SaveUserInfoController;
    private readonly IGetUserDataController GetUserDataController;

    public HomeController(ISaveUserInfoController saveUserInfoController, IGetUserDataController getUserDataController)
    {
        SaveUserInfoController = saveUserInfoController;
        GetUserDataController = getUserDataController;
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
            return RedirectToAction("QouteCalculator", "Home", new { id = Model.Id });
        }
        else return View(new UserDataFormModel());

    }

    [HttpGet]
    [Route("qouteCalculator/{id}")]
    public async Task<IActionResult> QouteCalculator(int id)
    {
        return View(await GetUserDataController.GetUserDataAsync(id));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}