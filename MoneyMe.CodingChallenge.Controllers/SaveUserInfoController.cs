namespace MoneyMe.CodingChallenge.Controllers;
internal class SaveUserInfoController : ISaveUserInfoController
{
    private readonly ISaveUserInfoInputPort InputPort;

    public SaveUserInfoController(ISaveUserInfoInputPort inputPort) => InputPort = inputPort;

    public async ValueTask SaveUserInfoAsync(UserDataFormModel model)
        => await InputPort.Handle(model);
}
