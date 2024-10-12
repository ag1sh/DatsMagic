using DatsMagic.Config;
using Microsoft.Extensions.Options;

namespace DatsMagic.Services.DatsTeamServers;

public class DatsTeamMainServer(
    HttpClient httpClient,
    ILogger<DatsTeamMainServer> logger,
    DataWriter dataWriter,
    IOptions<DatsTeamServerOptions> options)
    : DatsTeamServer(httpClient, logger, dataWriter, options.Value.MainServerUrl, options.Value)
{ }
