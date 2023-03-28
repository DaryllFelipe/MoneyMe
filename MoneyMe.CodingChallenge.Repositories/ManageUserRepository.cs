using Microsoft.EntityFrameworkCore;

namespace MoneyMe.CodingChallenge.Repositories;
internal class ManageUserRepository : IManageUserRepository, IDisposable
{
    private readonly Context MyContext;
    public ManageUserRepository()
    {
        MyContext = new();
    }

    public Task<int> IsUserExistsAsync(UserDataFormModel model)
    {
        return Task.FromResult(5);
    }

    public Task<bool> SaveUserDataAsync(UserDataFormModel model)
    {
        bool result;
        Loan data = new()
        {
            AmountRequired = model.AmountRequired,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Id = model.Id,
            Mobile = model.Mobile,
            Term = model.Term,
            Title = model.Title,
        };
        try
        {
            MyContext.Loans.Add(data);
            MyContext.SaveChanges();
            model.Id = data.Id;
            result = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = false;
        }
        return Task.FromResult(result);
    }

    public Task<UserDataFormModel> GetUserDataAsync(int id)
    {
        Loan loan = MyContext.Loans.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(new UserDataFormModel() 
        {
             Id = id,
              AmountRequired = loan.AmountRequired,
               DateOfBirth=loan.DateOfBirth,
                Email = loan.Email,
                 FirstName= loan.FirstName,
                  LastName= loan.LastName,
                   Mobile = loan.Mobile,
                    SelectedProduct = loan.SelectedProduct,
                     Term = loan.Term,
                      Title = loan.Title,
        });
    }

    public void Dispose()
    {
        MyContext.Dispose();
    }
}