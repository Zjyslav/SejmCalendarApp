using SejmCalendar.Library.DataAccess;

namespace SejmCalendar.Library;
public class BirthdayService : IBirthdayService
{
    public List<SejmMPRecord> SejmMPs { get; set; } = new();

    private readonly ISejmDataAccess _dataAccess;

    public BirthdayService(ISejmDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<List<SejmTermRecord>> GetAvailableTerms()
    {
        return await _dataAccess.GetAllTerms();
    }

    public async Task LoadSejmMPsByTermId(int termId)
    {
        SejmMPs = await _dataAccess.GetAllMPsByTermId(termId);
        SortMPsByBirthday();
    }

    public List<SejmMPRecord> GetMPsByBirthday(int month, int day)
    {
        var output = SejmMPs
            .Where(x => x.BirthDate.Day == day && x.BirthDate.Month == month)
            .ToList();

        return output;
    }

    public List<SejmMPRecord> GetMPsByBirthday(DateTime date)
    {
        return GetMPsByBirthday(date.Month, date.Day);
    }

    private void SortMPsByBirthday()
    {
        SejmMPs = SejmMPs
            .OrderBy(x => x.BirthDate.Day)
            .OrderBy(x => x.BirthDate.Month)
            .ToList();
    }
}
