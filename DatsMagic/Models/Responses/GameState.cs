using System.Text.Json.Serialization;

namespace DatsMagic.Models.Responses;

public class GameState
{
    [JsonPropertyName("isGameStarted")]
    public bool IsGameStarted { get; set; }

    [JsonPropertyName("isGameEnded")]
    public bool IsGameEnded { get; set; }

    [JsonPropertyName("isMainServer")]
    public bool IsMainServer { get; set; }

    [JsonPropertyName("isDataFromLogs")]
    public bool IsDataFromLogs { get; set; }

    [JsonPropertyName("world")]
    public World? World { get; set; }
}
