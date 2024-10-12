using DatsMagic.Config;
using Microsoft.Extensions.Options;

namespace DatsMagic.Services.DatsTeamServers;

public class DatsTeamTestServer(
    HttpClient httpClient,
    ILogger<DatsTeamTestServer> logger,
    DataWriter dataWriter,
    IOptions<DatsTeamServerOptions> options)
    : DatsTeamServer(httpClient, logger, dataWriter, options.Value.TestServerUrl, options.Value)
{ }
