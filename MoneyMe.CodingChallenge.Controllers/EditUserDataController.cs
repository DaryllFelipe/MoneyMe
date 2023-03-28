namespace MoneyMe.CodingChallenge.Controllers;
internal class EditUserDataController : IEditUserDataController
{
    private readonly IEditUserDataInputPort InputPort;

    public EditUserDataController(IEditUserDataInputPort inputPort) => InputPort = inputPort;

    public async ValueTask EditUserDataAsync(UserDataFormModel model)
        => await InputPort.Handle(model);
}
