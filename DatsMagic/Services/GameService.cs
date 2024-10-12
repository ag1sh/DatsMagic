using DatsMagic.Interfaces;
using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;

namespace DatsMagic.Services;

public class GameService
{
    private readonly ILogger<GameService> _logger;
    private readonly DataReader _dataReader;

    public IGameStrategy Strategy { get; set; } = null!;

    public bool IsGameStarted { get; set; }
    public bool IsGameEnded { get; set; }
    public bool IsMainServer { get; set; } = true;
    public bool IsDataFromLogs { get; set; }
    public World? World { get; set; }
    public Move Move { get; set; }

    public GameService(ILogger<GameService> logger, DataReader dataReader)
    {
        _logger = logger;
        _dataReader = dataReader;
    }

    public async Task<GameState> GetGameStateAsync()
    {
        return new GameState
        {
            IsGameStarted = IsGameStarted,
            IsGameEnded = IsGameEnded,
            IsMainServer = IsMainServer,
            IsDataFromLogs = IsDataFromLogs,
            World = IsDataFromLogs ? await _dataReader.ReadDataFromLogs() : World
        };
    }

    public void UpdateGameStatus()
    {
        if (World == null)
        {
            IsGameStarted = false;
            IsGameEnded = true;
        }
        else
        {
            IsGameStarted = true;
            IsGameEnded = false;
        }
    }

    public void ExecuteStrategy()
    {
        Strategy.Execute(World!, Move);
    }
}
