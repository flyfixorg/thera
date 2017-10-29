using Reversi.Entities;

namespace Reversi
{
    public class Solution
    {
        public static string PlaceToken(string board)
        {
            var reversiBoard = new ReversiBoard(board);
            return reversiBoard.GetBestPlace(FieldStateEnum.O,FieldStateEnum.X);
        }
    }

}
