using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace SejmCalendar.Library.DataAccess;
public class SejmDataAccess : ISejmDataAccess
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SejmDataAccess> _logger;

    public SejmDataAccess(HttpClient httpClient, ILogger<SejmDataAccess> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<SejmTermRecord>> GetAllTerms()
    {
        string requestUri = "sejm/term";
        _logger.LogInformation("API request: {requestUri}", $"{_httpClient.BaseAddress}{requestUri}");
        List<SejmTermRecord>? output = await _httpClient.GetFromJsonAsync<List<SejmTermRecord>>(requestUri);
        return output ?? new();
    }

    public async Task<List<SejmMPRecord>> GetAllMPsByTermId(int termId)
    {
        string requestUri = $"sejm/term{termId}/MP";
        _logger.LogInformation("API request: {requestUri}", $"{_httpClient.BaseAddress}{requestUri}");
        List<SejmMPRecord>? output = await _httpClient.GetFromJsonAsync<List<SejmMPRecord>>(requestUri);
        return output ?? new();
    }

    public async Task<byte[]?> GetMpPhoto(int mpId, int termId)
    {
        string requestUri = $"sejm/term{termId}/MP/{mpId}/photo";
        _logger.LogInformation("API request: {requestUri}", $"{_httpClient.BaseAddress}{requestUri}");
        byte[]? output = await _httpClient.GetByteArrayAsync(requestUri);

        return output;
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