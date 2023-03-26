namespace MoneyMe.CodingChallenge.UseCases
{
    internal class GetUserDataHandler : IGetUserDataInputPort
    {
        private readonly IManageUserRepository Repository;

        public GetUserDataHandler(IManageUserRepository repository) => Repository = repository;

        public async ValueTask<UserDataFormModel> Handle(int id) 
            => await Repository.GetUserDataAsync(id);
    }
}
