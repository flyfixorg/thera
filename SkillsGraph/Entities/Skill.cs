namespace Skills
{
    public class Skill
    {
        public Skill(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public bool IsLocked { get; private set; } = true;
        public void Unlock()
        {
            IsLocked = false;
        }
    }
}
