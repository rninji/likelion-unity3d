using Pattern.Command;
using UnityEngine;

public class SkillCommand : ICommand
{
    public Player player;
    private string skillName;
    
    public SkillCommand(Player player, string skillname)
    {
        this.player = player;
        this.skillName = skillname;
    }
    
    public void Execute()
    {
        player.UseSkill(skillName);
    }

    public void Cancel()
    {
        player.UseSkillCancel(skillName);
    }
}
