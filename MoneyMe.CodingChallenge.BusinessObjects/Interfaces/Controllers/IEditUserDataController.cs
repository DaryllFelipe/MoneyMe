namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Controllers;
public interface IEditUserDataController
{
    ValueTask EditUserDataAsync(UserDataFormModel model);
}
