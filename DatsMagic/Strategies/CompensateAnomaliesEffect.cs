using DatsMagic.Interfaces;
using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;

namespace DatsMagic.Strategies;

public class CompensateAnomaliesEffect : IGameStrategy
{
    public void Execute(World world, Move move)
    {
        foreach (var transport in world.Transports.Where(t => t.Status == "alive"))
        {
            var moveTransport = move.Transports.Find(t => t.Id == transport.Id);

            if (moveTransport == null)
            {
                moveTransport = new Models.Requests.Transport
                {
                    Id = transport.Id,
                    Acceleration = new Acceleration { X = -transport.AnomalyAcceleration.X, Y = -transport.AnomalyAcceleration.Y }
                };

                move.Transports.Add(moveTransport);
            }
        }
    }
}
