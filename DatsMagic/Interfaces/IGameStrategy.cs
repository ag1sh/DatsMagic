using DatsMagic.Models.Requests;
using DatsMagic.Models.Responses;

namespace DatsMagic.Interfaces;

public interface IGameStrategy
{
    public void Execute(World world, Move move);
}
