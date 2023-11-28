using SejmCalendar.Library.DataAccess;

namespace SejmCalendar.Blazor.Models;

public class DayModel
{
    public DateTime Date { get; set; }
    public List<SejmMPRecord> SejmMPs { get; set; } = new();
}
