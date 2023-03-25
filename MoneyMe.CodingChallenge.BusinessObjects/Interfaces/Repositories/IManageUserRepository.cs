namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Repositories;
public interface IManageUserRepository
{
    Task<bool> IsUserExistsAsync(UserDataFormModel model);
    Task<bool> SaveUserDataAsync(UserDataFormModel model);
}
