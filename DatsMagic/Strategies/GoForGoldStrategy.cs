using DatsMagic.Helpers;
using DatsMagic.Interfaces;
using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;

namespace DatsMagic.Strategies;

public class GoForGoldStrategy : IGameStrategy
{
    public void Execute(World world, Move move)
    {
        foreach (var transport in world.Transports.Where(t => t.Status == "alive"))
        {
            var moveTransport = move.Transports.Find(t => t.Id == transport.Id);

            if (moveTransport != null)
            {
                double x = 0, y = 0;

                if (transport.X > world.MapSize.X / 4
                    && transport.X < 3 * world.MapSize.X / 4
                    && transport.Y > world.MapSize.Y / 4
                    && transport.Y < 3 * world.MapSize.Y / 4)
                {
                    (int x, int y)? bountyCoor = GetNearestBounty(world.Bounties, transport, world.MapSize);
                    if (bountyCoor == null)
                        continue;

                    x = bountyCoor.Value.x - transport.X + transport.SelfAcceleration.X + moveTransport.Acceleration.X;
                    y = bountyCoor.Value.y - transport.Y + transport.SelfAcceleration.Y + moveTransport.Acceleration.Y;
                }
                else
                {
                    //if (transport.X < world.MapSize.X / 4)
                    //    x = (world.MapSize.X / 4) - transport.X + transport.SelfAcceleration.X + moveTransport.Acceleration.X;

                    //if (transport.X > 3 * world.MapSize.X / 4)
                    //    x = (3 * world.MapSize.X / 4) - transport.X + transport.SelfAcceleration.X + moveTransport.Acceleration.X;

                    //if (transport.Y < world.MapSize.Y / 4)
                    //    y = (world.MapSize.Y / 4) - transport.Y + transport.SelfAcceleration.Y + moveTransport.Acceleration.Y;

                    //if (transport.Y > 3 * world.MapSize.Y / 4)
                    //    y = (3 * world.MapSize.Y / 4) - transport.Y + transport.SelfAcceleration.Y + moveTransport.Acceleration.Y;

                    x = (world.MapSize.X / 2) - transport.X + transport.SelfAcceleration.X + moveTransport.Acceleration.X;
                    y = (world.MapSize.Y / 2) - transport.Y + transport.SelfAcceleration.Y + moveTransport.Acceleration.Y;
                }

                var vector = new Vector<double>(x, y);

                (double accX, double accY) = vector.GetKVector(world.MaxAccel);

                moveTransport.Acceleration.X = accX;
                moveTransport.Acceleration.Y = accY;
            }
        }
    }

    private static (int x, int y)? GetNearestBounty(List<Bounty> bounties, Models.Responses.Transport transport, MapSize mapSize)
    {
        var reachableBounties = bounties
            .Where(b =>
                Math.Abs(mapSize.X / 2 - transport.X) < Math.Abs(mapSize.X / 2 - b.X)
                && Math.Abs(mapSize.Y / 2 - transport.Y) < Math.Abs(mapSize.Y / 2 - b.Y)).ToList();

        if (!reachableBounties.Any())
        {
            return null;
        }

        var sortedBounty = reachableBounties
            .OrderBy(b => (new Vector<int>(b.X - transport.X, b.Y - transport.Y)).Length);

        //var sortedBounty = bounties
        //    .OrderBy(b => (new Vector<int>(b.X - transport.X, b.Y - transport.Y)).Length);

        var result = sortedBounty.First();

        return (result.X, result.Y);
    }
}
