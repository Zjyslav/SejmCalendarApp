using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace SejmCalendar.Library.DataAccess;
public class SejmDataAccess : ISejmDataAccess
{
    private readonly HttpClient _httpClient;

    public SejmDataAccess(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SejmTermRecord>> GetAllTerms()
    {
        List<SejmTermRecord>? output = await _httpClient.GetFromJsonAsync<List<SejmTermRecord>>("sejm/term");
        return output ?? new();
    }

    public async Task<List<SejmMPRecord>> GetAllMPsByTermId(int termId)
    {
        List<SejmMPRecord>? output = await _httpClient.GetFromJsonAsync<List<SejmMPRecord>>($"sejm/term{termId}/MP");
        return output ?? new();
    }
}

#region records
public record SejmTermRecord(int Num,
                             DateTime From,
                             DateTime To,
                             bool Current,
                             PrintsRecord Prints);

public record PrintsRecord(int Count,
                           DateTime LastChanged,
                           string Link);

public record SejmMPRecord(int Id,
                     string FirstLastName,
                     string LastFirstName,
                     string FirstName,
                     string SecondName,
                     string LastName,
                     string Email,
                     bool Active,
                     string InactiveCause,
                     string WaiverDesc,
                     int DistrictNum,
                     string DisctrictName,
                     string Voivodeship,
                     string Club,
                     DateTime BirthDate,
                     string BirthLocation,
                     string Profession,
                     string EducationLevel,
                     int NumberOfVotes);
#endregion