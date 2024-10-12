using DatsMagic.Config;
using Microsoft.Extensions.Options;

namespace DatsMagic.Services;

public class DataWriter
{
    private readonly DataLogsOptions _options;

    public DataWriter(IOptions<DataLogsOptions> options)
    {
        _options = options.Value;
    }

    public async Task LogMoveRequestAsync(string message)
    {
        using var writer = new StreamWriter(_options.MoveRequestsFilePath, append: true);
        await writer.WriteLineAsync(message);
    }

    public async Task LogMoveResponseAsync(string message)
    {
        using var writer = new StreamWriter(_options.MoveResponsesFilePath, append: true);
        await writer.WriteLineAsync(message);
    }
}