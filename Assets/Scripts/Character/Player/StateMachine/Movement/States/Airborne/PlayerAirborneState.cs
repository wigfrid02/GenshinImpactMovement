using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerAirborneState : PlayerMovementState
    {
        public PlayerAirborneState(PlayerMovementStateMachine playermovementstateMachine) : base(playermovementstateMachine)
        {
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            ResetSprintState();
        }
        #endregion

        #region Reusable Methods
        protected override void OnContactWithGround(Collider collider)
        {
            stateMachine.ChangeState(stateMachine.LightLandingState);
        }

        protected virtual void ResetSprintState()
        {
            stateMachine.ReusableData.ShouldSprint = false;
        }
        #endregion
    }
}
