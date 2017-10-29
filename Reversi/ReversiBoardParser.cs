using System;
using System.Collections.Generic;
using System.Linq;
using Reversi.Entities;

namespace Reversi
{
    public class ReversiBoardParser
    {
        public List<List<Field>> ParseBoardString(string boardString)
        {
            List<List<Field>> board = new List<List<Field>>();
            var lines = boardString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            try
            {
                var width = short.Parse(lines[0].Split(' ')[0]);
                var height = short.Parse(lines[0].Split(' ')[1]);
                for (short y = 0; y < height; y++)
                {
                    board.Add(new List<Field>());
                    for (short x = 0; x < width; x++)
                    {
                        var fieldChar = lines[y + 1].Where(c => !char.IsWhiteSpace(c)).ToArray()[x];
                        var fieldState = ConvertToFieldState(fieldChar);
                        board[y].Add(new Field(fieldState, new Cordinate(x, y)));
                    }
                }
                return board;
            }
            catch (Exception ex)
            {
                throw new IncorrectBoardDefinitionException("Incorect board definition string", ex);
            }
        }

        public FieldStateEnum ConvertToFieldState(char c)
        {
            switch (c)
            {
                case 'O':
                    return FieldStateEnum.O;
                case 'X':
                    return FieldStateEnum.X;
                case '.':
                    return FieldStateEnum.Empty;
                default:
                    throw new IncorrectBoardDefinitionException("Incorect char as filed state");
            }
        }

        public string ConvertCordinatesToFieldDescription(Cordinate cord)
        {
            var column = (char)('A' + cord.X);
            var row = (cord.Y + 1).ToString();
            return column + row;
        }
    }
}
