using SejmCalendar.Library.DataAccess;
using System.Runtime.CompilerServices;

namespace SejmCalendar.Library;
public class BirthdayService : IBirthdayService
{
    public List<SejmMPRecord> SejmMPs { get; set; } = new();

    private readonly ISejmDataAccess _dataAccess;

    private int _termId;

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
        _termId = termId;
        SejmMPs = await _dataAccess.GetAllMPsByTermId(_termId);
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

    public async Task<string?> GetMPPhotoString(SejmMPRecord mp, int termId)
    {
        var bytes = await _dataAccess.GetMpPhoto(mp.Id, termId);
        var output = $"data:image/jpeg;base64, {Convert.ToBase64String(bytes)}";
        return output;
    }

    public async Task<string?> GetMPPhotoString(SejmMPRecord mp)
    {
        var output = await GetMPPhotoString(mp, _termId);
        return output;
    }

    private void SortMPsByBirthday()
    {
        SejmMPs = SejmMPs
            .OrderBy(x => x.BirthDate.Day)
            .OrderBy(x => x.BirthDate.Month)
            .ToList();
    }
}
