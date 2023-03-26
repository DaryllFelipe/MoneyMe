namespace MoneyMe.CodingChallenge.BusinessObjects.Interfaces.Repositories;
public interface IManageUserRepository
{
    Task<int> IsUserExistsAsync(UserDataFormModel model);
    Task<bool> SaveUserDataAsync(UserDataFormModel model);
    Task<UserDataFormModel> GetUserDataAsync(int id);
}
