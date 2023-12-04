
namespace SejmCalendar.Blazor;

public interface IDateService
{
    DateTime Date { get; }

    event Action? OnDateChange;

    void AddDays(int days);
    void SetDate(DateTime date);
}