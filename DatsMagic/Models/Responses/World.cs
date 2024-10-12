using System.Text.Json.Serialization;

namespace DatsMagic.Models.Responses
{
    public class World
    {
        [JsonPropertyName("anomalies")]
        public List<Anomaly> Anomalies { get; set; }

        [JsonPropertyName("attackCooldownMs")]
        public int AttackCooldownMs { get; set; }

        [JsonPropertyName("attackDamage")]
        public int AttackDamage { get; set; }

        [JsonPropertyName("attackExplosionRadius")]
        public double AttackExplosionRadius { get; set; }

        [JsonPropertyName("attackRange")]
        public double AttackRange { get; set; }

        [JsonPropertyName("bounties")]
        public List<Bounty> Bounties { get; set; } = new();

        [JsonPropertyName("enemies")]
        public List<Enemy> Enemies { get; set; }

        [JsonPropertyName("mapSize")]
        public MapSize MapSize { get; set; }

        [JsonPropertyName("maxAccel")]
        public double MaxAccel { get; set; }

        [JsonPropertyName("maxSpeed")]
        public double MaxSpeed { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("reviveTimeoutSec")]
        public int ReviveTimeoutSec { get; set; }

        [JsonPropertyName("shieldCooldownMs")]
        public int ShieldCooldownMs { get; set; }

        [JsonPropertyName("shieldTimeMs")]
        public int ShieldTimeMs { get; set; }

        [JsonPropertyName("transportRadius")]
        public int TransportRadius { get; set; }

        [JsonPropertyName("transports")]
        public List<Transport> Transports { get; set; }

        [JsonPropertyName("wantedList")]
        public List<Wanted> WantedList { get; set; }

        [JsonPropertyName("errors")]
        public List<string>? Errors { get; set; }
    }

    public class Anomaly
    {
        [JsonPropertyName("effectiveRadius")]
        public double EffectiveRadius { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("radius")]
        public double Radius { get; set; }

        [JsonPropertyName("strength")]
        public double Strength { get; set; }

        [JsonPropertyName("velocity")]
        public Velocity Velocity { get; set; }

        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("y")]
        public double Y { get; set; }
    }

    public class Velocity
    {
        [JsonPropertyName("x")]
        public double X { get; set; }
        
        [JsonPropertyName("y")]
        public double Y { get; set; }
    }

    public class Bounty
    {
        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("radius")]
        public int Radius { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }

    public class Enemy
    {
        [JsonPropertyName("health")]
        public int Health { get; set; }

        [JsonPropertyName("killBounty")]
        public int KillBounty { get; set; }

        [JsonPropertyName("shieldLeftMs")]
        public int ShieldLeftMs { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("velocity")]
        public Velocity Velocity { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }

    public class MapSize
    {
        [JsonPropertyName("x")]
        public int X { get; set; }
        
        [JsonPropertyName("y")]
        public int Y { get; set; }
    }

    public class Transport
    {
        [JsonPropertyName("anomalyAcceleration")]
        public Velocity AnomalyAcceleration { get; set; }

        [JsonPropertyName("attackCooldownMs")]
        public int AttackCooldownMs { get; set; }

        [JsonPropertyName("deathCount")]
        public int DeathCount { get; set; }

        [JsonPropertyName("health")]
        public int Health { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("selfAcceleration")]
        public Velocity SelfAcceleration { get; set; }

        [JsonPropertyName("shieldCooldownMs")]
        public int ShieldCooldownMs { get; set; }

        [JsonPropertyName("shieldLeftMs")]
        public int ShieldLeftMs { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("velocity")]
        public Velocity Velocity { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }

    public class Wanted
    {
        [JsonPropertyName("health")]
        public int Health { get; set; }

        [JsonPropertyName("killBounty")]
        public int KillBounty { get; set; }

        [JsonPropertyName("shieldLeftMs")]
        public int ShieldLeftMs { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("velocity")]
        public Velocity Velocity { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}
