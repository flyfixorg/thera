using System.Linq;

namespace Skills.Policies
{
    public class UnlockSkillPolicy : IUnlockSkillPolicy
    {
        public bool Unlock(SkillNode skillNode)
        {
            if (CanBeUnlocked(skillNode))
            {
                skillNode.Data.Unlock();
                return true;
            }

            return false;
        }
        public bool CanBeUnlocked(SkillNode skillNode)
        {
            //root
            if (!skillNode.Parents.Any() && skillNode.Data.IsLocked)
            {
                return true;
            }

            //Already unlocked
            if (!skillNode.Data.IsLocked)
            {
                return false;
            }

            //Parent locked
            if (skillNode.Parents.Any(p => p.Data.IsLocked))
            {
                return false;
            }

            return true;
        }
    }
}