using System.Collections.Generic;

namespace Reversi.Entities
{
    public struct Cordinate
    {
        public Cordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public List<Cordinate> GetNeightbours()
        {
            return new List<Cordinate>()
            {
                new Cordinate(X-1,Y),
                new Cordinate(X-1,Y-1),
                new Cordinate(X,Y-1),
                new Cordinate(X+1,Y-1),
                new Cordinate(X+1,Y),
                new Cordinate(X+1,Y+1),
                new Cordinate(X,Y+1),
                new Cordinate(X-1,Y+1)
            };
        }

        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}
    }
}
