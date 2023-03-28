namespace MoneyMe.Controllers;

public class HomeController : Controller
{
    private readonly ISaveUserInfoController SaveUserInfoController;
    private readonly IGetUserDataController GetUserDataController;
    private readonly IGetMonthlyPaymentController GetMonthlyPaymentController;
    private readonly IEditUserDataController EditUserDataController;

    public HomeController(ISaveUserInfoController saveUserInfoController, IGetUserDataController getUserDataController, IGetMonthlyPaymentController getMonthlyPaymentController, IEditUserDataController editUserDataController)
    {
        SaveUserInfoController = saveUserInfoController;
        GetUserDataController = getUserDataController;
        GetMonthlyPaymentController = getMonthlyPaymentController;
        EditUserDataController = editUserDataController;
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
                    await EditUserDataController.EditUserDataAsync(Model);
                    return RedirectToAction("QouteCalculator", "Home", new { id = Model.Id });
                }
            }
            else
            {
                await EditUserDataController.EditUserDataAsync(Model);
                return RedirectToAction("QouteCalculator", "Home", new { id = Model.Id });
            }
        }
        else return View(new UserDataFormModel());
    }

    [HttpGet]
    [Route("apply-now/{id}")]
    public async Task<IActionResult> ApplyNow(int id)
    {
        UserDataFormModel userData = await GetUserDataController.GetUserDataAsync(id);
        bool canProceed = true;
        if (userData.DateOfBirth.AddYears(18) < DateTime.Now)
        {
            canProceed = false;
            ViewBag.CantProceedError += "You need to be 18 yrs old so that you can apply to this loan. ";
        }
        List<string> blockedMobileNo = new() { "093098211111", "093098211112" };
        List<string> blockedDomain = new() { "yahoo.com", "bing.com" };
        if (blockedMobileNo.Contains(userData.Mobile))
        {
            canProceed = false;
            ViewBag.CantProceedError += "Your mobile number is blocked. ";
        }
        string emailDomain = GetEmailDomain(userData.Email);
        if (blockedDomain.Contains(emailDomain))
        {
            canProceed = false;
            ViewBag.CantProceedError += "Your email domain is blocked.";
        }
        if (canProceed) return Redirect("https://www.moneyme.com.au/");
        else return View(userData);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private string GetEmailDomain(string email)
    {
        char delimiter = '@';
        int delimiterIndex = email.IndexOf(delimiter);
        string outputString = outputString = email.Substring(delimiterIndex + 1);
        return outputString;
    }
}