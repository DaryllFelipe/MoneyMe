namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Controllers;
public interface IGetUserDataController
{
    ValueTask<UserDataFormModel> GetUserDataAsync(int id);
}
