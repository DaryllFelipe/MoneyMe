namespace MoneyMe.CodingChallenge.UseCases;
internal class SaveUserInfoHandler : ISaveUserInfoInputPort
{
    private readonly IManageUserRepository Repository;
    public SaveUserInfoHandler(IManageUserRepository repository) => Repository = repository;

    public async ValueTask Handle(UserDataFormModel model)
    {
		try
		{
            int id = await Repository.IsUserExistsAsync(model);
            if (id < 0)
            {
                await Repository.SaveUserDataAsync(model);
                id = await Repository.IsUserExistsAsync(model);
            }
            model.Id = id;
        }
		catch (Exception)
		{
            throw;
        }
    }
}
