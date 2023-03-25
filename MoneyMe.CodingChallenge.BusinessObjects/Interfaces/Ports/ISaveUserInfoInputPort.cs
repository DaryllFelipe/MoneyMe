namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Ports
{
    public interface ISaveUserInfoInputPort
    {
        ValueTask Handle(UserDataFormModel model);
    }
}
