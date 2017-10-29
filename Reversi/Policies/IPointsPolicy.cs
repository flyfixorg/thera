using System.Collections.Generic;
using Reversi.Entities;

namespace Reversi.Policies
{
    public interface IPointsPolicy
    {
        bool SetPoints(ref int points, int x, int y, int boardHeight, int boardWidth, FieldStateEnum activePlayer, IReadOnlyList<IReadOnlyList<Field>> board);
        int CalculateFieldPoints(Cordinate fieldCord, FieldStateEnum activePlayer, IReadOnlyList<IReadOnlyList<Field>> board, int boardHeight, int boardWidth);
    }
}