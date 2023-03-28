namespace MoneyMe.CodingChallenge.UseCases;
internal class EditUserDataHandler : IEditUserDataInputPort
{
    private readonly IManageUserRepository Repository;

    public EditUserDataHandler(IManageUserRepository repository) => Repository = repository;

    public async ValueTask Handle(UserDataFormModel model)
    {
		try
		{
			await Repository.EditUserDataAsync(model);
        }
		catch (Exception)
		{
			throw;
		}
    }
}
