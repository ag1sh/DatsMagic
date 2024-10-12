using DatsMagic.Helpers;
using DatsMagic.Interfaces;
using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;

namespace DatsMagic.Strategies;

public class GoToCenterStrategy : IGameStrategy
{
    public void Execute(World world, Move move)
    {
        foreach (var transport in world.Transports.Where(t => t.Status == "alive"))
        {
            var moveTransport = move.Transports.Find(t => t.Id == transport.Id);

            if (moveTransport != null)
            {
                var x = (world.MapSize.X / 2) - transport.X + transport.SelfAcceleration.X + moveTransport.Acceleration.X;
                var y = (world.MapSize.Y / 2) - transport.Y + transport.SelfAcceleration.Y + moveTransport.Acceleration.Y;

                var vector = new Vector<double>(x, y);

                (double accX, double accY) = vector.GetKVector(world.MaxAccel);

                moveTransport.Acceleration.X = accX;
                moveTransport.Acceleration.Y = accY;
            }
        }
    }
}
