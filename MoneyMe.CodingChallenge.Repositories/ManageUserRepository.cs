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
            Email = "sample@gmail.com",
            FirstName = "Daryll",
            LastName = "Felipe",
            Mobile = "09633213003",
            Term = 2,
            Title = "Mr.",
        });
    }
}