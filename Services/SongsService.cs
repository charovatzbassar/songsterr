using System.Text.Json;
using Project_Task.Interfaces;
using Project_Task.Genius;

namespace Project_Task.Services;

public class SongsService : ISongsService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SongsService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<GeniusResponse?> GetSongs(string query)
    {
        string url = $"https://api.genius.com/search?q={query}&access_token={_configuration["GeniusApiKey"]}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        string json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<GeniusResponse>(json, options);

        if (data == null) return null;

        return data;
    }
}