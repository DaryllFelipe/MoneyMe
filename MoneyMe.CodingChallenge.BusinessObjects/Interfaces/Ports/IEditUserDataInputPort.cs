namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Ports;
public interface IEditUserDataInputPort
{
    ValueTask Handle(UserDataFormModel model);
}
