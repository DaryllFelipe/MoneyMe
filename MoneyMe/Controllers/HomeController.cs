namespace MoneyMe.Controllers;

public class HomeController : Controller
{
    private readonly ISaveUserInfoController SaveUserInfoController;
    private readonly IGetUserDataController GetUserDataController;
    private readonly IGetMonthlyPaymentController GetMonthlyPaymentController;

    public HomeController(ISaveUserInfoController saveUserInfoController, IGetUserDataController getUserDataController, IGetMonthlyPaymentController getMonthlyPaymentController)
    {
        SaveUserInfoController = saveUserInfoController;
        GetUserDataController = getUserDataController;
        GetMonthlyPaymentController = getMonthlyPaymentController;
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
            if (Model.SelectedProduct == Products.B)
            {
                if (Model.Term < 6)
                {
                    ViewBag.Error = "Your selected product is product B. Please set the loan term a minimum of 6 months";
                    return View(new UserDataFormModel());
                }
                else
                {
                    await SaveUserInfoController.SaveUserInfoAsync(Model);
                    return RedirectToAction("QouteCalculator", "Home", new { id = Model.Id });
                }
            }
            else
            {
                await SaveUserInfoController.SaveUserInfoAsync(Model);
                return RedirectToAction("QouteCalculator", "Home", new { id = Model.Id });
            }
        }
        else return View(new UserDataFormModel());

    }

    [HttpGet]
    [Route("qouteCalculator/{id}")]
    public async Task<IActionResult> QouteCalculator(int id)
    {
        QouteCalculatorViewModel viewModel = new()
        {
            UserData = await GetUserDataController.GetUserDataAsync(id),
        };

        viewModel.MonthlyRepayment = await GetMonthlyPaymentController.GetMonthlyPaymentAsync(viewModel.UserData);
        return View(viewModel);
    }

    [HttpGet]
    [Route("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        UserDataFormModel model = await GetUserDataController.GetUserDataAsync(id);
        return View(model);
    }

    [HttpPost]
    [Route("edit/{id}")]
    public async Task<IActionResult> Edit(UserDataFormModel Model)
    {
        if (ModelState.IsValid)
        {
            if (Model.SelectedProduct == Products.B)
            {
                if (Model.Term < 6)
                {
                    ViewBag.Error = "Your selected product is product B. Please set the loan term a minimum of 6 months";
                    return View(new UserDataFormModel());
                }
                else
                {
                    await SaveUserInfoController.SaveUserInfoAsync(Model);
                    return RedirectToAction("QouteCalculator", "Edit", new { id = Model.Id });
                }
            }
            else
            {
                await SaveUserInfoController.SaveUserInfoAsync(Model);
                return RedirectToAction("QouteCalculator", "Edit", new { id = Model.Id });
            }
        }
        else return View(new UserDataFormModel());
    }

    [HttpGet]
    [Route("apply-now/{id}")]
    public async Task<IActionResult> ApplyNow(int id)
    {
        UserDataFormModel userData = await GetUserDataController.GetUserDataAsync(id);
        return View(userData);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}