using SejmCalendar.Library.DataAccess;

namespace SejmCalendar.Library;
public interface IBirthdayService
{
    List<SejmMPRecord> SejmMPs { get; set; }

    Task<List<SejmTermRecord>> GetAvailableTerms();
    List<SejmMPRecord> GetMPsByBirthday(DateTime date);
    List<SejmMPRecord> GetMPsByBirthday(int month, int day);
    Task LoadSejmMPsByTermId(int termId);
    Task<string?> GetMPPhotoString(SejmMPRecord mp, int termId);
    Task<string?> GetMPPhotoString(SejmMPRecord mp);
}