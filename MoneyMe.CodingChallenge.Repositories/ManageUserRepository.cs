using Microsoft.EntityFrameworkCore;
using MoneyMe.CodingChallenge.BusinessObjects.Enums;

namespace MoneyMe.CodingChallenge.Repositories;
internal class ManageUserRepository : IDisposable, IManageUserRepository
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
            SelectedProduct = (int)model.SelectedProduct,
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
        UserDataFormModel model = new();
        if (loan != null)
        {
            model = new UserDataFormModel()
            {
                Id = id,
                AmountRequired = loan.AmountRequired,
                DateOfBirth = loan.DateOfBirth,
                Email = loan.Email,
                FirstName = loan.FirstName,
                LastName = loan.LastName,
                Mobile = loan.Mobile,
                SelectedProduct = (Products)loan.SelectedProduct,
                Term = loan.Term,
                Title = loan.Title,
            };
        }
        return Task.FromResult(model);
    }

    public Task<bool> EditUserDataAsync(UserDataFormModel model)
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
            SelectedProduct = (int)model.SelectedProduct,
            Title = model.Title,
        };
        try
        {
            MyContext.Loans.Update(data);
            MyContext.SaveChanges();
            result = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = false;
        }
        return Task.FromResult(result);
    }

    public void Dispose()
    {
        MyContext.Dispose();
    }
}