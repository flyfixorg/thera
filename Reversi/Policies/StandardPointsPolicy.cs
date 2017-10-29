using System.Collections.Generic;
using Reversi.Entities;

namespace Reversi.Policies
{
    public class StandardPointsPolicy : IPointsPolicy
    {
        public int CalculateFieldPoints(Cordinate fieldCord, FieldStateEnum activePlayer, IReadOnlyList<IReadOnlyList<Field>> board, int boardHeight, int boardWidth)
        {
            var points = 0;
            var pointsTmp = 0;

            //UP
            var x = fieldCord.X;
            var y = fieldCord.Y;
            pointsTmp = 0;
            do
            {
                y--;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            //UP-RIGHT
            x = fieldCord.X;
            y = fieldCord.Y;
            points += pointsTmp;
            pointsTmp = 0;
            do
            {
                y--;
                x++;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            //RIGHT
            x = fieldCord.X;
            y = fieldCord.Y;
            points += pointsTmp;
            pointsTmp = 0;
            do
            {
                x++;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            //DOWN RIGHT
            x = fieldCord.X;
            y = fieldCord.Y;
            points += pointsTmp;
            pointsTmp = 0;
            do
            {
                y++;
                x++;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            //DOWN y++
            x = fieldCord.X;
            y = fieldCord.Y;
            points += pointsTmp;
            pointsTmp = 0;
            do
            {
                y++;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            //DOWN LEFT
            x = fieldCord.X;
            y = fieldCord.Y;
            points += pointsTmp;
            pointsTmp = 0;
            do
            {
                y++;
                x--;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            //LEFT x--
            x = fieldCord.X;
            y = fieldCord.Y;
            points += pointsTmp;
            pointsTmp = 0;
            do
            {
                x--;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            // UP-LEFT
            x = fieldCord.X;
            y = fieldCord.Y;
            points += pointsTmp;
            pointsTmp = 0;
            do
            {
                y--;
                x--;
            } while (!SetPoints(ref pointsTmp, x, y, boardHeight, boardWidth, activePlayer, board));

            points += pointsTmp;
            return points;
        }

        public bool SetPoints(ref int points, int x, int y, int boardHeight, int boardWidth, FieldStateEnum activePlayer, IReadOnlyList<IReadOnlyList<Field>> board)
        {
            if (x < 0 || y < 0 || y >= boardHeight || x >= boardWidth || board[y][x].State == FieldStateEnum.Empty)
            {
                points = 0;
                return true;
            }

            if (board[y][x].State == activePlayer)
            {
                return true;
            }

            points++;
            return false;
        }
    }
}