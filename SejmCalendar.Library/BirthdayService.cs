using SejmCalendar.Library.DataAccess;

namespace SejmCalendar.Library;
public class BirthdayService
{
    private readonly ISejmDataAccess _dataAccess;

    public BirthdayService(ISejmDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
}
