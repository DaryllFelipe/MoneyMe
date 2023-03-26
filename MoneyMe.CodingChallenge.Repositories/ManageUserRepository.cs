

using MoneyMe.CodingChallenge.BusinessObjects.ViewModels;

namespace MoneyMe.CodingChallenge.Repositories;
internal class ManageUserRepository : IManageUserRepository
{
    public Task<int> IsUserExistsAsync(UserDataFormModel model)
    {
        return Task.FromResult(5);
    }

    public Task<bool> SaveUserDataAsync(UserDataFormModel model)
    {
        return Task.FromResult(true);
    }

    public Task<UserDataFormModel> GetUserDataAsync(int id)
    {
        return Task.FromResult(new UserDataFormModel()
        {
            Id = 10,
            AmountRequired = 2,
            DateOfBirth = DateTime.Now,
            Email = "adasd13123@gmail.com",
            FirstName = "Test",
            LastName = "Test",
            Mobile = "1231231",
            Term = 2,
            Title = "Ms.",
        });
    }
}