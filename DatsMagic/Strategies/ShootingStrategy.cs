using DatsMagic.Helpers;
using DatsMagic.Interfaces;
using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;

namespace DatsMagic.Strategies;

public class ShootingStrategy : IGameStrategy
{
    public void Execute(World world, Move move)
    {
        foreach (var transport in world.Transports.Where(t => t.Status == "alive"))
        {
            var moveTransport = move.Transports.Find(t => t.Id == transport.Id);

            if (moveTransport != null && transport.AttackCooldownMs == 0)
            {
                (int x, int y)? target = GetTarget(world.Enemies, transport);
                if (target == null)
                    continue;

                var attack = new Attack { X = target.Value.x, Y = target.Value.y };
                moveTransport.Attack = attack;
            }
        }
    }

    private static (int x, int y)? GetTarget(List<Enemy> enemies, Models.Responses.Transport transport)
    {
        (int x, int y)? target = null;
        var reward = -1;

        foreach (var enemy in enemies)
        {
            var vector = new Vector<int>(enemy.X - transport.X, enemy.Y - transport.Y);
            if (vector.Length <= 200 && enemy.KillBounty > reward)
            {
                target = (enemy.X, enemy.Y);
                reward = enemy.KillBounty;
            }
        }

        return target;
    }
}
