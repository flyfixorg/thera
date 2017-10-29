namespace Reversi.Entities
{
    public class Field
    {
        public Field(FieldStateEnum state, Cordinate cordinates)
        {
            State = state;
            Cordinates = cordinates;
        }
        public  Cordinate Cordinates { get; private set; }
        public int? Points { get; set; }
        public  FieldStateEnum State { get; private set; }
    }
}
