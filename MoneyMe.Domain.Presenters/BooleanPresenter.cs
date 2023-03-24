namespace MoneyMe.Domain.Presenters;
public class BooleanPresenter : IBooleanPresenter
{
    public bool Result { get; private set; }

    public ValueTask Handle(bool result)
    {
        Result = result;
        return ValueTask.CompletedTask;
    }
}
