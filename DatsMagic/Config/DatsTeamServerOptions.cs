namespace DatsMagic.Config;

public class DatsTeamServerOptions
{
    public string MainServerUrl { get; set; } = null!;
    public string TestServerUrl { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string AuthHeaderName { get; set; } = null!;
    public string MoveUri { get; set; } = null!;
}
