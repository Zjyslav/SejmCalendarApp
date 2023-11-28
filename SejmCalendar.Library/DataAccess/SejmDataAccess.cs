using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace SejmCalendar.Library.DataAccess;
public class SejmDataAccess
{
    private readonly HttpClient _httpClient;

    public SejmDataAccess(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
