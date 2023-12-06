namespace SejmCalendar.Blazor;

public class DateService : IDateService
{
    public DateTime Date { get; private set; } = DateTime.Now;

    public event Action? OnDateChange;

    public void SetDate(DateTime date)
    {
        Date = date;
        NotifyDateChanged();
    }

    public void AddDays(int days)
    {
        Date = Date.AddDays(days);
        NotifyDateChanged();
    }
    private void NotifyDateChanged() => OnDateChange?.Invoke();
}
