

using MoneyMe.CodingChallenge.BusinessObjects.ViewModels;

namespace MoneyMe.CodingChallenge.Repositories;
internal class ManageUserRepository : IManageUserRepository
{
    public Task<bool> IsUserExistsAsync(UserDataFormModel model)
    {
        return Task.FromResult(true);  
    }

    public Task<bool> SaveUserDataAsync(UserDataFormModel model)
    {
        return Task.FromResult(true);
    }
}