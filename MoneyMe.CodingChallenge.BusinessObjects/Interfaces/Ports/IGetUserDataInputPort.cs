namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Ports;
public interface IGetUserDataInputPort
{
    ValueTask<UserDataFormModel> Handle(int id);
}
