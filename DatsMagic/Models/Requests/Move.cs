using System.Text.Json.Serialization;

namespace DatsMagic.Models.Requests;

public class Move
{
    [JsonPropertyName("transports")]
    public List<Transport> Transports { get; set; } = new();
}

public class Transport
{
    [JsonPropertyName("acceleration")]
    public Acceleration Acceleration { get; set; } = null!;

    [JsonPropertyName("activateShield")]
    public bool ActivateShield { get; set; }

    [JsonPropertyName("attack")]
    public Attack? Attack { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}

public class Acceleration
{
    [JsonPropertyName("x")]
    public double X { get; set; } = 0;
    [JsonPropertyName("y")]
    public double Y { get; set; } = 0;
}

public class Attack
{
    [JsonPropertyName("x")]
    public int X { get; set; }
    [JsonPropertyName("y")]
    public int Y { get; set; }
}
