using DatsMagic.Models.Requests;
using DatsMagic.Services.DatsTeamServers;
using DatsMagic.Strategies;

namespace DatsMagic.Services;

public class GameTick : BackgroundService
{
    private readonly GameService _gameService;
    private readonly DatsTeamMainServer _mainserver;
    private readonly DatsTeamTestServer _testserver;
    private readonly ILogger<GameTick> _logger;

    private DatsTeamServer GameServer => _gameService.IsMainServer ? _mainserver : _testserver;

    public GameTick(
        GameService gameService,
        DatsTeamMainServer mainserver,
        DatsTeamTestServer testserver,
        ILogger<GameTick> logger)
    {
        _gameService = gameService;
        _mainserver = mainserver;
        _testserver = testserver;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Move? move = null;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var world = await GameServer.SendCommandAsync(move);
                move = new();

                _gameService.World = world;
                _gameService.Move = move;

                _gameService.UpdateGameStatus();

                if (_gameService.IsGameEnded)
                {
                    move = null;
                    await Task.Delay(300000, stoppingToken);
                    continue;
                }

                _gameService.Strategy = new CompensateAnomaliesEffect();
                _gameService.ExecuteStrategy();

                _gameService.Strategy = new GoForGoldStrategy();
                _gameService.ExecuteStrategy();

                _gameService.Strategy = new ShootingStrategy();
                _gameService.ExecuteStrategy();

                _gameService.Strategy = new ShieldActivationStrategy();
                _gameService.ExecuteStrategy();

                await Task.Delay(350, stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                move = null;
            }
        }
    }
}
