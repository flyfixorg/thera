using System;
using System.Collections.Generic;
using System.Linq;
using Skills.Exceptions;
using Skills.Policies;

namespace Skills
{
    public class SkillsGraph
    {

        //Use DI Container
        readonly IUnlockSkillPolicy _unlockPolicy = new UnlockSkillPolicy();
        public List<SkillNode> Skills { get; }

        public SkillsGraph(List<SkillNode> skills)
        {
            Skills = skills;
        }

        public bool UnlockSkill(string name)
        {
           return _unlockPolicy.Unlock(GetSkill(name));
        }

        public SkillNode GetSkill(string name)
        {
            try
            {
                return Skills.Single(s => s.Data.Name == name);
            }
            catch (Exception ex)
            {
                throw new SkillNotFoundException($"Skill {name} cannot be find in graph", ex);
            }
        }
    }
}
