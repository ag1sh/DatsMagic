using DatsMagic.Config;
using DatsMagic.Models.Responses;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DatsMagic.Services;

public class DataReader
{
    private readonly StreamReader _reader;

    public DataReader(IOptions<DataLogsOptions> options)
    {
        _reader = new StreamReader(options.Value.MoveResponsesFilePath)!;
    }

    public async Task<World?> ReadDataFromLogs()
    {
        var line = await _reader.ReadLineAsync();

        return line != null ? JsonSerializer.Deserialize<World>(line) : null;
    }
}
