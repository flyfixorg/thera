namespace Skills.Policies
{
    public interface IUnlockSkillPolicy
    {
        /// <summary>
        /// Unlock skill node
        /// </summary>
        /// <param name="skillNode">Node to unlock</param>
        /// <returns>True if operation has been done, False otherwise</returns>
        bool Unlock(SkillNode skillNode);

        /// <summary>
        /// Check if node can be unlock
        /// </summary>
        /// <param name="skillNode">Node to check</param>
        /// <returns>True if node can be unlock</returns>
        bool CanBeUnlocked(SkillNode skillNode);
    }
}
