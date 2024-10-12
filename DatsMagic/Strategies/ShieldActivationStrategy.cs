using DatsMagic.Interfaces;
using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;

namespace DatsMagic.Strategies;

public class ShieldActivationStrategy : IGameStrategy
{
    public void Execute(World world, Move move)
    {
        foreach (var transport in world.Transports.Where(t => t.Status == "alive"))
        {
            var moveTransport = move.Transports.Find(t => t.Id == transport.Id);

            if (moveTransport != null && transport.ShieldCooldownMs == 0)
            {
                moveTransport.ActivateShield = true;
            }
        }
    }
}
