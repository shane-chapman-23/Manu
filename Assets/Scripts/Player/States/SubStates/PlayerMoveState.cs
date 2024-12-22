using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerFSMController stateMachineController, PlayerData playerData, string animBoolName) : base(player, stateMachineController, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckForNoMovementInput();
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.CheckIfShouldFlip(player.XInput);
        player.SetVelocityX(playerData.movementVelocity * player.XInput);
    }

    private void CheckForNoMovementInput()
    {
        if (player.XInput == 0)
        {
            stateMachineController.ChangeState(player.SlideState);
        }
    }
}
