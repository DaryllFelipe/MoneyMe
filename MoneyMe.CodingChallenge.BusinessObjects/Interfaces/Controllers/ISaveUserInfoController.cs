namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Controllers;
public interface ISaveUserInfoController
{
    ValueTask SaveUserInfoAsync(UserDataFormModel model);
}
