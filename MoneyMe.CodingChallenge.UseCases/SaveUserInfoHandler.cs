namespace MoneyMe.CodingChallenge.UseCases;
internal class SaveUserInfoHandler : ISaveUserInfoInputPort
{
    private readonly IManageUserRepository Repository;
    public SaveUserInfoHandler(IManageUserRepository repository) => Repository = repository;

    public async ValueTask Handle(UserDataFormModel model)
    {
		try
		{
            bool isUserExists = await Repository.IsUserExistsAsync(model);
            if (!isUserExists) await Repository.SaveUserDataAsync(model);
        }
		catch (Exception)
		{
            throw;
        }
    }
}
