using System.Collections.Generic;
using NUnit.Framework;
using Skills;
using Skills.Exceptions;

namespace SkillsGraph.Tests
{
    [TestFixture]
    public class SkillsGraphTest
    {
        private Skills.SkillsGraph _skillsGraph = null;
        private Skills.SkillsGraph _skillsTree = null;

        [SetUp]
        public void SetupGraph()
        {
            var warrior = new SkillNode(new Skill("Warrior"));
            var strike = new SkillNode(new Skill("Strike"));
            var hit = new SkillNode(new Skill("Hit"));
            var doubleStrike = new SkillNode(new Skill("Double Strike"));
            var slash = new SkillNode(new Skill("Slash"));
            var knockout = new SkillNode(new Skill("Knockout"));
            var roundHouseKick = new SkillNode(new Skill("Roundhouse Kick"));

            warrior.AddChild(strike, hit);
            strike.AddChild(doubleStrike, slash);
            slash.AddChild(roundHouseKick);
            hit.AddChild(knockout);
            knockout.AddChild(roundHouseKick);

            List<SkillNode> list = new List<SkillNode>
            {
                warrior,
                strike,
                hit,
                doubleStrike,
                slash,
                knockout,
                roundHouseKick
            };
            _skillsGraph = new Skills.SkillsGraph(list);         
        }

        [SetUp]
        public void SetupTree()
        {

            var mage = new SkillNode(new Skill("Mage"));
            var fireball = new SkillNode(new Skill("Fireball"));
            var electroshock = new SkillNode(new Skill("Electroshock"));
            var freeze = new SkillNode(new Skill("Freeze"));
            var thunderbolt = new SkillNode(new Skill("Thunderbolt"));
            var snowstorm = new SkillNode(new Skill("Snowstorm"));;

            mage.AddChild(fireball);
            fireball.AddChild(electroshock, freeze);
            electroshock.AddChild(thunderbolt);
            freeze.AddChild(snowstorm);

            List<SkillNode> list = new List<SkillNode>
            {
                mage,
                fireball,
                electroshock,
                freeze,
                thunderbolt,
                snowstorm,
            };
            _skillsTree = new Skills.SkillsGraph(list);
        }

        [Test]
        public void RootShouldBeAvailableForUnlock()
        {
            Assert.AreEqual(true,_skillsGraph.UnlockSkill("Warrior"));
            Assert.AreEqual(true,_skillsTree.UnlockSkill("Mage"));
        }

        [Test]
        public void AlreadyUnlokedShouldNotBeAvailableForUnlock()
        {
            _skillsGraph.UnlockSkill("Warrior");
            _skillsTree.UnlockSkill("Mage");

            Assert.AreEqual(false, _skillsGraph.UnlockSkill("Warrior"));
            Assert.AreEqual(false, _skillsTree.UnlockSkill("Mage"));
        }

        [Test]
        public void ShouldThrowExceptionWhenSkillNotFound()
        {
            Assert.Throws<SkillNotFoundException>(() => _skillsGraph.UnlockSkill("NotExisitingSkill"));
            Assert.Throws<SkillNotFoundException>(() => _skillsTree.UnlockSkill("NotExisitingSkill"));
        }

        [Test]
        public void NodeWithAllUnlockedParentsShouldBeAvailableForUnlock()
        {
            _skillsGraph.UnlockSkill("Warrior");
            _skillsGraph.UnlockSkill("Strike");
            _skillsGraph.UnlockSkill("Hit");
            _skillsGraph.UnlockSkill("Slash");
            _skillsGraph.UnlockSkill("Knockout");

            _skillsTree.UnlockSkill("Mage");
            _skillsTree.UnlockSkill("Fireball");
            _skillsTree.UnlockSkill("Electroshock");


            Assert.AreEqual(true, _skillsGraph.UnlockSkill("Roundhouse Kick"));
            Assert.AreEqual(true, _skillsTree.UnlockSkill("Thunderbolt"));
        }

        [Test]
        public void NodeWithANotAllUnlockedParentsShouldNotBeAvailableForUnlock()
        {
            _skillsGraph.UnlockSkill("Warrior");
            _skillsGraph.UnlockSkill("Strike");
            _skillsGraph.UnlockSkill("Hit");
            _skillsGraph.UnlockSkill("Slash");
            _skillsGraph.UnlockSkill("Double Strike");

            _skillsTree.UnlockSkill("Mage");
            _skillsTree.UnlockSkill("Fireball");
            _skillsTree.UnlockSkill("Freeze");


            Assert.AreEqual(false, _skillsGraph.UnlockSkill("Roundhouse Kick"));
            Assert.AreEqual(false, _skillsTree.UnlockSkill("Thunderbolt"));
        }
    }
}
