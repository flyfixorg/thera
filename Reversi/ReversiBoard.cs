using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Entities;
using Reversi.Policies;

namespace Reversi
{
    public class ReversiBoard
    {
        public int Width { get; }
        public int Height { get; }
        private readonly ReversiBoardParser _parser = new ReversiBoardParser();
        private readonly IPointsPolicy _pointsPolicy = new StandardPointsPolicy();
        private List<List<Field>> Board { get; }

        public ReversiBoard(string board)
        {
            Board = _parser.ParseBoardString(board);
            Height = Board.Count;
            Width = Board[0].Count;
        }

        public string GetBestPlace(FieldStateEnum oponent, FieldStateEnum activePlayer)
        {

            var notEmptyFields = GetAllNotEmptyFields(oponent, activePlayer);
            IEnumerable<Field> allPossibleFieldsForMove = GetAllNeightborsEmptyFields(notEmptyFields);

            //If not available movement
            if (!allPossibleFieldsForMove.Any())
            {
                return String.Empty;
            }

            foreach (var f in allPossibleFieldsForMove)
            {
                //Doesn't compute same field many times
                if (f.Points == null)
                {
                    f.Points = _pointsPolicy.CalculateFieldPoints(f.Cordinates, activePlayer,Board,Height,Width);
                }
            }
            var fieldWithMaxPoints = allPossibleFieldsForMove.OrderByDescending(f => f.Points).First();
            return _parser.ConvertCordinatesToFieldDescription(fieldWithMaxPoints.Cordinates);

        }

        private IEnumerable<Field> GetAllNeightborsEmptyFields(IReadOnlyList<Cordinate> notEmptyFields)
        {
            return notEmptyFields
                .SelectMany(GetEmptyNeightbours)
                .Distinct()
                .Select(f => Board[f.Y][f.X]);
        }

        private List<Cordinate> GetAllNotEmptyFields(FieldStateEnum oponent, FieldStateEnum activePlayer)
        {
            var fields = new List<Cordinate>();
            for (short y = 0; y < Height; y++)
            {
                for (short x = 0; x < Width; x++)
                {
                    if (Board[y][x].State == oponent || Board[y][x].State == activePlayer)
                    {
                        fields.Add(new Cordinate(x, y));
                    }
                }
            }
            return fields;
        }

        private List<Cordinate> GetEmptyNeightbours(Cordinate cord)
        {
            List<Cordinate> freeNeightBours =
                cord.GetNeightbours().Where(c => c.X >= 0 &&
                c.X < Width &&
                c.Y >= 0 &&
                c.Y < Height
                && Board[c.Y][c.X].State == FieldStateEnum.Empty).ToList();
            return freeNeightBours;
        }

    }
}
