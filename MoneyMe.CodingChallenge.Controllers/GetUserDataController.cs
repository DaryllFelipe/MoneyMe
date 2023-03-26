namespace MoneyMe.CodingChallenge.Controllers;
internal class GetUserDataController : IGetUserDataController
{
    private readonly IGetUserDataInputPort InputPort;

    public GetUserDataController(IGetUserDataInputPort inputPort) => InputPort = inputPort;

    public async ValueTask<UserDataFormModel> GetUserDataAsync(int id)
        => await InputPort.Handle(id);
}
