namespace MoneyMe.Domain.Interfaces.Presenters;
public interface IBooleanPresenter
{
    bool Result { get; }
    ValueTask Handle(bool result);
}
