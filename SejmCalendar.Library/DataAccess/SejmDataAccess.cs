using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace SejmCalendar.Library.DataAccess;
public class SejmDataAccess
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

#endregion