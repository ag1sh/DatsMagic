using DatsMagic.Config;
using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;
using System.Text.Json;

namespace DatsMagic.Services.DatsTeamServers;

public abstract class DatsTeamServer
{
    private readonly DatsTeamServerOptions _options;
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;
    private readonly DataWriter _dataWriter;

    protected DatsTeamServer(
        HttpClient httpClient,
        ILogger logger,
        DataWriter dataWriter,
        string baseUrl,
        DatsTeamServerOptions options)
    {
        _options = options;
        _logger = logger;
        _dataWriter = dataWriter;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(baseUrl);
        _httpClient.DefaultRequestHeaders.Add(options.AuthHeaderName, options.Token);
    }

    public async Task<World?> SendCommandAsync(Move? move)
    {
        var response = await _httpClient.PostAsJsonAsync(_options.MoveUri, move);
        var result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            await _dataWriter.LogMoveResponseAsync(result);
            return JsonSerializer.Deserialize<World>(result)!;
        }
        else
        {
            _logger.LogError("Error while sending Move request : {Error}", result);
        }

        return null;
    }
}
