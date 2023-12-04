
namespace SejmCalendar.Library.DataAccess;

public interface ISejmDataAccess
{
    Task<List<SejmMPRecord>> GetAllMPsByTermId(int termId);
    Task<List<SejmTermRecord>> GetAllTerms();
    Task<byte[]?> GetMpPhoto(int mpId, int termId);
}