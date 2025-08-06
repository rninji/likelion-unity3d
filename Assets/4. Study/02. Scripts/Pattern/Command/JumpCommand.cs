using Pattern.Command;
using UnityEngine;

public class JumpCommand : ICommand
{
    public Player player;
    public JumpCommand(Player player)
    {
        this.player = player;
    }
    
    public void Execute()
    {
        player.Jump();
    }

    public void Cancel()
    {
        player.JumpCancel();
    }
}
