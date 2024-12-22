using UnityEngine;

public class PlayerSlideState : PlayerGroundedState
{
    public PlayerSlideState(Player player, PlayerFSMController stateMachineController, PlayerData playerData, string animBoolName) : base(player, stateMachineController, playerData, animBoolName)
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
        ChangeToIdleAfterDecelerate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Decelerate();
    }

    private void Decelerate()
    {
        float playerVelocityX = player.Rigidbody.linearVelocity.magnitude;

        if (playerVelocityX > 0)
        {
            player.Rigidbody.linearVelocity *= (1 - playerData.decelerationRate);
        }
    }

    private void ChangeToIdleAfterDecelerate()
    {
        float playerVelocityX = player.Rigidbody.linearVelocity.magnitude;

        if (playerVelocityX < 0.1f)
        {
            stateMachineController.ChangeState(player.IdleState);
        }
    }
}
